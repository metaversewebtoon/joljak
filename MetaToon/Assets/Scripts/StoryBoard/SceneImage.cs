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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector2 localposition, int imageNumber)
	{
        // ó����ġ ����
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.name);
    }
}
