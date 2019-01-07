using UnityEngine;
using UnityEngine.Networking;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : NetworkBehaviour
	{
		[SerializeField] private float _jumpForce;
		[SerializeField] private float _acceleration;
		[SerializeField] private float _maxHorizontalVelocity;
		[SerializeField] private int _maxJumps;
		[SerializeField, Range(0, 1)] private float _stopSpeed = .5f;

		[SerializeField] private Transform _camera;

		private Rigidbody _rigidBody;
		private int _jumpCount;

		public void ChangeJumpCount(int amount)
		{
			_jumpCount += amount;
		}
		
		public int GetJumpCount()
		{
			return _jumpCount;
		}
		
		// Unity Methods.
		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody>();
		}

		private void Start()
		{
			// Stop the player jumping at the start until he touches the floor.
			_jumpCount = _maxJumps;
		}
		
		private void FixedUpdate()
		{
			// Get input from the player.
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");

			// Check if the can move.
			var totalInput = Mathf.Abs(_rigidBody.velocity.x) + Mathf.Abs(_rigidBody.velocity.z);
			if (totalInput < _maxHorizontalVelocity)
			{
				var horizontalVelocity = _camera.right * horizontal;

				// Ignore the y axis when moving forward, as it can make the player fly up.
				var forwardVector = new Vector3(_camera.forward.x, 0, _camera.forward.z).normalized;
				var verticalVelocity = forwardVector * vertical;

				var newForce = (horizontalVelocity + verticalVelocity) * _acceleration;
				_rigidBody.AddForce(newForce);
			}
			// Stop the player if he isn't moving.
			else if (totalInput <= 0)
			{
				// Stop the horizontal velocities, without affecting the vertical velocity.
				var stopVector = Vector3.up * _rigidBody.velocity.y;

				// Smoothly slow down the player.
				_rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, stopVector, _stopSpeed);
			}

			// Check if the player can jump.
			if (_jumpCount < _maxJumps && Input.GetKeyDown(KeyCode.Space))
			{
				_jumpCount++;

				// Reset the current vertical velocity.
				_rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0, _rigidBody.velocity.z);

				var newForce = Vector3.up * _jumpForce;
				_rigidBody.AddForce(newForce);
			}
		}

		private void OnCollisionEnter()
		{
			_jumpCount = 0;
		}
	}
}
