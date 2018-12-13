using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HillScoreManager : MonoBehaviour
{

	public static int score;
	Text text1;


	void Awake()
	{
		text1 = GetComponent<Text>();
		score = 0;
	} 
	
	void Update()
	{
		text1.text = "Score" + score;
	}
}
