using UnityEngine;

namespace Misc
{
	public class MovingPlatform : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			// When an object enters the platform trigger, it gets parented meaning it will move with the platform.
			other.transform.parent = transform;
		}

		private void OnTriggerExit(Collider other)
		{
			// When the object leaves the trigger, it loses the parent to make it move independently.
			other.transform.parent = null;
		}
	}
}
