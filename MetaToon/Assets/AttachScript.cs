using System.Collections;
using System.Collections.Generic;
using SA;
using UnityEngine;

public class AttachScript : MonoBehaviour
{
    URL urlScript;

    // Start is called before the first frame update
    public void OnClick()
    {
        urlScript = GameObject.Find("InputField (TMP)").GetComponent<URL>();
        Debug.Log("btn clicked");
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
