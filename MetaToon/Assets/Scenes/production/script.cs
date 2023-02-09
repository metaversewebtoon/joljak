using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject scroll_background;
    public GameObject scroll_element;
    public GameObject scroll_character;
    public GameObject scroll_pose;
    public GameObject scroll_look;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ScrollInactive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ScrollInactive()
    {
        scroll_background.SetActive(false);
        scroll_element.SetActive(false);
        scroll_character.SetActive(false);
        scroll_pose.SetActive(false);
        scroll_look.SetActive(false);
    }


    // ��ư Ŭ���� ��ũ�� ����
    public void ScrollActive()
    {
        ScrollInactive();

        // Ŭ���� ��ư �̸� ��������
        string buttonName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(0);
        print(buttonName);
        
        // Ŭ���� �ش� ��ư�� ��ũ�� ����
        if (buttonName.Equals("background"))
        {
            scroll_background.SetActive(true);
        }
        else if (buttonName.Equals("element"))
        {
            scroll_element.SetActive(true);
        }
        else if (buttonName.Equals("character"))
        {
            scroll_character.SetActive(true);
        }
        else if (buttonName.Equals("pose"))
        {
            scroll_pose.SetActive(true);
        }
        else if (buttonName.Equals("look"))
        {
            scroll_look.SetActive(true);
        }

    }




}
