using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TextureExtractor 
{
    public static Texture2D GetTexture(Vector2 range, List<Image> cutImageList, Color backgroundColor, uint padding)
	{
		var texture = new Texture2D((int)range.x, (int)range.y);
		FillColor(texture, backgroundColor);

		foreach (var image in cutImageList)
		{
			texture = ComposeCut(texture, image);
		}
		return texture;
	}


	private static Texture2D ComposeCut(Texture2D background, Image image)
	{
		var startX = image.rectTransform.localPosition.x - image.rectTransform.rect.width / 2;
		var startY = (-image.rectTransform.localPosition.y);
		var copyTexture = duplicateTexture(image.sprite.texture);

		// »óÇÏÁÂ¿ì ¾Æ·¡ : ¿ø·¡ÁÂÇ¥ - ³ôÀÌ±îÁö   ÁÂ¿ì : ¿ø·¡ÁÂÇ¥ +- ³ÐÀÌ¹Ý
		for(int x = 0; x < image.rectTransform.rect.width; x++)
		{
			for (int y = 0; y < image.rectTransform.rect.height; y++)
			{
				background.SetPixel((int)startX + x, (int)startY + y, copyTexture.GetPixel(x, y));
				if (background.width < (int)startX + x || background.height < (int)startY + y)
					goto EndLoop;
			}
		}
		EndLoop:
		return background;
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

	private static Texture2D duplicateTexture(Texture2D source)
	{
		RenderTexture renderTex = RenderTexture.GetTemporary(
					source.width,
					source.height,
					0,
					RenderTextureFormat.Default,
					RenderTextureReadWrite.Linear);

		Graphics.Blit(source, renderTex);
		RenderTexture previous = RenderTexture.active;
		RenderTexture.active = renderTex;
		Texture2D readableText = new Texture2D(source.width, source.height);
		readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
		readableText.Apply();
		RenderTexture.active = previous;
		RenderTexture.ReleaseTemporary(renderTex);
		return readableText;
	}
}
