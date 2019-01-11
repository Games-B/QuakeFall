using Player;
using UnityEngine;

namespace Weapons
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private int _damage;
		[SerializeField] private float _explosionRange;
		[SerializeField] private float _explosionForce;
		[SerializeField] private float _lifespan;
		[SerializeField] private Transform _parent;

		public void SetParent(Transform newParent)
		{
			_parent = newParent;
		}
		
		private float _currentLifespan;

		private void Update()
		{
			_currentLifespan = Mathf.Clamp(_currentLifespan + Time.deltaTime, 0, _lifespan);

			if (_currentLifespan >= _lifespan)
			{
				Destroy(gameObject);
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			// Don't collide with the player.
			if (other.transform == _parent) return;
			
			// Get all the objects in the range of the explosion.
			var colliderArray = Physics.OverlapSphere(transform.position, _explosionRange);
			
			// Go through all the objects.
			foreach (var coll in colliderArray)
			{
				print(coll);
				// Hurt the object if it's a player.
				if (coll.CompareTag("Player"))
				{
					coll.GetComponent<PlayerHealth>().Hurt(_damage);
					coll.GetComponent<Rigidbody>().AddForce((coll.transform.position - transform.position).normalized * _explosionForce);
				}
				
				// Push the object back if it has a rigid body.
				else if (coll.GetComponent<Rigidbody>() != null)
				{
					coll.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRange);
				}
			}
			
			Destroy(gameObject);
		}
	}
}