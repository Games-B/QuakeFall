using System.Collections.Generic;
using Network;
using UnityEngine;
using UnityEngine.Rendering;

namespace Weapons
{
	public class Arsenal : MonoBehaviour
	{
		[SerializeField] private int activeWeapon = 1;
		[SerializeField] private int previousWeapon; 
		[SerializeField] private List<Weapon> inventory = new List<Weapon>(5);
		[SerializeField] private bool swapToPickup;

		enum WeaponType
		{
			Pistol, Rifle, Boopgun, Sniper, Shotgun 
		}

		// Getters and setters.
		public Weapon[] GetInventory()
		{
			return inventory.ToArray();
		}
		public int GetActiveWeapon()
		{
			return activeWeapon;
		}
		
		public bool SwitchWeapons(int targetIndex)
		{
			// Loop the target if it's out of bounds.
			if (targetIndex >= inventory.Count) targetIndex = 0;
			else if (targetIndex < 0) targetIndex = inventory.Count - 1;
			
			// Only switch if the target weapon is enabled, and the weapon is not the same as the current one.
			if (!inventory[targetIndex].gameObject.activeSelf || activeWeapon == targetIndex) return false;
			
			// Update the previous weapon.
			previousWeapon = activeWeapon;
			// Switch to the target weapon.
			activeWeapon = targetIndex;
			
			HideAllWeapons();
			inventory[activeWeapon].gameObject.SetActive(true);

			return true;
		}
		
		public void AddAmmo(int weaponIndex, int ammoCount)
		{
			inventory[weaponIndex].GetComponent<Weapon>().AddAmmo(ammoCount);
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

		public void RemoveWeapon(int targetIndex)
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
