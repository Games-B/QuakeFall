using Network;
using UnityEngine;

namespace Weapons
{
	[RequireComponent(typeof(Arsenal))]
	public class DropWeapons : MonoBehaviour
	{
		[SerializeField] private float dropForce;
		[Header("References"), SerializeField] private Transform playerTransform;
		[SerializeField] private NetworkCommands networkCommands;

		private Arsenal _arsenal;

		private void Awake()
		{
			_arsenal = GetComponent<Arsenal>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				DropWeapon();
			}
		}

		private void DropWeapon()
		{
			var activeWeapon = _arsenal.GetActiveWeapon();
			var inventory = _arsenal.GetInventory();
			var ammo = inventory[activeWeapon].GetAmmo();
			networkCommands.CmdDropWeapon(activeWeapon, ammo, playerTransform.position, playerTransform.forward * dropForce);
			_arsenal.RemoveWeapon(activeWeapon);
		}
	}
}
