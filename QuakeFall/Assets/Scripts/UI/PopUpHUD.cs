using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpHUD : MonoBehaviour
{

	public GameObject InGameHUD;
	private bool _isShowing;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_isShowing = !_isShowing;
			InGameHUD.SetActive(_isShowing);
		} 
		
	
		
	}
}
