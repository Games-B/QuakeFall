using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{

	public class ButtonManagerTest : MonoBehaviour
	{

		public GameObject HostGamePanel;
		public GameObject JoinGamePanel;
		public GameObject OptionsPanel;
		public GameObject QuitAlert;



		// Use this for initialization
		void Start()
		{
			HostGamePanel.SetActive(false);
			JoinGamePanel.SetActive(false);
			OptionsPanel.SetActive(false);


		}

		// Update is called once per frame
		void Update()
		{

		}
		
	

		public void Options()
		{
			OptionsPanel.SetActive(true);
		}


		public void BackSettingsPanel()
		{
			OptionsPanel.SetActive(false);
		}



		public void QuitConfirmation()
			{
				QuitAlert.SetActive(true);
			}

			public void CancelQuit()
			{
				QuitAlert.SetActive(false);
			}

			public void ConfirmQuit()
			{
				Application.Quit();
			}
		}
	}
	
	
