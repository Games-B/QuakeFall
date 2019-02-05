using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class Scope : MonoBehaviour
	{

		[SerializeField] private Animator _animator;
		[SerializeField] private bool _isScoped = false;
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				_isScoped = !_isScoped;
				_animator.SetBool("ScopedIn", _isScoped);
			}
		}
	}
}
