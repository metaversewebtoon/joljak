using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    void OnMouseDown()
    {

        //interface_ = GameObject.Find("Canvas").transform.Find("interface").gameObject;

        //Invoke("InterfaceActive", 0.2f);

        if (gameObject.CompareTag("avatar"))
        {
            GameObject.Find("GameObject").GetComponent<lookScript>().avatar = gameObject;
        }
        GameObject.Find("GameObject").GetComponent<objectControl>().objectName = gameObject;
        GameObject.Find("GameObject").GetComponent<ObjectMove>().targetObject = gameObject;

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



