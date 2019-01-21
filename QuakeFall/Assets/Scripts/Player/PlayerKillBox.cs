using UnityEngine;

namespace Player
{
	public class PlayerKillBox : MonoBehaviour
	{
		[SerializeField] private float heightThreshold;
		private PlayerHealth _playerHealth;

		private void Awake()
		{
			_playerHealth = GetComponent<PlayerHealth>();
		}

		private void Update()
		{
			if (transform.position.y < heightThreshold)
			{
				_playerHealth.Die();
			}
		}
	}
}