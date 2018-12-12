using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
	public class Settings : MonoBehaviour
	{
		[SerializeField] private Slider _fovSlider;
		[SerializeField] private Slider _brightnessSlider;

		private float _rbgValue = 0.5f;
		
		//Sound and music needed to experiment with linking the slider 
		public void SetVolume(float volume)
		{
			Debug.Log(volume);
		
		}

			public void AdjustAmbientLight (float rbgValue){
				RenderSettings.ambientLight = new Color (rbgValue, rbgValue, rbgValue, 1);
				PlayerPrefs.SetFloat("Realtime Brightness", _brightnessSlider.value);
			}
		
		public void SetQuality(int qualityIndex)
		{
			//Connected to the quality settings of Unity
			QualitySettings.SetQualityLevel(qualityIndex);
		}

		public void SetFullscreen(bool isFullScreen)
		{
			Screen.fullScreen = isFullScreen;
		}

		private void Update()
		{
			// Live settings.
			PlayerPrefs.SetFloat("Realtime FOV", _fovSlider.value);
		}

		
		public void Revert()
		{
			_fovSlider.value = PlayerPrefs.GetFloat("Applied FOV");
		}
		
		public void Apply()
		{
			PlayerPrefs.SetFloat("Applied FOV", _fovSlider.value);
			PlayerPrefs.Save();
		}
	}
}
