using ReadyPlayerMe;
using UnityEngine;
using TMPro;
using System;
using System.Collections;
using SA;
using System.Threading;
using System.Threading.Tasks;

public class URL : MonoBehaviour
{
    public TMP_InputField urlInput;
    private string url = "";
    private string[] splitUrl;
    public string[] avatarName;

    public GameObject avatar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            url = urlInput.GetComponent<TMP_InputField>().text;
            Debug.Log("URL has been entered");

            splitUrl = url.Split('/');
            avatarName = splitUrl[3].Split('.'); // avatarName[0] == 아바타 오브젝트 이름

            GetAvatar(); // 아바타 불러오기
        }
    }

    public void GetAvatar()
    {
        AvatarLoader avatarLoader = new AvatarLoader();
        //avatarLoader.OnCompleted += (_, args) => { avatar = args.Avatar; };
        avatarLoader.LoadAvatar(url);
        Debug.Log("아바타 로드");
    }

    private void OnDestroy()
    {
        if (avatar != null) Destroy(avatar);
    }
}