using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Network
{
	[RequireComponent(typeof(Text))]
	public class IpDisplay : MonoBehaviour
	{
		private Text _text;
		
		private void Awake()
		{
			_text = GetComponent<Text>();
			var localIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
			_text.text = localIp;
		}
	}
}
