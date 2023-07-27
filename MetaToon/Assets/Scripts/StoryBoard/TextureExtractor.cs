using System.Collections;
using System.Collections.Generic;
using System.IO;
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
			ComposeCut(texture, image);
		}

		texture.Apply();
		return texture;
	}


	private static void ComposeCut(Texture2D background, Image image)
	{
		var startX = image.rectTransform.localPosition.x - image.rectTransform.rect.width / 2;
		var startY = background.height + image.rectTransform.localPosition.y - image.rectTransform.rect.height;
		Debug.Log(startY);
		var copyTexture = Resize(image.sprite.texture, (int)image.rectTransform.rect.width, (int)image.rectTransform.rect.height);



		Debug.Log($"texture size {background.width} , {background.height}");



		for (int x = 0; x < copyTexture.width; x++)
		{
			for (int y = 0; y < copyTexture.height; y++)
			{
				background.SetPixel((int)startX + x, (int)startY + y, copyTexture.GetPixel(x, y));
				if (background.width < (int)startX + x || background.height < (int)startY + y)
					continue;
			}
		}
	EndLoop:
		return;

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

	public static Texture2D textureFromSprite(Image image)
	{
		if (image.rectTransform.rect.width != image.sprite.texture.width)
		{
			Texture2D newText = new Texture2D((int)image.rectTransform.rect.width, (int)image.rectTransform.rect.height);
			Color[] newColors = image.sprite.texture.GetPixels((int)image.sprite.textureRect.x,
														 (int)image.sprite.textureRect.y,
														 (int)image.sprite.textureRect.width,
														 (int)image.sprite.textureRect.height);
			newText.SetPixels(newColors);
			newText.Apply();
			return newText;
		}
		else
			return image.sprite.texture;

		
	}
	public static Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
	{
		RenderTexture rt = new RenderTexture(targetX, targetY, 24);
		RenderTexture.active = rt;
		Graphics.Blit(texture2D, rt);
		Texture2D result = new Texture2D(targetX, targetY);
		result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
		result.Apply();
		return result;
	}
}
