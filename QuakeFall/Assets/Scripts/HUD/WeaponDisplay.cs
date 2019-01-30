using UnityEngine;
using UnityEngine.UI;
using Weapons;

public class WeaponDisplay : MonoBehaviour
{
	[SerializeField] private Text weaponName, weaponAmmo;
	[SerializeField] private Arsenal arsenal;

	private void Update()
	{
		var activeWeapon = arsenal.GetInventory()[arsenal.GetActiveWeapon()];
		weaponName.text = activeWeapon.GetName();
		weaponAmmo.text = string.Format("Ammo: {0}", activeWeapon.GetAmmo());
	}
}
