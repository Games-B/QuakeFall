using UnityEngine;
using UnityEngine.Networking;

namespace Misc
{
	public class QuitGame : NetworkBehaviour
	{
		private void Update()
		{
			if(!isLocalPlayer) return;

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
}
