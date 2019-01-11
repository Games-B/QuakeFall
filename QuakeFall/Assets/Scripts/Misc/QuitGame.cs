using UnityEngine;
using UnityEngine.Networking;

namespace Misc
{
	public class QuitGame : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
}
