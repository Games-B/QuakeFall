using UnityEngine;
using UnityEngine.Networking;
using Weapons;

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
		public void CmdShoot(int prefabIndex, Vector3 startPosition, Vector3 targetPoint, float initialForce, GameObject shooter)
		{
			RpcSpawnProjectile(prefabIndex, startPosition, targetPoint, initialForce, shooter);
		}
		
		[ClientRpc]
		public void RpcSpawnProjectile(int prefabIndex, Vector3 startPosition, Vector3 targetPoint, float initialForce, GameObject shooter)
		{
			var newProjectile = Instantiate(_networkManager.spawnPrefabs[prefabIndex], startPosition, Quaternion.identity, null);
			
			newProjectile.GetComponent<Projectile>().SetOwner(shooter);
			
			// Point it towards the target object.
			newProjectile.transform.LookAt(targetPoint);
			newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * initialForce);
			NetworkServer.Spawn(newProjectile);
		}
	}
}
