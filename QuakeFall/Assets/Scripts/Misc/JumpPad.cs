using UnityEngine;

namespace Misc
{
	public class JumpPad : MonoBehaviour
	{
		[SerializeField] private float _jumpForce = 500;
        // Trigger when another GameObject enters the jump pad's trigger.
        private void OnTriggerEnter(Collider other)
        {
            // Work out the force to add to the object.
            var forceToAdd = transform.up * _jumpForce;
            // Add the force to the object's rigid body.
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;

            other.GetComponent<Rigidbody>().AddRelativeForce(forceToAdd);
            //FindObjectOfType<AudioManager>().Play("JumpPad");

        }
    }
}
