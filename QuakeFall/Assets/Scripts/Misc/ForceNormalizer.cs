using UnityEngine;

namespace Misc
{
	[RequireComponent(typeof(Rigidbody))]
	public class ForceNormalizer : MonoBehaviour
	{
		[SerializeField, Range(0, 1)] private float _forceSpeed, _torqueSpeed = .1f;
		
		private Rigidbody _rigidBody;

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			_rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, Vector3.up * _rigidBody.velocity.y, _forceSpeed);
			_rigidBody.angularVelocity = Vector3.Lerp(_rigidBody.angularVelocity, Vector3.zero, _torqueSpeed);
		}
	}
}
