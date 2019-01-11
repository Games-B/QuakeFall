using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _jumpForce;
		[SerializeField] private float _walkSpeed, _runSpeed;
		[SerializeField] private int _maxJumps;

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

			var currentAcceleration = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
			var forwardVector = transform.forward * vertical * currentAcceleration;
			var rightVector = transform.right * horizontal * currentAcceleration;
			var targetPosition = transform.position + forwardVector + rightVector;
			_rigidBody.MovePosition(targetPosition);
			
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
