using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI: MonoBehaviour
	{

		[SerializeField] private GameObject _scoreBoard;

		[SerializeField] private Text _ammoText;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update()
		{

			if (Input.GetKeyDown(KeyCode.Tab))
			{
				_scoreBoard.SetActive(true);
			}
			else if (Input.GetKeyUp(KeyCode.Tab))
			{
				_scoreBoard.SetActive(false);
			}
		}

		void SetAmmoAmount(int amount)
		{
			_ammoText.text = amount.ToString();
		}
	}
	