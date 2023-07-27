using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public partial class StoryBoard : MonoBehaviour
{   //÷���� �ڵ����� ĸ���̹��� ������ �����س���
	private int title;

	[SerializeField]
	private SceneListView sceneView;
	[SerializeField]
	private CutView cutView;
	private Vector2 _boardSize = Vector2.zero;
	private StoryBoardTable table;

	public Vector2 boardSize
	{
		get {
			_boardSize.y = (-cutView.bottomYPos + 200.0f);
			return _boardSize; 
		}
	}
	// Start is called before the first frame update
	void Start()
	{
		
		title = 1;
		table = Resources.Load<StoryBoardTable>("Tables/StoryBoardTable");

		// init persistance datapath
		string[] filePaths = Directory.GetFiles(Application.persistentDataPath);
		foreach (string filePath in filePaths)
			File.Delete(filePath);

		LoadZipFile();
		StartCoroutine(WaitStoryboardsize());
		

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CreateStoryBoard()
	{
		var texture = TextureExtractor.GetTexture(boardSize, cutView.cutImageActived.ToList(), Color.white, 20);
		//var png = texture.EncodeToPNG();
		//File.WriteAllBytes("Assets/Resources/"+table.storyBoardDir+"/toon.png", png); // temp save
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

	private void RefreshAll()
	{
		cutView.Refresh();
		sceneView.Refresh();
	}

	public IEnumerator WaitStoryboardsize()
	{
		yield return new WaitForSeconds(0.1f);

		_boardSize = cutView.GetComponent<RectTransform>().rect.size;
		Debug.Log(_boardSize);
	}

}
