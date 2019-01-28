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
		[SerializeField] private float forwardOffset;
		
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
			
			if (activeWeapon == 0) return;
			var inventory = _arsenal.GetInventory();
			var ammo = inventory[activeWeapon].GetAmmo();
			var spawnPosition = playerTransform.position + playerTransform.forward * forwardOffset;
			networkCommands.CmdDropWeapon(activeWeapon, ammo,  spawnPosition, playerTransform.forward * dropForce);
			_arsenal.RemoveWeapon(activeWeapon);
		}
	}
}
