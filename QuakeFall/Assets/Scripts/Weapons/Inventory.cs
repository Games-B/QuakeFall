using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private int _activeWeapon;
		[SerializeField] private int _previousWeapon; 
		[SerializeField] private List<Weapon> _inventory = new List<Weapon>(5);
		[SerializeField] private bool _swapToPickup;

		enum WeaponType
		{
			Pistol, Rifle, Boopgun, Sniper, Shotgun 
		}

		private void Start()
		{
			SetupWeapons();
		}

		private void SetupWeapons()
		{
			// Remove all weapons apart from the first one.
			for (var i = 1; i < _inventory.Count - 1; i++)
			{
				RemoveWeapon(i);
			}
			
			// Switch to the first weapon.
			SwitchWeapons(0);
		}

		public bool SwitchWeapons(int targetIndex)
		{
			// Only switch if the target weapon is enabled, and the weapon is not the same as the current one.
			if (!_inventory[targetIndex].IsEnabled() || _activeWeapon == targetIndex) return false;
			
			// Update the previous weapon.
			_previousWeapon = _activeWeapon;
			// Switch to the target weapon.
			_activeWeapon = targetIndex;

			return true;
		}

		public void AddWeapon(int targetIndex)
		{
			// Enable the target weapon.
			_inventory[targetIndex].GetComponent<Weapon>().SetEnabled(true);

			// Swap to the newly added weapon if the setting is enabled.
			if (_swapToPickup)
			{
				SwitchWeapons(targetIndex);
			}
		}

		public void RemoveWeapon(int targetIndex)
		{
			// Swap to the previous weapon if the current one is being removed.
			if (targetIndex == _activeWeapon)
			{
				SwitchWeapons(_previousWeapon);
			}
			
			// Remove the target weapon.
			_inventory[targetIndex].SetEnabled(false);
		}
	}
}
