using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
	public class Arsenal : MonoBehaviour
	{
		[SerializeField] private int activeWeapon;
		[SerializeField] private int previousWeapon; 
		[SerializeField] private List<Weapon> inventory = new List<Weapon>(5);
		[SerializeField] private bool swapToPickup;

		enum WeaponType
		{
			Pistol, Rifle, Boopgun, Sniper, Shotgun 
		}

		// Getters and setters.
		public Weapon GetActiveWeapon()
		{
			return inventory[activeWeapon];
		}

		// Unity methods.
		private void Start()
		{
			SetupWeapons();
		}

		private void SetupWeapons()
		{
			// Remove all weapons apart from the first one.
			for (var i = 1; i < inventory.Count - 1; i++)
			{
				RemoveWeapon(i);
			}
			
			// Switch to the first weapon.
			inventory[0].enabled = true;
			SwitchWeapons(0);
		}

		private bool SwitchWeapons(int targetIndex)
		{
			// Only switch if the target weapon is enabled, and the weapon is not the same as the current one.
			if (!inventory[targetIndex].enabled || activeWeapon == targetIndex) return false;
			
			// Update the previous weapon.
			previousWeapon = activeWeapon;
			// Switch to the target weapon.
			activeWeapon = targetIndex;
			
			HideAllWeapons();
			inventory[activeWeapon].gameObject.SetActive(true);

			return true;
		}

		public void AddWeapon(int targetIndex)
		{
			// Enable the target weapon.
			inventory[targetIndex].GetComponent<Weapon>().enabled = true;

			// Swap to the newly added weapon if the setting is enabled.
			if (swapToPickup)
			{
				SwitchWeapons(targetIndex);
			}
		}

		private void RemoveWeapon(int targetIndex)
		{
			// Swap to the previous weapon if the current one is being removed.
			if (targetIndex == activeWeapon)
			{
				SwitchWeapons(previousWeapon);
			}
			
			// Remove the target weapon.
			inventory[targetIndex].enabled = false;
		}

		private void HideAllWeapons()
		{
			foreach (var weapon in inventory)
			{
				weapon.gameObject.SetActive(false);
			}
		}
	}
}
