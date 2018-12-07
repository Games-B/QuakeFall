using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _jumpForce;
		[SerializeField] private float _acceleration;
		[SerializeField] private float _maxHorizontalVelocity;

		[SerializeField] private int _maxJumps;

		[SerializeField] private Transform _camera;

		private Rigidbody _rigidBody;
		private int _currentJumps;

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody>();
		}

		private void Start()
		{
			// Stop the player jumping at the start until he touches the floor.
			_currentJumps = _maxJumps;
		}

		private void FixedUpdate()
		{
			// Get input from the player.
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");
			
			// Check if the can move.
			if (Mathf.Abs(_rigidBody.velocity.x) + Mathf.Abs(_rigidBody.velocity.z) < _maxHorizontalVelocity)
			{
				var horizontalVelocity = _camera.right * horizontal;
				var verticalVelocity = _camera.forward * vertical;

				var newForce = (horizontalVelocity + verticalVelocity) * _acceleration;
				_rigidBody.AddForce(newForce);
			}

			// Check if the player can jump.
			if (_currentJumps < _maxJumps && Input.GetKeyDown(KeyCode.Space))
			{
				_currentJumps++;

				// Reset the current vertical velocity.
				_rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0, _rigidBody.velocity.z);
				
				var newForce = transform.up * _jumpForce;
				_rigidBody.AddForce(newForce);
			}
		}

		private void OnCollisionEnter()
		{
			_currentJumps = 0;
		}
	}
}
