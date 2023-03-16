using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스크립트 이름 바꾸기 drag->object click
public class objectClickScript : MonoBehaviour
{
    public GameObject interface_;

    float distance = 10;

    void start()
    {
        
    }

    void update()
    {
    
    }

    void OnMouseDrag()
    {
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.position = objPosition;
    }

    void OnMouseDown()
    {

        interface_ = GameObject.Find("Canvas").transform.Find("interface").gameObject;

        Invoke("InterfaceActive", 0.2f);

        if (gameObject.CompareTag("avatar"))
        {
            GameObject.Find("GameObject").GetComponent<lookScript>().avatar = gameObject;
        }
        GameObject.Find("GameObject").GetComponent<objectControl>().objectName = gameObject;

    }
    
    void InterfaceActive()
    {
        interface_.SetActive(true);
    }


    public void InterfaceInActive()
    {
        interface_.SetActive(false);
    }

}



