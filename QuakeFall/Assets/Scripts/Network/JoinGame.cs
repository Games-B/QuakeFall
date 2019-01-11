using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

namespace Network
{
    public class JoinGame : MonoBehaviour {

        // This will list all room names and how many players are in the game.
        List<GameObject> _roomList = new List<GameObject>();

        [SerializeField]
        private Text _status;

        [SerializeField]
        private GameObject _roomListItemPrefab;

        [SerializeField]
        private Transform _roomListParent;


        // This will reference the Network manager
        private NetworkManager _networkManager;

        // This will allow players to refresh if they cannot see a game and will happen on start. 
        void Start()
        {
            _networkManager = NetworkManager.singleton;
            if(_networkManager.matchMaker == null)
            {
                _networkManager.StartMatchMaker();
            }

            RefreshRoomList();
        }

        // This will refresh the pages on the server.
        public void RefreshRoomList()
        {
            ClearRoomList();

            if (_networkManager.matchMaker == null)
            {
                _networkManager.StartMatchMaker();
            }
        
            if (_networkManager != null)
                _networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
            _status.text = "Loading...";
        }

        // This will list all matches available.
        // If player cannot connect disconnect.
        public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
        {
            _status.text = "";

            if (!success || matchList == null)
            {
                _status.text = "Couldn't get room list.";
                return;
            }

            foreach (MatchInfoSnapshot match in matchList)
            {
                GameObject _roomListItemGO = Instantiate(_roomListItemPrefab);
                _roomListItemGO.transform.SetParent(_roomListParent);

                // Have a component sit on the gameObject
                RoomListItem _roomListItem = _roomListItemGO.GetComponent<RoomListItem>();
                if(_roomListItem != null)
                {
                    _roomListItem.Setup(match, JoinRoom);
                }

                // that will take care of setting up the name/amount of players
                // as well as setting up a callback function that will join the game.

                _roomList.Add(_roomListItemGO);
            }

            if(_roomList.Count == 0)
            {
                _status.text = "No rooms available at the moment.";
            }
        }

        // This will call the server to clear the room.
        void ClearRoomList()
        {
            for (var i = 0; i < _roomList.Count; i++)
            {
                Destroy(_roomList[i]);
            }

            _roomList.Clear();
        }

        public void JoinRoom (MatchInfoSnapshot _match)
        {
            Debug.Log("Joining" + _match.name);
            _networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, _networkManager.OnMatchJoined);
            StartCoroutine(WaitForJoin());
        }

        // This is so that the player can't join the same match straight away.
        // The player must wait until refresh.
        IEnumerator WaitForJoin()
        {
            ClearRoomList();
        
            var countdown = 10;
            while (countdown > 0)
            {
                _status.text = "JOINING... (" + countdown + ")";

                yield return new WaitForSeconds(1);
            
                countdown--;
            }
        
            // Failed to connect
            _status.text = "Failed to connect.";
            yield return new WaitForSeconds(1);
        
            var matchInfo = _networkManager.matchInfo;
            if (matchInfo != null)
            {
                // This will drop the clients connection if they leave the room to join another.
                _networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, _networkManager.OnDropConnection);
                // If the host quits the whole game ends.
                _networkManager.StopHost();
            }
        
            RefreshRoomList();
        }

    }
}
