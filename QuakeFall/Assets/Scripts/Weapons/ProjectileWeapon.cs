using UnityEngine;

namespace Weapons
{
	public class ProjectileWeapon : Weapon
	{
		[Header("Projectile Weapon"), SerializeField] private GameObject _projectilePrefab;
		[SerializeField] private float _initialForce;

		protected override void SpawnBullet(Vector3 targetPoint)
		{
			// Spawn the new projectile.
			var newProjectile = Instantiate(_projectilePrefab, GunEnd.position, Quaternion.identity, null);
			
			// Point it towards the target object.
			newProjectile.transform.LookAt(targetPoint);
			newProjectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * _initialForce);
		}
	}
}
