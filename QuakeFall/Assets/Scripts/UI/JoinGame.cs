using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI
{
	public class JoinGame : MonoBehaviour
	{
		[SerializeField] private NetworkManager _networkManager;
		[SerializeField] private string _ipAddress = "192.168.0.1";
		[SerializeField] private int _port = 7777;
		
		public void UpdateIpAddress(InputField target)
		{
			_ipAddress = target.text;
		}
		
		public void UpdatePort(InputField target)
		{
			_port = int.Parse(target.text);
		}
		
		public void Join()
		{
			_networkManager.networkAddress = _ipAddress;
			_networkManager.networkPort = _port;
			_networkManager.StartClient();
		}
	}
}
