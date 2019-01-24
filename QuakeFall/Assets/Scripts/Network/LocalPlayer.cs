using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
	public class LocalPlayer : NetworkBehaviour
	{
		// List of the components that will be enabled for the local player.
		[SerializeField] private Behaviour[] _playerComponents;
		private MeshRenderer _playerMesh;

		private void Awake()
		{
			_playerMesh = GetComponent<MeshRenderer>();
		}

		private void Start()
		{
			// Only work for local players.
			if (!isLocalPlayer) return;

			_playerMesh.enabled = false;
			
			// Enable all player components.
			foreach (var component in _playerComponents)
			{
				component.enabled = true;
			}
		}
	}
}