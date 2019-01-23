using Player;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class ScreenFlash : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField, Range(0, 1)] private float _healthThreshold = .3f;
        [SerializeField] private float _flashCooldown;
        [SerializeField] private Image _vignette;
        [Header("Colours"), SerializeField] private Color _defaultColour;
        [SerializeField] private Color _shieldColour, _lowHealthColour;

        private float _currentCooldown;

        private void Start()
        {
            _vignette.color = _defaultColour;
        }

        private void Update()
        {
            var pHealth = _playerHealth.GetHealth();
            if ((float) pHealth[0] / pHealth[1] <= _healthThreshold && _currentCooldown >= _flashCooldown)
            {
                FlashHealth();
            }

            _currentCooldown = Mathf.Clamp(_currentCooldown += Time.deltaTime, 0, _healthThreshold);
        }

        private void FlashHealth()
        {
            _vignette.color = _vignette.color == _lowHealthColour ?  _defaultColour : _lowHealthColour;
            _currentCooldown = 0;
        }
    }
}
