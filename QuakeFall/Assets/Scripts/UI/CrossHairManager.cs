using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CrossHairManager : MonoBehaviour
	{
		// Private fields.
		[SerializeField] private Sprite crossHairImage;
		[SerializeField] private Color crossHairFill;
		[SerializeField] private RectTransform[] transforms;
		[SerializeField] private int dotWidth, lineWidth, lineHeight, lineDistance;

		// Unity Methods.
		private void Update()
		{
			UpdateStyle();
		}

		// Custom Methods.
		private void UpdateStyle()
		{
			// Change the sprite and colour of all the elements.
			foreach (var rectTransform in transforms)
			{
				var image = rectTransform.GetComponent<Image>();
				image.sprite = crossHairImage;
				image.color = crossHairFill;
			}
			
			// Resize all the elements, starting with the center.
			transforms[0].sizeDelta = new Vector2(dotWidth, dotWidth);
			// Top one.
			transforms[1].anchoredPosition = Vector2.up * lineDistance;
			transforms[1].sizeDelta = new Vector2(lineHeight, lineWidth);
			// Right one.
			transforms[2].anchoredPosition = Vector2.right * lineDistance;
			transforms[2].sizeDelta = new Vector2(lineWidth, lineHeight);
			// Bottom one.
			transforms[3].anchoredPosition = Vector2.down * lineDistance;
			transforms[3].sizeDelta = new Vector2(lineHeight, lineWidth);
			// Left one.
			transforms[4].anchoredPosition = Vector2.left * lineDistance;
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
