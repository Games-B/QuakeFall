using UnityEngine;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		// Weapon name and image of weapon.
		[SerializeField] protected string Name;
		[SerializeField] protected Sprite Icon;
		[SerializeField] protected bool Enabled;
		[SerializeField] protected GameObject Model;
	
		// Weapons stats.
		[Space, SerializeField] protected int Damage;
		[SerializeField] protected float KnockBack;
		[SerializeField] protected float Range;
		[SerializeField] protected int Ammo;
		[SerializeField] protected float FireRate;
		[SerializeField] protected Transform GunEnd;

		private float _timeSinceShot;

		// Getters and Setters.
		public void SetEnabled(bool isEnabled)
		{
			Enabled = isEnabled;
		}
		
		// Other methods.
		private Vector3 GetShotPoint(Transform targetCamera)
		{
			return Vector3.zero;
		}

		protected bool Shoot(Transform targetCamera)
		{
			if (_timeSinceShot < FireRate) return false;

			_timeSinceShot = 0;
			var targetPoint = GetShotPoint(targetCamera);
			SpawnBullet(targetPoint);
			return true;
		}

		// Base bullet spawning, will be changed to either ray cast or projectile.
		protected virtual void SpawnBullet(Vector3 targetPoint) {}
	}
}
