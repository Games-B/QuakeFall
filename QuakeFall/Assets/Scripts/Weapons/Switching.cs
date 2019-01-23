using UnityEngine;

namespace Weapons
{
	[RequireComponent(typeof(Arsenal))]
	public class Switching : MonoBehaviour
	{
		private Arsenal _arsenal;

		private void Awake()
		{
			_arsenal = GetComponent<Arsenal>();
		}

		private void Update()
		{
			// Switch using the mouse scroll wheel.
			var scrollInput = Input.GetAxisRaw("Mouse ScrollWheel");
			_arsenal.SwitchWeapons(_arsenal.GetActiveWeapon() + (int)scrollInput);
		}
	}
}
