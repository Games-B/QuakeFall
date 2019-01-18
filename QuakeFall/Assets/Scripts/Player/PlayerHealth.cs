using UnityEngine;
using UnityEngine.Networking;

namespace Player
{
	// Make sure the health script is attached to a player.
	[RequireComponent(typeof(PlayerMovement))]
	public class PlayerHealth : NetworkBehaviour
	{
		[SerializeField] private float _respawnTime;
		[SerializeField] private Behaviour[] _componentsToDisable;
		[SerializeField] private bool _isDead;

		private float _timeUntilReSpawn;
		
		[SerializeField, Range(1, 1000)] private int _maxHealth;
		[SerializeField] private int _currentHealth;

		[SerializeField, Range(0, 1000)] private int _maxShield;
		[SerializeField] private int _currentShield;

		private void Update()
		{
			if (!_isDead) return;
			if (_timeUntilReSpawn <= 0)
			{
				ReSpawn();
				return;
			}
			_timeUntilReSpawn = Mathf.Clamp(_timeUntilReSpawn -= Time.deltaTime, 0, _respawnTime);
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
			_timeUntilReSpawn = _respawnTime;
			_isDead = true;
			foreach (var behaviour in _componentsToDisable)
			{
				behaviour.enabled = false;
			}
		}

		private void ReSpawn()
		{
			print("U brains PhAm!");
			Heal(_maxHealth);
			_isDead = false;
			var positionArray = NetworkManager.singleton.startPositions;
			var randomIndex = Random.Range(0, positionArray.Count);
			transform.position = positionArray[randomIndex].position;
			foreach (var behaviour in _componentsToDisable)
			{
				behaviour.enabled = true;
			}
		}
	}
}
