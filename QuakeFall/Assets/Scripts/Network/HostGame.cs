using UnityEngine;
using UnityEngine.Networking;


public class HostGame : MonoBehaviour
{
	[SerializeField] private uint _roomSize = 16;

	[SerializeField] private string _roomName;

	[SerializeField] private NetworkManager _networkManager;

	private void Start()
	{
		_networkManager = NetworkManager.singleton;
		if (_networkManager.matchMaker == null)
		{
			_networkManager.StartMatchMaker();
		}
	}

	public void SetRoomName(string _name)
	{
		_roomName = _name;
	}

	public void CreateRoom()
	{
		if (_roomName != "" && _roomName != null)
		{
			Debug.Log("Creating Room: " + _roomName + " with room for " + _roomSize + " players.");
			_networkManager.matchMaker.CreateMatch(_roomName, _roomSize, true, "","","",0,0, _networkManager.OnMatchCreate);
		}
	}
}
