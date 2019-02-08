using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class Scope : MonoBehaviour
	{
		[SerializeField] private Camera _targetCamera;
		[SerializeField] private float _zoomedFov, _normalFov;
		[SerializeField] private Animator _animator;
		[SerializeField] private bool _isScoped = false;
		[SerializeField] private float _scopeTime;
		[SerializeField] private GameObject _scopeUi;
		[SerializeField] private GameObject _weaponCamera;

		private float _scopeTimer;
	
		// Update is called once per frame
		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				_isScoped = true;
				_animator.SetBool("ScopedIn", true);
			}
			else if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				_isScoped = false;
				_animator.SetBool("ScopedIn", false);
				OnUnscoped();
			}
			
			
			if (_isScoped)
			{
				if (_scopeTimer >= _scopeTime) OnScoped();
				else
				{
					_scopeTimer = Mathf.Clamp(_scopeTimer + Time.deltaTime, 0, _scopeTime);
				}
			}
		}

		private void OnUnscoped()
		{
			_targetCamera.fieldOfView = _normalFov;
			_scopeUi.SetActive(false);
			_weaponCamera.SetActive(true);
		}

		private void OnScoped()
		{
			_targetCamera.fieldOfView = _zoomedFov;
			_scopeUi.SetActive(true);
			_weaponCamera.SetActive(false);
		}
	}
}
