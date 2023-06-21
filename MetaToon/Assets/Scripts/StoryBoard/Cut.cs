using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cut : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{

	RectTransform rectTransform;
	CanvasGroup canvasGroup;

    public Vector2 pos
	{
		get
		{
            return transform.localPosition;
		}
		set
		{
            transform.localPosition = value;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}
    void Update()
    {
    }

    public void init(uint cutNum)
	{
        //this.enabled = false;
        transform.position = new Vector2(0.0f, -500.0f * cutNum);
	}
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }



    public void OnDrag(PointerEventData eventData)
    {
        // ���� �̵��� ���ؼ� �󸶳� �̵��ߴ����� ������
        // ĵ������ �����ϰ� ����� �ϱ� ������
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

	public void OnPointerClick(PointerEventData eventData)
	{
        this.gameObject.SetActive(false);
        Debug.Log(transform.localPosition);
	}



	// Update is called once per frame

}
