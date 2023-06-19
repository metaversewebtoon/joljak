using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TextureExtractor 
{
    public static Texture2D GetTexture(Vector2 range, List<Image> cutImageList, Color backgroundColor)
	{
		var texture = new Texture2D((int)range.x, (int)range.y);
		FillColor(texture, backgroundColor);

		foreach (var image in cutImageList)
		{
			ComposeCut(texture, image);
		}
		return texture;
	}


	private static void ComposeCut(Texture2D background, Image image)
	{
		var startX = image.rectTransform.position.x - image.rectTransform.rect.width / 2;
		var startY = image.rectTransform.position.y + image.rectTransform.rect.height / 2;

		for(int x = (int)startX; x < image.rectTransform.rect.width; x++)
		{
			for (int y = (int)startY; y > startY - image.rectTransform.rect.height; y--)
			{
				background.SetPixel(x, y, image.sprite.texture.GetPixel(x, y));
			}
		}
	}

	private static void FillColor(Texture2D texture, Color color)
	{
		for (int y = 0; y < texture.height; y++)
		{
			for (int x = 0; x < texture.width; x++)
			{

				texture.SetPixel(x, y, color);

			}
		}
	}
}
