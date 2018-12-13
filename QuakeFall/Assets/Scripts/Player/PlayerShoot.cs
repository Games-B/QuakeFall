using UnityEngine;

namespace Player
{
	public class PlayerShoot : MonoBehaviour
	{
		[SerializeField] private int _damage;
		[SerializeField] private int _range;

		public Camera FpsCam;
	
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
			if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, _range))
			{
				Debug.Log(hit.transform.name);
			}
		}
	}
}