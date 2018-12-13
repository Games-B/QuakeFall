using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _range;

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