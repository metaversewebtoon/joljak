using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutFactory 
{
	public static Cut CreateCut(Transform parent, uint cutNum, Sprite sprite,
		StoryBoardTable table)
	{
		var cutPrefab = table.cutPrefab;
		var cut = Object.Instantiate(cutPrefab);
		cut.transform.parent = parent;
		cut.name = $"Cut{cutNum}";
		cut.GetComponent<Image>().sprite = sprite;
		cut.init(cutNum);
		return cut;
	}
}
