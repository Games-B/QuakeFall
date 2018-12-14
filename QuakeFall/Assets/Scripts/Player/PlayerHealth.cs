using UnityEngine;

namespace Player
{
	// Make sure the health script is attached to a player.
	[RequireComponent(typeof(PlayerMovement))]
	public class PlayerHealth : MonoBehaviour
	{
		[SerializeField, Range(1, 1000)] private int _maxHealth;
		[SerializeField] private int _currentHealth;

		[SerializeField, Range(0, 1000)] private int _maxShield;
		[SerializeField] private int _currentShield;

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
	}
}
