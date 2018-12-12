using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public float Multiplier = 1.4f;
	public float Duration = 14f;
	
	public GameObject PickupEffect;
	
	// When 
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(Pickup(other));
		}
	}

	IEnumerator Pickup(Collider player)
	{
		var effect = Instantiate(PickupEffect, transform.position, transform.rotation);
		effect.transform.parent = transform;

		PlayerStats stats = player.GetComponent<PlayerStats>();
		stats.shield *= Multiplier;

		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		
		yield return new WaitForSeconds(Duration);

		stats.shield /= Multiplier;
		
		Destroy(gameObject);
	}
}