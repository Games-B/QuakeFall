using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	public Image HealthBarEnemy;
	public Image ShieldBarEnemy;

	public void UpdateBar(float currentHealth, float maxHealth, float currentShied, float maxShield)
	{
		HealthBarEnemy.fillAmount = currentHealth / maxHealth;
		
		//If the shield is activated
		//Cover health bar, take dmg first
		ShieldBarEnemy.fillAmount = currentShied / maxShield;
		//If shied is 0, deactivate it
		//Health bar absorbs the dmg
	}
	
	
}
