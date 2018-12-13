using UnityEngine;

namespace Misc
{
	public class CursorLock : MonoBehaviour
	{
		private void Awake()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
