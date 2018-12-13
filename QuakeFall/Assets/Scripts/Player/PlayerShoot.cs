using UnityEngine;

<<<<<<< HEAD
namespace Player
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private float _damage = 10f;
		[SerializeField] private float _range = 100f;
=======
public class PlayerShoot : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _range;
>>>>>>> BoopGun

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