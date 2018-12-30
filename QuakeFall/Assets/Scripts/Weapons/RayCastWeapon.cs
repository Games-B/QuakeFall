using UnityEngine;

namespace Weapons
{
	public class RayCastWeapon : Weapon
	{
		[SerializeField] private LineRenderer _lineRenderer;
		
		protected override void SpawnBullet(Vector3 targetPoint)
		{
			_lineRenderer.SetPosition(0, GunEnd.position);
			_lineRenderer.SetPosition(1, targetPoint);
		}
	}
}
