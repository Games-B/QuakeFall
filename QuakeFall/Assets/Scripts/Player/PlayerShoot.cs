using UnityEngine;

namespace Player
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private float _damage = 10f;
		[SerializeField] private float _range = 100f;

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

				var target = hit.transform.GetComponent<Target>();
				if (target != null)
				{
					target.TakeDamage(_damage);
				}
			}
		}
	}
}