using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillZone : MonoBehaviour {

	void OnTriggerStay(Collider other)
	{
		HillScoreManager.score += 1;
	}
	
}
