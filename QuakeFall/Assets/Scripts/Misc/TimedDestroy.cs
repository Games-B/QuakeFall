using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
	[SerializeField] private float timeToDestroy;

	private float _timePassed;

	private void Update()
	{
		_timePassed = Mathf.Clamp(_timePassed + Time.deltaTime, 0, timeToDestroy);
		if (_timePassed >= timeToDestroy) Destroy(gameObject);
	}
}
