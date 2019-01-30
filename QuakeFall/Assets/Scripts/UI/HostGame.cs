using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI
{
	public class HostGame : MonoBehaviour
	{
		[SerializeField] private int _port = 7777;
		private NetworkManager _networkManager;

		private void Awake()
		{
			_networkManager = FindObjectOfType<NetworkManager>();
		}

		public void UpdatePort(InputField target)
		{
			_port = int.Parse(target.text);
		}

		public void Host()
		{
			_networkManager.matchPort = _port;
			_networkManager.StartHost();
		}
	}
}
