using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectClickScript : MonoBehaviour
{

    void OnMouseDrag()
    {

    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("avatar"))
        {
            GameObject.Find("GameObject").GetComponent<lookScript>().avatar = gameObject;
        }
        GameObject.Find("GameObject").GetComponent<ObjectSize>().targetObject = gameObject;
        GameObject.Find("GameObject").GetComponent<ObjectMove>().targetObject = gameObject;

    }
    
}



