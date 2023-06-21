using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneImage : MonoBehaviour, IPointerClickHandler
{
    // 텍스쳐와 연결되어있고
    // 크기와 위치 조정만 
    // model 클래스와 동기화
    // Start is called before the first frame update
    StoryBoard storyBoard;
    uint id;
    void Start()
    {
        Debug.Log(transform.root.name);
        storyBoard = transform.root.GetComponent<StoryBoard>();
        Debug.Log(storyBoard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(uint id)
	{
        // 처음위치 설정
        this.id = id;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.name);
        storyBoard.EnableCut(id);
    }
}
