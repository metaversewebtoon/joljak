using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneImage : MonoBehaviour, IPointerClickHandler
{
    // �ؽ��Ŀ� ����Ǿ��ְ�
    // ũ��� ��ġ ������ 
    // model Ŭ������ ����ȭ
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
        // ó����ġ ����
        this.id = id;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.name);
        storyBoard.EnableCut(id);
    }
}
