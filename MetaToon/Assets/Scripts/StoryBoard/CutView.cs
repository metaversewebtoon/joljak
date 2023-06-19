using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CutView : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<uint, Cut> cutSet = new Dictionary<uint, Cut>();
    private uint imageCount;
    private StoryBoardTable table;

    private Cut targetCut; // 리스너로 타겟지정

    public IEnumerable<Cut> cuts => cutSet.Values;
    public IEnumerable<Image> cutImages => cuts.Select( x => x.GetComponent<Image>() );

	//public IEnumerable<Cut> cutList => cutDic.SelectMany(x => x.Value);
	public float bottomYPos { get { return cutSet.Values.Select(x => x.transform.position.y).Min(); } }
	public float topYPos { get { return cutSet.Values.Select(x => x.transform.position.y).Max(); } }

	void Start()
    {
        table = Resources.Load<StoryBoardTable>("Tables/StoryBoardTable");

        imageCount = 0;
        var spriteList = ImageLoader.GetSpriteswithTextures(table.resourceDir);
        // 리소스파일에서 텍스쳐 수만큼 팩토리에 생성요청
        foreach (var sprite in spriteList)
        {
            var cut = CutFactory.CreateCut(this.transform, imageCount, sprite, table);
            cutSet[imageCount]=cut;
            imageCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCut()
	{
        targetCut.gameObject.SetActive(false);
	}

    public void EnableCut()
	{
        targetCut.gameObject.SetActive(true);
	}

   
}
