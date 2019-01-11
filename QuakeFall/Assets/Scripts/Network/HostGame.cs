using UnityEngine;
using UnityEngine.Networking;


public class HostGame : MonoBehaviour
{
	[SerializeField] private uint _roomSize = 16;

	[SerializeField] private string _roomname;

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
		_roomname = _name;
	}

	public void CreateRoom()
	{
		if (_roomname != "" && _roomname != null)
		{
			Debug.Log("Creating Room: " + _roomname + " with room for " + _roomSize + " players.");
			_networkManager.matchMaker.CreateMatch(_roomname, _roomSize, true, "", _networkManager.OnMatchCreate);
		}
	}
}
