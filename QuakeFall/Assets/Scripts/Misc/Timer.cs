using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Misc
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Text _uiText;
        [SerializeField, Tooltip("The time of the round (In seconds)")] private float _mainTimer;
        [SerializeField, Range(1, 60)] private float _millisecondThreshold = 30;

        [SerializeField] private float _timer;
        [SerializeField] private bool _canCount = true;
        [SerializeField] private bool _doOnce = false;

        private void Start()
        {
            _timer = _mainTimer;
        }

        private void Update()
        {
            if (_timer >= 0 && _canCount)
            {
                _timer -= Time.unscaledDeltaTime;
                
                // Format the timer.
                var time = TimeSpan.FromSeconds(_timer);

                string formattedTime;

                if (_timer > _millisecondThreshold)
                {
                    formattedTime = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
                }
                // Add milliseconds if the timer is below the threshold.
                else
                {
                    formattedTime = string.Format("{0:00}:{1:00}", time.Seconds, time.Milliseconds);
                }
                
                _uiText.text = formattedTime;
            }
            else if (_timer <= 0f && !_doOnce)
            {
                _canCount = false;
                _doOnce = true;
                _uiText.text = "Game Over";
                _timer = 0;
            }
        }
    } 

}

