using UnityEngine;
using UnityEngine.Networking;

namespace Weapons
{
	public class ProjectileWeapon : Weapon
	{
		[Header("Projectile Weapon"), SerializeField] private GameObject _projectilePrefab;
		[SerializeField] private float _initialForce;

		[Command]
		public void CmdSpawn(GameObject item)
		{
			NetworkServer.Spawn(item);
		}
		
		public override bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			if (!base.Shoot(targetCamera, out targetPoint, out hit)) return false;
			
			var newProjectile = Instantiate(_projectilePrefab, GunEnd.position, Quaternion.identity, null);
			
			// Point it towards the target object.
			newProjectile.transform.LookAt(targetPoint);
			newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * _initialForce);
			CmdSpawn(newProjectile);
			return true;
		}
	}
}
