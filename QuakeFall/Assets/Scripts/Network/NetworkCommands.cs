using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
	public class NetworkCommands : NetworkBehaviour
	{
		private NetworkManager _networkManager;

		private void Awake()
		{
			_networkManager = FindObjectOfType<NetworkManager>();
		}

		[Command]
		public void CmdShoot(int prefabIndex, Vector3 startPosition, Vector3 targetPoint, float initialForce)
		{
			RpcSpawnProjectile(prefabIndex, startPosition, targetPoint, initialForce);
		}
		
		[ClientRpc]
		public void RpcSpawnProjectile(int prefabIndex, Vector3 startPosition, Vector3 targetPoint, float initialForce)
		{
			var newProjectile = Instantiate(_networkManager.spawnPrefabs[prefabIndex], startPosition, Quaternion.identity, null);
			
			// Point it towards the target object.
			newProjectile.transform.LookAt(targetPoint);
			newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * initialForce);
			NetworkServer.Spawn(newProjectile);
		}
	}
}
