using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cut : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	RectTransform rectTransform;
	CanvasGroup canvasGroup;
	[SerializeField] Canvas canvas;



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
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    // Update is called once per frame
    
}
