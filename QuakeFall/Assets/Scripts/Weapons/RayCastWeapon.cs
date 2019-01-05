using Player;
using UnityEngine;

namespace Weapons
{
	public class RayCastWeapon : Weapon
	{
		protected override bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			if (!base.Shoot(targetCamera, out targetPoint, out hit)) return false;
			if (hit.transform.CompareTag("Player"))
			{
				// Hurt the player.
				hit.transform.GetComponent<PlayerHealth>().Hurt(Damage);
			}

			// Push the object back.
			if (hit.transform.GetComponent<Rigidbody>() != null)
			{
				hit.transform.GetComponent<Rigidbody>().AddForce(-hit.normal * KnockBack);
			}

			return true;
		}
	}
}
