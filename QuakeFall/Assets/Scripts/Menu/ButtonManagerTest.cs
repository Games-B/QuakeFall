﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{

	public class ButtonManagerTest : MonoBehaviour
	{

		public GameObject OptionsPanel;
		public GameObject GameplayPanel;
		public GameObject GraphicsPanel;
		public GameObject SoundPanel;
		public GameObject QuitAlert;


		// Use this for initialization
		void Start()
		{
			OptionsPanel.SetActive(false);
			GraphicsPanel.SetActive(false);
			SoundPanel.SetActive(false);
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void Options()
		{
			OptionsPanel.SetActive(true);
		}

		public void Gameplay()
		{
			GameplayPanel.SetActive(true);
			GraphicsPanel.SetActive(false);
			SoundPanel.SetActive(false);
		}

		public void Graphics()
		{
			GraphicsPanel.SetActive(true);
			GameplayPanel.SetActive(false);
			SoundPanel.SetActive(false);
		}

		public void Sound()
		{
			SoundPanel.SetActive(true);
			GraphicsPanel.SetActive(false);
			GameplayPanel.SetActive(false);
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