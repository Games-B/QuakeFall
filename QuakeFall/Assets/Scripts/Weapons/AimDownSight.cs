using UnityEngine;


public class AimDownSight : MonoBehaviour
{
	[SerializeField] private Vector3 _aimDownSight;
	[SerializeField] private Vector3 _hipFire;
	[SerializeField, Range(0, 1)] private float _speed;
	
	// Update is called once per frame
	public void Update () 
	{
		if (Input.GetKey(KeyCode.Mouse1))
		{
			transform.localPosition = Vector3.Slerp(transform.localPosition, _aimDownSight, _speed);
		}
		else
		{
			transform.localPosition = Vector3.Slerp(transform.localPosition, _hipFire, _speed);
		}
	}
}
