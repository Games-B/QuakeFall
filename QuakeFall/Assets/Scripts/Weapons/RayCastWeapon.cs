using Player;
using UnityEngine;

namespace Weapons
{
	public class RayCastWeapon : Weapon
	{
		[Header("RayCast Weapon"), SerializeField] private int damage;
		[SerializeField] private float knockBack;
		[SerializeField] private int lineIndex;
		
		public override bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			if (!base.Shoot(targetCamera, out targetPoint, out hit)) return false;

			if (hit.transform == null) return false;
			if (hit.transform.CompareTag("Player"))
			{
				// Hurt the player.
				hit.transform.GetComponent<PlayerHealth>().Hurt(damage);
			}

			// Push the object back if it has a rigid body.
			if (hit.transform.GetComponent<Rigidbody>() != null)
			{
				hit.transform.GetComponent<Rigidbody>().AddForce(targetCamera.transform.forward * knockBack);
			}

			return true;
		}
	}
}
