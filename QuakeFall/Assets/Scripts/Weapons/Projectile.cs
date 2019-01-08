using Player;
using UnityEngine;

namespace Weapons
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private int _damage;
		[SerializeField] private float _explosionRange;
		[SerializeField] private float _explosionForce;

		private void OnCollisionEnter()
		{
			// Get all the objects in the range of the explosion.
			var colliderArray = Physics.OverlapSphere(transform.position, _explosionRange, 0);
			
			// Go through all the objects.
			foreach (var coll in colliderArray)
			{
				// Hurt the object if it's a player.
				if (coll.CompareTag("Player"))
				{
					coll.GetComponent<PlayerHealth>().Hurt(_damage);
				}
				
				// Push the object back if it has a rigid body.
				if (coll.GetComponent<Rigidbody>() != null)
				{
					coll.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRange);
				}
			}
		}
	}
}