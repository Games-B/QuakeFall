using Player;
using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
	public class LocalPlayer : NetworkBehaviour
	{
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private UnityEngine.Camera _camera;
		[SerializeField] private PlayerCamera _playerCamera;
		
		private void Start()
		{
			// Only work for local players.
			if (!isLocalPlayer) return;
			// 
			_playerMovement.enabled = true;
			_camera.enabled = true;
			_playerCamera.enabled = true;
		}
	}
}
