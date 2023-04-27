using ReadyPlayerMe;
using UnityEngine;
using TMPro;
using System;
using System.Collections;
using SA;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS4014

public class URL : MonoBehaviour
{
    public TMP_InputField urlInput;
    private string url = "";
    private string[] splitUrl;
    public string[] avatarName;

    public GameObject avatar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // 엔터 입력시
        {
            url = urlInput.GetComponent<TMP_InputField>().text;
            Debug.Log("URL has been entered");

            //URL로 부터 아바타 이름만 추출
            splitUrl = url.Split('/');
            avatarName = splitUrl[3].Split('.'); // avatarName[0] == 아바타 오브젝트 이름

            GetAvatar(); // 아바타 불러오기
        }
    }

    public async Task GetAvatar()
    {
        AvatarLoader avatarLoader = new AvatarLoader();
        //avatarLoader.OnCompleted += (_, args) => { avatar = args.Avatar; };
        await avatarLoader.LoadAvatar(url);
        Debug.Log(" [URL] Complete Loading Avatar");

        doAttachScript(avatarName[0]); // 아바타에 자세조정 스크립트 적용
        Debug.Log(" [URL] Complete Attaching FullBodyIKBehaviour Script to Avatar");
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

    private void OnDestroy()
    {
        if (avatar != null) Destroy(avatar);
    }
}