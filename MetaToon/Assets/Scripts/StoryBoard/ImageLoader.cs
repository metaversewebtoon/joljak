using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public static class ImageLoader
{
	public enum type { Captured, Cut};

    public static List<Sprite> GetSprites(string basePath)
	{
		var sprites = Resources.LoadAll<Sprite>(basePath);
		List<Sprite> spritelist = new List<Sprite>();
		spritelist.AddRange(sprites);
		return spritelist;
	}

	public static List<Sprite> GetSpriteswithTextures(string basepath)
	{
		var imagePaths = Directory.GetFiles(basepath, "*.png");
		var textures = new List<Texture2D>();
		foreach(var path in imagePaths)
		{
			var b = File.ReadAllBytes(path);
			var texture = new Texture2D(2, 2);
			texture.LoadImage(b);
			textures.Add(texture);
		}
		List<Sprite> spritelist = new List<Sprite>();
		foreach (var t in textures)
		{
			var sprite = Sprite.Create(t, new Rect(Vector2.zero, new Vector2(t.width, t.height)),Vector2.zero);
			spritelist.Add(sprite);
		}
		
		return spritelist;
	}

}
