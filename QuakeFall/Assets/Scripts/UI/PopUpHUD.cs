using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PopUpHUD : MonoBehaviour
{

	public GameObject InGameHUD;
	private bool _isShowing;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_isShowing = !_isShowing;
			InGameHUD.SetActive(_isShowing);
		}
	
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
