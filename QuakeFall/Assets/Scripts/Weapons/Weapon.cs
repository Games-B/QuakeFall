using UnityEngine;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		// Weapon name and image of weapon.
		[SerializeField] private string _name;
		[SerializeField] private Sprite _icon;
		[SerializeField] private bool _enabled;
		[SerializeField] private GameObject _model;
	
		// Weapons stats.
		[Space]
		[SerializeField] private int _damage;
		[SerializeField] private int _headshotdamage;
		[SerializeField] private float _knockBack;
		[SerializeField] private float _range;
		[SerializeField] private int _ammo;

		// Getters and Setters.
		public void SetEnabled(bool isEnabled)
		{
			_enabled = isEnabled;
		}
	}xx
}
