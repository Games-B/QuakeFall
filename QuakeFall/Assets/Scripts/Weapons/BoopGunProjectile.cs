using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{

	public class BoopGunProjectile : MonoBehaviour
	{
		
		
		[SerializeField] private int _knockBack;
		[SerializeField] private float _range;
		[SerializeField] private float _knockBackRange;
		[SerializeField] private Rigidbody[] _rigidBodies;
		[SerializeField] private GameObject Ball;
		
		[SerializeField] private UnityEngine.Camera _fpsCam;

		private void Start()
		{
			_rigidBodies = FindObjectsOfType<Rigidbody>();
		}
		
		// Unity Methods.
		private void Update () 
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Shoot(Ball);
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			foreach (var rigidBody in _rigidBodies)
			{
				other.contacts.Length.Equals(other);
				rigidBody.AddExplosionForce(_knockBack, transform.position, _knockBackRange);
			}
		}
		
		// Custom Methods.
		private void Shoot(GameObject ball)
		{
			RaycastHit hit;
			if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
			{
				Debug.Log(hit.transform.name);
			}
		}
		
	}
}
