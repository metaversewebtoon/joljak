using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cut : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{

    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    KeyState keystate;
    float scaleWeight;

    enum KeyState  { scale, position };
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
        scaleWeight = 0.0001f;
        keystate = KeyState.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            keystate = KeyState.scale;
        if (Input.GetKeyUp(KeyCode.Space))
            keystate = KeyState.position;
    }

    public void init(uint cutNum)
	{
        //this.enabled = false;
        transform.position = new Vector2(0.0f, -500.0f * cutNum);
        keystate = KeyState.position;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        switch(keystate)
		{
            case KeyState.position:
            case KeyState.scale:
                canvasGroup.alpha = .6f;
                canvasGroup.blocksRaycasts = false;
                break;
        }
        
    }



    public void OnDrag(PointerEventData eventData)
    {
        switch (keystate)
        {
            case KeyState.position:
                rectTransform.anchoredPosition += eventData.delta;
                break;
            case KeyState.scale:
                rectTransform.sizeDelta  += (eventData.delta);
                break;

        }
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        switch (keystate)
        {
            case KeyState.position:
            case KeyState.scale:
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                break;
        }
        
    }

	public void OnPointerClick(PointerEventData eventData)
	{
        this.gameObject.SetActive(false);
        Debug.Log(transform.localPosition);
	}



	// Update is called once per frame

}
