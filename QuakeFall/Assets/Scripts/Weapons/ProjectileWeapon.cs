using Network;
using UnityEngine;
using UnityEngine.Networking;

namespace Weapons
{
	public class ProjectileWeapon : Weapon
	{
		[Header("Projectile Weapon"), SerializeField] private int prefabIndex;
		[SerializeField] private float initialForce;
		private NetworkCommands networkCommands;

		private void Awake()
		{
			networkCommands = FindObjectOfType<NetworkCommands>();
		}

		public override bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			if (!base.Shoot(targetCamera, out targetPoint, out hit)) return false;
			networkCommands.CmdShoot(prefabIndex, gunEnd.position, targetPoint, initialForce);
			return true;
		}
	}
}
