using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI
{
	public class HostGame : MonoBehaviour
	{
		[SerializeField] private NetworkManager _networkManager;
		[SerializeField] private int _port = 7777;

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
