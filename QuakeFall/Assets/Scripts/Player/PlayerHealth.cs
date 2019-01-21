using UnityEngine;
using UnityEngine.Networking;

namespace Player
{
	// Make sure the health script is attached to a player.
	[RequireComponent(typeof(PlayerMovement))]
	public class PlayerHealth : NetworkBehaviour
	{
		[SerializeField] private float respawnTime;
		[SerializeField] private bool isDead;

		private float _timeUntilReSpawn;
		
		[SerializeField, Range(1, 1000)] private int maxHealth;
		[SerializeField] private int currentHealth;

		[SerializeField, Range(0, 1000)] private int maxShield;
		[SerializeField] private int currentShield;
		
		[Header("Components To Disable"), SerializeField] private Behaviour[] componentArray;
		[SerializeField] private MeshRenderer meshRenderer;
		[SerializeField] private CapsuleCollider capsuleCollider;
		[SerializeField] private GameObject weapons;
		

		private void Update()
		{
			if (!isDead) return;
			if (_timeUntilReSpawn <= 0)
			{
				ReSpawn();
				return;
			}
			_timeUntilReSpawn = Mathf.Clamp(_timeUntilReSpawn -= Time.deltaTime, 0, respawnTime);
		}

		// Heals the player's health.
		private void Heal(int amount)
		{
			// Work out the amount to heal, and clamp it to prevent over healing.
			var amountToHeal = Mathf.Clamp(amount, 0, maxHealth - currentHealth);
			currentHealth += amountToHeal;
		}

		private void Shield(int amount)
		{
			// Work out the amount to heal, and clamp it to prevent over healing.
			var amountToShield = Mathf.Clamp(amount, 0, maxShield - currentShield);
			currentShield  += amountToShield;
		}

		private void HurtHealth(int amount)
		{
			var amountToHurt = Mathf.Clamp(amount, 0, currentHealth);
			currentHealth -= amountToHurt;
			
			// Check if the player should die.
			if (currentHealth <= 0)
			{
				Die();
			}
		}

		private int HurtShield(int amount)
		{
			var amountToHurt = Mathf.Clamp(amount, 0, currentShield);
			currentShield -= amountToHurt;
			
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

		public void Die()
		{
			// Stuff that happens when you die.
			if (isDead) return;
			_timeUntilReSpawn = respawnTime;
			isDead = true;
			// Disable all the components.
			meshRenderer.enabled = false;
			capsuleCollider.enabled = false;
			weapons.SetActive(false);
			foreach (var behaviour in componentArray)
			{
				behaviour.enabled = false;
			}
		}

		private void ReSpawn()
		{
			print("U brains PhAm!");
			Heal(maxHealth);
			isDead = false;
			var positionArray = NetworkManager.singleton.startPositions;
			var randomIndex = Random.Range(0, positionArray.Count);
			transform.position = positionArray[randomIndex].position;
			// Enable all the components.
			meshRenderer.enabled = true;
			capsuleCollider.enabled = true;
			weapons.SetActive(true);
			foreach (var behaviour in componentArray)
			{
				behaviour.enabled = true;
			}
		}
	}
}
