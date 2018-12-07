using System.Collections;
using UnityEngine;

namespace Player
{
	public class PlayerWallRun : MonoBehaviour
	{
	
		private bool _isWallR; // Reference for right wall
		private bool _isWallL; // Reference for left wall
		private RaycastHit _hitR; // Reference for hitting right wall
		private RaycastHit _hitL; // Reference for hitting left wall

		private Rigidbody _rb; // Reference to RigidBody
		private PlayerMovement _playerMovement; // Reference for PlayerMovement Script.
		[SerializeField] private float _runTime = 10f;

		private float _currentTime;
	
		// This will get the RigidBody of the player and the PlayerMovement when the player spawns in so that they can WallRun.
		void Start ()
		{
			_rb = GetComponent<Rigidbody>();
			_playerMovement = GetComponent<PlayerMovement>();
		}
	
		// This allows the player to WallRun on a wall that is on the right and use any remaining jumps to get somewhere. 
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.E) && _playerMovement.GetJumpCount() <= 1)
			{
				// Uses Raycast so that if the player is aiming at the wall it will allow WallRun to happen
				if (Physics.Raycast(transform.position, transform.right, out _hitR, 1))
				{
					if (_hitR.transform.CompareTag("Wall"))
					{
						_isWallR = true;
						_isWallL = false;
						_rb.useGravity = false;
						_currentTime = 0;
					}
				}
			}
			// This allows the player to WallRun on a wall that is on the left and use any remaining jumps to get somewhere.
			// Uses Raycast so that if the player is aiming at the wall it will allow WallRun to happen
			if (Physics.Raycast(transform.position, transform.right, out _hitL, 1))
			{
				if (_hitL.transform.CompareTag("Wall"))
				{
					_isWallL = true;
					_isWallR = false;
					_rb.useGravity = false;
					_currentTime = 0;
				}
			}

			if (_currentTime <= _runTime)
			{
				_isWallL = false;
				_isWallR = false;
				_rb.useGravity = true;
			}

			_currentTime = Mathf.Clamp(_currentTime + Time.deltaTime, 0, _runTime);
		}
	}
}

