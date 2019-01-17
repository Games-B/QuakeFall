using UnityEngine;
using UnityEngine.UI;

public class KingOfTheHillManager : MonoBehaviour {

	[SerializeField] private float _score;  // The player's score.
	[SerializeField] private Text _text1;   // Reference to the Text component.
	
	[SerializeField] private float _bonusMultiplier; // Every second, the points increase by THIS amount. Right now it is 1.
	[SerializeField] private float _


	private void Awake()
	{
		// Reset the score.
		_score = 0;
	}

	private void Update()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		_text1.text = "Score:" + Mathf.RoundToInt(_score);
	}
	
	private void OnTriggerStay(Collider other)
	{
		_score += _bonusMultiplier * Time.deltaTime;		
	}
}