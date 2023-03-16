using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class objectControl : MonoBehaviour
{
    public GameObject objectName;
    public Slider slider_x;
    public Slider slider_y;
    public Slider slider_z;
    float slider_value;

    public void PosControl()
    {
        //GameObject sliderName = EventSystem.current.currentSelectedGameObject;
        



    }

    public void PosXControl()
    {
        if (objectName.transform.localScale.x >= 0)
        {
            if (slider_x.value > slider_value)
            {
                objectName.transform.localScale += new Vector3(1, 0, 0);
            }
            else if (slider_x.value < slider_value)
            {
                if (objectName.transform.localScale.x != 0)
                {
                    objectName.transform.localScale -= new Vector3(1, 0, 0);
                }
            }
        }
        slider_value = slider_x.value;
    }

    public void PosYControl()
    {
        if (objectName.transform.localScale.y >= 0)
        {
            if (slider_y.value > slider_value)
            {
                objectName.transform.localScale += new Vector3(0, 1, 0);
            }
            else if (slider_y.value < slider_value)
            {
                if (objectName.transform.localScale.y != 0)
                {
                    objectName.transform.localScale -= new Vector3(0, 1, 0);
                }
            }
        }
        slider_value = slider_y.value;
    }

    public void PosZControl()
    {
        if (objectName.transform.localScale.z >= 0)
        {
            if (slider_z.value > slider_value)
            {
                objectName.transform.localScale += new Vector3(0, 0, 1);
            }
            else if (slider_z.value < slider_value)
            {
                if (objectName.transform.localScale.z != 0)
                {
                    objectName.transform.localScale -= new Vector3(0, 0, 1);
                }
            }
        }
        slider_value = slider_z.value;
    }



    public void PosControlOff()
    {
        slider_x.value = 5.0f;
        slider_y.value = 5.0f;
        slider_z.value = 5.0f;
    }


}



