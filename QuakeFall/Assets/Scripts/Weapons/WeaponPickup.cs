using UnityEngine;

namespace Weapons
{
	public class WeaponPickup : MonoBehaviour
	{
		[SerializeField] private int weaponIndex;
		[SerializeField] private int ammo;

		// Getters and setters.
		public void SetAmmo(int newAmmo)
		{
			ammo = newAmmo;
		}

		public int[] GetStats()
		{
			return new[]
			{
				weaponIndex, ammo
			};
		}
		
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				other.gameObject.GetComponentInChildren<Arsenal>().AddWeapon(weaponIndex);
				Destroy(gameObject);
			}
		}
	}
}