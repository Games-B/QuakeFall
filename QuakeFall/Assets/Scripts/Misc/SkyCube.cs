using UnityEngine;

public class SkyCube : MonoBehaviour
{
	[SerializeField] private float colourSpeed = .1f;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private Color[] colours;
	[SerializeField] private Material skyBox;
	[SerializeField] private Light directionalLight;

	private int colourIndex;
	private int previousIndex;

	private float colourProgress;
	private void Update()
	{
		// Shift colours.
		colourProgress = Mathf.Clamp(colourProgress + Time.deltaTime * colourSpeed, 0, 1);
		var targetColour = Color.LerpUnclamped(colours[previousIndex], colours[colourIndex], colourProgress);
		// Change to next colour.
		if (colourProgress >= 1)
		{
			colourProgress = 0;
			previousIndex = colourIndex;
			if (colourIndex >= colours.Length - 1) colourIndex = 0;
			else colourIndex ++;
		}
		skyBox.SetColor("_Tint", targetColour);
		// directionalLight.color = targetColour;
		
		// Rotate the sky box.
		var rotation = skyBox.GetFloat("_Rotation");
		rotation+= Time.deltaTime * rotationSpeed;
		skyBox.SetFloat("_Rotation", rotation);
	}
}
