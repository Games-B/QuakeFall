using UnityEngine;

namespace Player
{
	public class TransformAlign : MonoBehaviour
	{
		[SerializeField] private Transform _target;

		private void Update()
		{
			var targetRotation = Vector3.up * _target.eulerAngles.y;

			transform.eulerAngles = targetRotation;
		}
	}
}
