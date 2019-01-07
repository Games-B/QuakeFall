using Player;
using UnityEngine;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		[Header("Weapon"), SerializeField] protected string Name;
		[SerializeField] protected Vector2 Recoil;
		[SerializeField] protected Sprite Icon;
		[SerializeField] protected bool Enabled;
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

		protected virtual bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			// Don't shoot if enough time has not passed or you don't have enough ammo or you don't have the weapon.
			if (_timeSinceShot < FireRate || Ammo < 1 || !Enabled)
			{
				targetPoint = Vector3.zero;
				hit = new RaycastHit();
				return false;
			}
			_timeSinceShot = 0;
			Ammo--;
			
			// Set the start of the ray cast to the center of the camera, to make sure it points to the cross hair.
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
	}xx
}
