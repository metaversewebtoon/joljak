using System.Collections;
using System.Collections.Generic;
using SA;
using UnityEngine;

public class AttachScript : MonoBehaviour
{
    URL urlScript;

    public void OnClick()
    {
        urlScript = GameObject.Find("InputURL").GetComponent<URL>();
        Debug.Log("Attaching FullBodyIKBehaviour Script to Avatar");
        doAttachScript(urlScript.avatarName[0]); // �ƹ�Ÿ�� �ڼ����� ��ũ��Ʈ ����
    }
    public void doAttachScript(string name)
    {
        GameObject obj = GameObject.Find(name);
        if (obj)
        {
            obj.AddComponent<FullBodyIKBehaviour>();
        }
        else
        {
            Debug.Log(name + " �ƹ�Ÿ�� ã�� �� ����");
        }
    }
}
