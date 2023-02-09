using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Ŭ���� ��ư �̸� ���� �Լ�
    public string ButtonName(int a)
    {
        // Ŭ���� ��ư ������Ʈ�� �̸� ����
        string objectName = EventSystem.current.currentSelectedGameObject.name;

        print("��ư Ŭ��");
        print("��ư �̸�: " + objectName);

        if (a == 0)
        {
            // ��ư �̸��� '_' �������� �ڸ���
            int strIndex = objectName.LastIndexOf('_');
            string buttonName = objectName.Substring(strIndex + 1);

            return buttonName;
        }

        else
        {
            return objectName;
        }

        
    }


    // �� ��ȯ �Լ�
    public void SceneChange()
    {
        string sceneName = ButtonName(0);

        // �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }
}
