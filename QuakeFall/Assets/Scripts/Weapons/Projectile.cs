using Player;
using UnityEngine;

namespace Weapons
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private int _damage;
		[SerializeField] private float _explosionRange;
		[SerializeField] private float _explosionForce, _upwardsForce;
		[SerializeField] private float _lifespan;

		private GameObject _owner;
		private float _currentLifespan;

		public void SetOwner(GameObject newOwner)
		{
			_owner = newOwner;
		}
		
		private void Update()
		{
			_currentLifespan = Mathf.Clamp(_currentLifespan + Time.deltaTime, 0, _lifespan);

			if (_currentLifespan >= _lifespan)
			{
				Destroy(gameObject);
			}
		}

		private void OnCollisionEnter()
		{
			// Get all the objects in the range of the explosion.
			var colliderArray = Physics.OverlapSphere(transform.position, _explosionRange);
			
			// Go through all the objects.
			foreach (var coll in colliderArray)
			{
				
				// Hurt the object if it's a player.
				if (coll.CompareTag("Player"))
				{
					coll.GetComponent<Rigidbody>().AddForce((coll.transform.position - transform.position).normalized * _explosionForce + Vector3.up * _upwardsForce);
					coll.GetComponent<PlayerHealth>().Hurt(_damage);
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