using UnityEngine;

namespace Player
{
	// Make sure the health script is attached to a player.
	[RequireComponent(typeof(PlayerMovement))]
	public class PlayerHealth : MonoBehaviour
	{
		[SerializeField, Range(1, 1000)] private int _maxHealth;
	}
}
