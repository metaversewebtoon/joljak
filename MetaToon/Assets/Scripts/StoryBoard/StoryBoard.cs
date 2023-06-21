using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public partial class StoryBoard : MonoBehaviour
{   //첨에는 자동으로 캡쳐이미지 순서로 생성해놓기
	private int title;

	private Vector2 boardSize;

	[SerializeField]
	private SceneListView sceneView;
	[SerializeField]
	private CutView cutView;

	private StoryBoardTable table;

	

	// Start is called before the first frame update
	void Start()
	{
		
		title = 1;
		table = Resources.Load<StoryBoardTable>("Tables/StoryBoardTable");
		boardSize = this.transform.Find("StoryBoardView/ViewPort/Content").GetComponent<RectTransform>().rect.size;

		
		LoadZipFile();
		boardSize.y = -(cutView.bottomYPos + 500.0f);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CreateStoryBoard()
	{
		var texture = TextureExtractor.GetTexture(boardSize, cutView.cutImages.ToList(), Color.white, 20);
		UploadStoryBoard(texture.EncodeToPNG(), "ToonName" + title);
		
	}

	public void DisableCut()
	{
		var cut = EventSystem.current.currentSelectedGameObject.GetComponent<Cut>();
		if (cut.Equals(null))
			return;
		cut.gameObject.SetActive(false);
	}

	public void EnableCut(uint id)
	{
		var cut = cutView.cutDict[id];
		cut.pos = new Vector2(650.0f, cutView.bottomYPos);
		cut.gameObject.SetActive(true);
		
	}

}
