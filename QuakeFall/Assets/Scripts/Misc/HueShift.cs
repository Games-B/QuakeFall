using UnityEngine;
using UnityEngine.PostProcessing;

public class HueShift : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private PostProcessingProfile _profile;

	private void Update()
	{
		var settings = _profile.colorGrading.settings;
		// Reset the hue shift if it overflows.
		if (settings.basic.hueShift >= 180)
		{
			settings.basic.hueShift = -180;
		}
		settings.basic.hueShift = Mathf.Clamp(settings.basic.hueShift + _speed, -180, 180);
		_profile.colorGrading.settings = settings;
	}
}
