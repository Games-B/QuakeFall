using Network;
using UnityEngine;
using UnityEngine.Networking;

namespace Weapons
{
	public class ProjectileWeapon : Weapon
	{
		[Header("Projectile Weapon"), SerializeField] private int _prefabIndex;
		[SerializeField] private float _initialForce;
		[SerializeField] private NetworkCommands _networkCommands;
		
		public override bool Shoot(UnityEngine.Camera targetCamera, out Vector3 targetPoint, out RaycastHit hit)
		{
			if (!base.Shoot(targetCamera, out targetPoint, out hit)) return false;
			_networkCommands.CmdShoot(_prefabIndex, GunEnd.position, targetPoint, _initialForce);
			return true;
		}
	}
}
