using UnityEngine;

public class JumpPad : MonoBehaviour
{
	[SerializeField, Range(0, 1000)] private float _jumpForce = 500;
 
	// Trigger when another GameObject enters the jump pad's trigger.
	private void OnTriggerEnter(Collider other)
	{
		// Work out the force to add to the object.
		var forceToAdd = Vector3.up * _jumpForce;
		// Add the force to the object's rigid body.
		other.GetComponent<Rigidbody>().AddForce(forceToAdd);
	}
}
