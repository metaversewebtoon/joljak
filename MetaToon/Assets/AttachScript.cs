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
        doAttachScript(urlScript.avatarName[0]); // 아바타에 자세조정 스크립트 적용
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
            Debug.Log(name + " 아바타를 찾을 수 없음");
        }
    }
}
