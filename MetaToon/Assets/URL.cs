using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class URL : MonoBehaviour
{
    public TMP_InputField urlInput;
    private string url = "";

    private GameObject avatar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            url = urlInput.GetComponent<TMP_InputField>().text;
            Debug.Log("URL has been entered");
            GetAvatar();
        }
    }

    public void GetAvatar()
    {
        AvatarLoader avatarLoader = new AvatarLoader();
        //avatarLoader.OnCompleted += (_, args) => { avatar = args.Avatar; };
        avatarLoader.LoadAvatar(url);
    }

    private void OnDestroy()
    {
        if (avatar != null) Destroy(avatar);
    }
}
