using UnityEngine;

namespace Camera
{
	[RequireComponent(typeof(UnityEngine.Camera))]
	public class CameraFov : MonoBehaviour
	{
		private UnityEngine.Camera _camera;

		private void Awake()
		{
			_camera = GetComponent<UnityEngine.Camera>();
		}

		private void Update()
		{
			_camera.fieldOfView = PlayerPrefs.GetFloat("Realtime FOV");
		}
	}
}
