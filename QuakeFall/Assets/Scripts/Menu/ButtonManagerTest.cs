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
        public GameObject AudioSettingsPanel;
		public GameObject QuitAlert;
		private bool _isShowingHost;
		private bool _isShowingJoin;
		private bool _isShowingOptions;



		// Use this for initialization
		void Start()
		{
			HostGamePanel.SetActive(false);
			JoinGamePanel.SetActive(false);
			OptionsPanel.SetActive(false);
            AudioSettingsPanel.SetActive(false);


		}

		// Update is called once per frame
		void Update()
		{

		}

		public void HostGameSection()
		{
			_isShowingHost = !_isShowingHost;
			HostGamePanel.SetActive(_isShowingHost);
			
			
			
		

		}

		public void JoinGameSection()
		{
			_isShowingJoin = !_isShowingJoin;
			JoinGamePanel.SetActive(_isShowingJoin);
			
			
		}
	

		public void Options()
		{
			_isShowingOptions = !_isShowingOptions;
			OptionsPanel.SetActive(_isShowingOptions);
			
			
		}


        public void AudioPanel()
        {
            AudioSettingsPanel.SetActive(true);
	        
	
        }


        public void BackSettingsPanel()
		{
			OptionsPanel.SetActive(false);
			JoinGamePanel.SetActive(false);
			HostGamePanel.SetActive(false);
            AudioSettingsPanel.SetActive(false);
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
	
	
