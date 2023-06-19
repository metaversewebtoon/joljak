using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneListView : MonoBehaviour
{
    private Dictionary<uint, SceneImage> sceneImageSet = new Dictionary<uint, SceneImage>();
    private uint imageCount;
    private StoryBoardTable table;
    // Start is called before the first frame update
    void Start()
    {
        table = Resources.Load<StoryBoardTable>("Tables/StoryBoardTable");

        imageCount = 0;
        var spriteList = ImageLoader.GetSpriteswithTextures(table.resourceDir);
        // 리소스파일에서 텍스쳐 수만큼 팩토리에 생성요청
        foreach(var sprite in spriteList)
		{
            var sceneImage = SceneImageFactory.CreateSceneImage(this.transform, imageCount, sprite, table);
            sceneImageSet[imageCount]=sceneImage;
            imageCount++;
		}
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
