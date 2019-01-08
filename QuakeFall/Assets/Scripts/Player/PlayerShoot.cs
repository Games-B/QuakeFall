using UnityEngine;

namespace Player
{
	public class PlayerShoot : MonoBehaviour
	{
		[SerializeField] private int _damage;
		[SerializeField] private int _range;
		[SerializeField] private int _ammo;

		[SerializeField] private UnityEngine.Camera _fpsCam;
	
		// Unity Methods.
		private void Update () 
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Shoot();
			}
		}

		// Custom Methods.
		private void Shoot()
		{
			RaycastHit hit;
			if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
			{
				Debug.Log(hit.transform.name);
			}
		}
	}
}