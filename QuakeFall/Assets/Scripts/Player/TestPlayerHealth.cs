using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerHealth : MonoBehaviour
{

	/*public int PlayerHealth;
	public int NumOfHealth; //Number of health bars
	public Image[] HealthBars;
	public Image[] ShieldBars;
	public Sprite RedBars; //Red health
	public Sprite BlueBars; //Blue shield bars */



	private void Start()
	{

	}

	void Update()
	{
		int totalNodes = 10;
		float maxHealth = 100;
		float currentHealth = 67;
		float healthNodeValue = maxHealth / totalNodes;

		Image[] healthNodes = new Image[10];

		float nodesToVanish = (maxHealth - currentHealth) / healthNodeValue;
		
		//////////////////////////////////////

		int nodesToShow = totalNodes - (int) nodesToVanish;

		for (int i = 0; i < healthNodes.Length; i++)
		{
			if (i < nodesToShow)
			{
				healthNodes[i].enabled = true;
			}
			else
			{
				healthNodes[i].enabled = false;
			}
			
		}

		/*if (PlayerHealth > NumOfHealth)
		{
			PlayerHealth = NumOfHealth;
		}*/

		/*if (Input.GetKeyDown(KeyCode.Q))
		{
			for (int i = 0; i < HealthBars.Length; i++)
			{
				if (i < NumOfHealth)
				{
					ShieldBars[i].enabled = true;
				}
				else
				{
					ShieldBars[i].enabled = false;
				}
			}  //Disregard this

			for (int i = 0; i < HealthBars.Length; i++)
			{
				if (i < NumOfHealth)
				{
					HealthBars[i].enabled = true;
				}
				else
				{
					HealthBars[i].enabled = false;
				}
			}

			// ***** NOTES TO SELF ***** //
			// If the player picks up the shield
			// Replace the red bars with blue
			// When taken dmg, replace the blue ones with red
			// Once shield gone, if taken dmg, get rid of the red ones
			// When nothing is drawn, player = dead

		}*/

	}
}


