using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CrossHairManager : MonoBehaviour
	{
		// Private fields.
		[SerializeField] private Sprite _crossHairImage;
		[SerializeField] private Color _crossHairFill;
		[SerializeField] private RectTransform[] _transforms;
		[Space]
		[SerializeField] private int _dotWidth, _lineWidth, _lineHeight, _lineDistance;

		// Unity Methods.
		private void Update()
		{
			UpdateStyle();
		}

		// Custom Methods.
		private void UpdateStyle()
		{
			// Change the sprite and colour of all the elements.
			foreach (var rectTransform in _transforms)
			{
				var image = rectTransform.GetComponent<Image>();
				image.sprite = _crossHairImage;
				image.color = _crossHairFill;
			}
			
			// Resize all the elements, starting with the center.
			_transforms[0].sizeDelta = new Vector2(_dotWidth, _dotWidth);
			// Top one.
			_transforms[1].anchoredPosition = Vector2.up * _lineDistance;
			_transforms[1].sizeDelta = new Vector2(_lineHeight, _lineWidth);
			// Right one.
			_transforms[2].anchoredPosition = Vector2.right * _lineDistance;
			_transforms[2].sizeDelta = new Vector2(_lineWidth, _lineHeight);
			// Bottom one.
			_transforms[3].anchoredPosition = Vector2.down * _lineDistance;
			_transforms[3].sizeDelta = new Vector2(_lineHeight, _lineWidth);
			// Left one.
			_transforms[4].anchoredPosition = Vector2.left * _lineDistance;
			_transforms[4].sizeDelta = new Vector2(_lineWidth, _lineHeight);
		}
	}
}
