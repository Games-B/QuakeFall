using UnityEngine;
using UnityEngine.Networking;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		[Header("Weapon"), SerializeField] protected string weaponName;
		[SerializeField] protected Sprite icon;
		[SerializeField] protected float range;
		[SerializeField] protected int ammo;
		[SerializeField] protected float fireRate;
		[SerializeField] protected Transform gunEnd;
		private float _timeSinceShot;

		public int GetAmmo()
		{
			return ammo;
		}
		
		public void AddAmmo(int ammoToAdd)
		{
			ammo += ammoToAdd;
		}
		
		// Custom methods.
		public virtual bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			// Don't shoot if enough time has not passed or you don't have enough ammo or you don't have the weapon.
			if (_timeSinceShot < fireRate || ammo < 1)
			{
				targetPoint = Vector3.zero;
				hit = new RaycastHit();
				return false;
			}
			_timeSinceShot = 0;
			ammo--;
			
			// Set the start of the ray cast to the center of the camera, to make sure it points to the cross hair.
			var rayOrigin = targetCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
			// Check if the ray cast hits anything.
			if (Physics.Raycast(rayOrigin, targetCamera.transform.forward, out hit, range))
			{
				targetPoint = hit.point;
			}
			else
			{
				var cameraTransform = targetCamera.transform;
				targetPoint = cameraTransform.position + cameraTransform.forward * range;
			}
			return true;
		}

		private void Update()
		{
			_timeSinceShot = Mathf.Clamp(_timeSinceShot + Time.deltaTime, 0, fireRate);
		}
	}
}
