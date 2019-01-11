using UnityEngine;

namespace Player
{
	public class TransformAlign : MonoBehaviour
	{
		[SerializeField] private bool _x, _y, _z;
		[SerializeField] private Transform _target;

		private void Update()
		{
			var xRotation = Vector3.right * _target.eulerAngles.x * (_x ? 1 : 0);
			var yRotation = Vector3.up * _target.eulerAngles.y * (_y ? 1 : 0);
			var zRotation = Vector3.forward * _target.eulerAngles.z * (_z ? 1 : 0);
			var targetRotation = xRotation + yRotation + zRotation;

			transform.eulerAngles = targetRotation;
		}
	}
}
