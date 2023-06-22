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

    public Dictionary<uint, Cut> cutDict => cutSet;
    public IEnumerable<Cut> cuts => cutSet.Values;
    public IEnumerable<Image> cutImages => cuts.Select(x => x.GetComponent<Image>());
    public IEnumerable<Image> cutImageActived => cuts.Select(x => x.GetComponent<Image>()).Where(x => x.gameObject.activeSelf == true);

    //public IEnumerable<Cut> cutList => cutDic.SelectMany(x => x.Value);
    public float bottomYPos { 
        get {
            var count = cuts.Where(x => x.gameObject.activeSelf == true).Count();
            if (count ==  0)
                return -100.0f;
            else
                return cuts.Where(x=>x.gameObject.activeSelf == true).Select(x => x.transform.localPosition.y).Min() - 500.0f;  //나중에 컷 크기로 수정
        } 
    }
	public float topYPos { 
        get 
        {
            if (cutSet.Count == 0)
                return -100.0f;
            else
                return cuts.Where(x => x.gameObject.activeSelf == true).Select(x => x.transform.localPosition.y).Max(); 
        }
    }

    public void Refresh()
	{
        cutSet.Clear();
        imageCount = 0;
        var spriteList = ImageLoader.GetSpriteswithTextures(Application.persistentDataPath);
        // 리소스파일에서 텍스쳐 수만큼 팩토리에 생성요청
        foreach (var sprite in spriteList)
        {
            var cut = CutFactory.CreateCut(this.transform, imageCount, sprite, table);
            cut.gameObject.SetActive(false);
            cutSet.Add(imageCount, cut);
            imageCount++;
        }
    }

	void Start()
    {
        table = Resources.Load<StoryBoardTable>("Tables/StoryBoardTable");
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

   
}
