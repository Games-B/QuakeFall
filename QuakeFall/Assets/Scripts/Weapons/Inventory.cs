using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private GameObject _activeWeapon;
		[SerializeField] private GameObject _previousWeapon; 
		[SerializeField] private List<GameObject> _inventory = new List<GameObject>(5);
		[SerializeField] private bool _swapToPickup;

		// Weapons.
		enum WeaponType
		{
			Pistol, Rifle, Boopgun, Sniper, Shotgun 
		}

		// When game starts, run function SetupWeapons.
		private void Start()
		{
			SetupWeapons();
		}

		private void Update()
		{
			// Switch weapons through keys.
			if (Input.inputString != "")
			{
				int slot;
				int.TryParse(Input.inputString[0].ToString(), out slot);

				if (slot > 0 && slot <= _inventory.Count)
				{
					slot -= 1;
					if (_inventory[slot].GetComponent<Weapon>().GetIsEnabled())
					{
						SwitchWeapons(slot);
					}
				}
			}
			
			// Switch weapons through scroll wheel.
			var scrollWheel = Input.GetAxisRaw("Mouse ScrollWheel");
			if (Math.Abs(scrollWheel) > 0)
			{
				// Scroll wheel up.
				if (scrollWheel > 0)
				{
					var targetIndex = _inventory.IndexOf(_activeWeapon) + 1;
					if (targetIndex >= _inventory.Count)
					{
						targetIndex = 0;
					}
					SwitchWeapons(targetIndex);
				}
				// Scroll wheel down.
				else if (scrollWheel < 0)
				{
					var targetIndex = _inventory.IndexOf(_activeWeapon) - 1;
					if (targetIndex < 0)
					{
						targetIndex = _inventory.Count - 1;
					}
					SwitchWeapons(targetIndex);
				}
			}
		}

		// When you spawn in remove all weapons except for pistol and equip the pistol.
		private void SetupWeapons()
		{
			for (int i = 1; i < _inventory.Count - 1; i++)
			{
				RemoveWeapon(i);
			}
			SwitchWeapons(0);
		}
		
		//your previous weapon become the active weapon
		public void SwitchWeapons(int index)
		{
			_previousWeapon = _activeWeapon;
			_activeWeapon = _inventory[index];
		}

		// When you walk over a weapon pickup it enables it and it becomes your active weapon.
		public void AddWeapon(int index)
		{
			_inventory[index].GetComponent<Weapon>().SetEnabled(true);
			
			if (_swapToPickup)
			{
				SwitchWeapons(index);
			}
		}
		public void RemoveWeapon(int index)
		{
			// Swap to the previous weapon if the current one is being removed.
			if (index == _inventory.IndexOf(_activeWeapon))
			{
				SwitchWeapons(_inventory.IndexOf(_previousWeapon));
			}
			_inventory[index].GetComponent<Weapon>().SetEnabled(false);
		}
	}
}
