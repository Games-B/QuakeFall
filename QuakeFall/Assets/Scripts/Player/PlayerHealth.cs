using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Player
{
	// Make sure the health script is attached to a player.
	[RequireComponent(typeof(PlayerMovement))]
	public class PlayerHealth : NetworkBehaviour
	{
		[SerializeField] private Behaviour[] _componentsToDisableOnDeath;
		[SerializeField, Range(1, 1000)] private int _maxHealth;
		[SerializeField] private int _currentHealth;

		[SerializeField, Range(0, 1000)] private int _maxShield;
		[SerializeField] private int _currentShield;

		[SerializeField] private float _reSpawnTime;
		private float _currentTime;
		private bool _isDead;

		private void Update()
		{
			if (_isDead)
			{
				_currentTime = Mathf.Clamp(_currentTime + Time.deltaTime, 0, _reSpawnTime);
				if (_currentTime >= _reSpawnTime)
				{
					ReSpawn();
				}
			}
		}

		// Heals the player's health.
		private void Heal(int amount)
		{
			// Work out the amount to heal, and clamp it to prevent over healing.
			var amountToHeal = Mathf.Clamp(amount, 0, _currentHealth - _maxHealth);
			_currentHealth += amountToHeal;
		}

		private void Shield(int amount)
		{
			// Work out the amount to heal, and clamp it to prevent over healing.
			var amountToShield = Mathf.Clamp(amount, 0, _maxShield - _currentShield);
			_currentShield  += amountToShield;
		}

		private void HurtHealth(int amount)
		{
			var amountToHurt = Mathf.Clamp(amount, 0, _currentHealth);
			_currentHealth -= amountToHurt;
			
			// Check if the player should die.    
			if (_currentHealth <= 0)
			{
				Die();
			}
		}

		private int HurtShield(int amount)
		{
			var amountToHurt = Mathf.Clamp(amount, 0, _currentShield);
			_currentShield -= amountToHurt;
			
			// Return the amount of damage left.
			return amount - amountToHurt;
		}

		public void Hurt(int amount)
		{
			// First try to hurt the shield.
			var damageLeft = HurtShield(amount);
			// Then hurt the health.
			HurtHealth(damageLeft);
		}

		private void Die()
		{
			// Stuff that happens when you die.
			print("U dEd PhAm!");
			_isDead = true;
			foreach (var behaviour in _componentsToDisableOnDeath)
			{
				behaviour.enabled = false;
			}
		}

		private void ReSpawn()
		{
			_isDead = false;
			
			foreach (var behaviour in _componentsToDisableOnDeath)
			{
				behaviour.enabled = true;
			}
			
			var spawnPoint = NetworkManager.singleton.GetStartPosition();
			transform.position = spawnPoint.position;
			transform.rotation = spawnPoint.rotation;
		}
	}
}
