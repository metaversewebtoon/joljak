using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectSize : MonoBehaviour
{
    public GameObject targetObject;
    public Slider slider_x;
    public Slider slider_y;
    public Slider slider_z;
    float slider_value;
    public GameObject size_ui;


    public void sizeXControl()
    {
        if (targetObject.transform.localScale.x >= 0)
        {
            if (slider_x.value > slider_value)
            {
                targetObject.transform.localScale += new Vector3(0.5f, 0, 0);
            }
            else if (slider_x.value < slider_value)
            {
                if (targetObject.transform.localScale.x != 0)
                {
                    targetObject.transform.localScale -= new Vector3(0.5f, 0, 0);
                }
            }
        }
        slider_value = slider_x.value;
    }

    public void sizeYControl()
    {
        if (targetObject.transform.localScale.y >= 0)
        {
            if (slider_y.value > slider_value)
            {
                targetObject.transform.localScale += new Vector3(0, 0.5f, 0);
            }
            else if (slider_y.value < slider_value)
            {
                if (targetObject.transform.localScale.y != 0)
                {
                    targetObject.transform.localScale -= new Vector3(0, 0.5f, 0);
                }
            }
        }
        slider_value = slider_y.value;
    }

    public void sizeZControl()
    {
        if (targetObject.transform.localScale.z >= 0)
        {
            if (slider_z.value > slider_value)
            {
                targetObject.transform.localScale += new Vector3(0, 0, 0.5f);
            }
            else if (slider_z.value < slider_value)
            {
                if (targetObject.transform.localScale.z != 0)
                {
                    targetObject.transform.localScale -= new Vector3(0, 0, 0.5f);
                }
            }
        }
        slider_value = slider_z.value;
    }


    public void sizeControlOff()
    {
        slider_x.value = 5.0f;
        slider_y.value = 5.0f;
        slider_z.value = 5.0f;
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



