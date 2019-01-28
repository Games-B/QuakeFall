using System;
using UnityEngine;

namespace Weapons
{
	[RequireComponent(typeof(Arsenal))]
	public class Switching : MonoBehaviour
	{
		[SerializeField] private float cooldown;
		
		private Arsenal _arsenal;
		private float _currentCooldown;

		private void Awake()
		{
			_arsenal = GetComponent<Arsenal>();
		}

		private void Update()
		{
			var scrollInput = Input.GetAxisRaw("Mouse ScrollWheel");
			if (_currentCooldown >= cooldown && Math.Abs(scrollInput) > 0)
			{
				_currentCooldown = 0;
				// Switch using the mouse scroll wheel.
				scrollInput = scrollInput > 0 ? 1 : -1;
				_arsenal.SwitchWeapons(_arsenal.GetActiveWeapon() + (int)scrollInput);
			}

			_currentCooldown = Mathf.Clamp(_currentCooldown + Time.deltaTime, 0, cooldown);
		}
	}
}
