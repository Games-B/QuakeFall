using Player;
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

		protected float TimeSinceShot;

		// Getters and Setters.
		public void SetEnabled(bool isEnabled)
		{
			Enabled = isEnabled;
		}

		protected virtual bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			// Set up the out parameters.
			targetPoint = Vector3.zero;
			hit = new RaycastHit();
			
			// Don't shoot if enough time has not passed.
			if (!(TimeSinceShot >= FireRate)) return false;
			TimeSinceShot = 0;
			
			var rayOrigin = targetCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
			// Check if the ray cast hits anything.
			if (Physics.Raycast(rayOrigin, targetCamera.transform.forward, out hit, Range))
			{
				targetPoint = hit.point;
			}
			else
			{
				targetPoint = targetCamera.transform.forward * Range;
			}
			return true;
		}
	}
}
