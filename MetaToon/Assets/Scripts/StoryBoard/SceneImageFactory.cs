using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneImageFactory 
{
    public static SceneImage CreateSceneImage(Transform parent, uint imageNum, 
		Sprite sprite, StoryBoardTable storyBoardTable)
	{
		var sceneImagePrefab = storyBoardTable.sceneImagePrefab;
		var sceneImage = Object.Instantiate(sceneImagePrefab);
		sceneImage.transform.parent = parent;
		sceneImage.name = $"SceneImage{imageNum}";
		sceneImage.thumb.gameObject.SetActive(false);
		sceneImage.GetComponent<Image>().sprite = sprite;
		return sceneImage;
	}

}
