using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
	public class CrossHairManager : MonoBehaviour
	{
		// Private fields.
		[SerializeField] private Transform player;
		[SerializeField] private Sprite crossHairImage;
		[SerializeField] private Color crossHairFill;
		[SerializeField] private RectTransform[] transforms;
		[SerializeField] private int dotWidth, lineWidth, lineHeight, lineDistance;
		[SerializeField] private float dynamicMultiplier, dynamicScale;

		private Vector3 _oldPosition;
		private Image[] _images;

		private void Start()
		{
			// Set up the images at the start to save memory.
			_images = new Image[transforms.Length];

			for (var i = 0; i < transforms.Length; i++)
			{
				_images[i] = transforms[i].GetComponent<Image>();
			}
		}

		// Unity Methods.
		private void FixedUpdate()
		{
			var newPosition = player.position;
			var difference = newPosition - _oldPosition;
			dynamicMultiplier = 1 + Mathf.Abs(difference.x) + Mathf.Abs(difference.y) + Mathf.Abs(difference.z) * dynamicScale;
			_oldPosition = newPosition;
		}

		private void Update()
		{
			UpdateStyle();
		}

		// Custom Methods.
		private void UpdateStyle()
		{
			// Change the sprite and colour of all the elements.
			foreach (var image in _images)
			{
				image.sprite = crossHairImage;
				image.color = crossHairFill;
			}
			
			// Resize all the elements, starting with the center.
			transforms[0].sizeDelta = new Vector2(dotWidth, dotWidth);
			// Top one.
			transforms[1].anchoredPosition = Vector2.up * lineDistance * dynamicMultiplier;
			transforms[1].sizeDelta = new Vector2(lineHeight, lineWidth);
			// Right one.
			transforms[2].anchoredPosition = Vector2.right * lineDistance * dynamicMultiplier;
			transforms[2].sizeDelta = new Vector2(lineWidth, lineHeight);
			// Bottom one.
			transforms[3].anchoredPosition = Vector2.down * lineDistance * dynamicMultiplier;
			transforms[3].sizeDelta = new Vector2(lineHeight, lineWidth);
			// Left one.
			transforms[4].anchoredPosition = Vector2.left * lineDistance * dynamicMultiplier;
			transforms[4].sizeDelta = new Vector2(lineWidth, lineHeight);
		}

		private void OnEnable()
		{
			foreach (var rectTransform in transforms)
			{
				rectTransform.gameObject.SetActive(true);
			}
		}

		private void OnDisable()
		{
			foreach (var rectTransform in transforms)
			{
				rectTransform.gameObject.SetActive(false);
			}
		}
	}
}
