using UnityEngine;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		[Header("Weapon"), SerializeField] protected string Name;
		[SerializeField] protected Sprite Icon;
		[SerializeField] protected bool Enabled;
		[SerializeField] protected GameObject Model;
		[SerializeField] protected int Damage;
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
		private Vector3 GetShotPoint(UnityEngine.Camera targetCamera)
		{
			var rayOrigin = targetCamera.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));
			RaycastHit hit;
			// Check if the bullet hits anything.
			if (Physics.Raycast(rayOrigin, targetCamera.transform.forward, out hit, Range))
			{
				// Check if you hit another player.
				if (hit.transform.CompareTag("Player"))
				{
					// Hurt the player.
				}
			}
			return Vector3.zero;
		}

		protected bool Shoot(UnityEngine.Camera targetCamera)
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
