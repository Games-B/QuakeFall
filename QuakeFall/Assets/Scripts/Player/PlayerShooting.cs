using UnityEngine;
using Weapons;

namespace Player
{
	public class PlayerShooting : MonoBehaviour
	{
		[SerializeField] private UnityEngine.Camera _targetCamera;
		[SerializeField] private Arsenal _arsenal;
        

        private void Awake()
        {
            
        }

        private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Vector3 targetPoint;
				RaycastHit hit;
				_arsenal.GetInventory()[_arsenal.GetActiveWeapon()].Shoot(_targetCamera, out targetPoint, out hit);
				print(targetPoint);
			}
		}
	}
}
