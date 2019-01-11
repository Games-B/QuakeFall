using UnityEngine;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		[Header("Weapon"), SerializeField] protected string Name;
		[SerializeField] protected Sprite Icon;
		[SerializeField] protected float Range;
		[SerializeField] protected int Ammo;
		[SerializeField] protected float FireRate;
		[SerializeField] protected Transform GunEnd;
		private float _timeSinceShot;
		
		// Custom methods.
		public virtual bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			// Don't shoot if enough time has not passed or you don't have enough ammo or you don't have the weapon.
			if (_timeSinceShot < FireRate || Ammo < 1)
			{
				// Print error message.
				if (_timeSinceShot < FireRate)
					print(string.Format("<color=red>Need to wait {0} before shooting!</color>",
						FireRate - _timeSinceShot));
				if (Ammo < 1) print("<color=red>No ammo to shoot with!</color>");
				
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

		private void Update()
		{
			_timeSinceShot = Mathf.Clamp(_timeSinceShot + Time.deltaTime, 0, FireRate);
		}
	}
}
