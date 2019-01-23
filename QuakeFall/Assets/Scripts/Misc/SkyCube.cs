using UnityEngine;

public class SkyCube : MonoBehaviour
{
	[SerializeField, Range(0, 1)] private float colourSpeed = .1f;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private Color[] colours;
	[SerializeField] private Material skyBox;

	private int colourIndex;

	private void Update()
	{
		// Shift colours.
		var targetColour = Color.LerpUnclamped(skyBox.GetColor("_Tint"), colours[colourIndex], colourSpeed);
		if (targetColour == colours[colourIndex])
		{
			if (colourIndex >= colours.Length - 1) colourIndex = 0;
			else colourIndex ++;
		}
		skyBox.SetColor("_Tint", targetColour);
		// Rotate the sky box.
		var rotation = skyBox.GetFloat("_Rotation");
		rotation+= Time.deltaTime * rotationSpeed;
		skyBox.SetFloat("_Rotation", rotation);
	}
}
