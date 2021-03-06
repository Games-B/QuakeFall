﻿using UnityEngine;

namespace Weapons
{
	public class BoopGunProjectile : MonoBehaviour
	{
		
		[SerializeField] private int _knockBack;
		[SerializeField] private float _knockBackRange;
		[SerializeField] private Rigidbody[] _rigidBodies;
		
		private void Start()
		{
			_rigidBodies = FindObjectsOfType<Rigidbody>();
		}
		
		private void OnCollisionEnter(Collision other)
		{
			foreach (var rigidBody in _rigidBodies)
			{
				rigidBody.AddExplosionForce(_knockBack, transform.position, _knockBackRange);
			}
		}
	}
}
