using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectSize : MonoBehaviour
{
    public GameObject targetObject;
    public Slider slider;
    float slider_value;
    public GameObject size_ui;



    public void sizeControl()
    {
        if (targetObject.transform.localScale.x >= 0)
        {
            if (slider.value > slider_value)
            {
                targetObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (slider.value < slider_value)
            {
                if (targetObject.transform.localScale.x != 0)
                {
                    targetObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                }
            }
        }
        slider_value = slider.value;
    }


    public void sizeControlOff()
    {
        slider.value = 5.0f;
    }

    public void sizeUiActive()
    {
        GameObject.Find("GameObject").GetComponent<ObjectMove>().isButtonClick = false;
        GameObject.Find("GameObject").GetComponent<ObjectRotation>().rotUiInActive();

        if (targetObject != null)
        {
            size_ui.SetActive(true);
        }
            
    }

    public void sizeUiInActive()
    {
        size_ui.SetActive(false);
    }

}



