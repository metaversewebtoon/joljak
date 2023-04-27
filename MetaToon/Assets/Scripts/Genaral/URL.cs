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
        if (Input.GetKeyDown(KeyCode.Return)) // ���� �Է½�
        {
            url = urlInput.GetComponent<TMP_InputField>().text;
            Debug.Log("URL has been entered");

            //URL�� ���� �ƹ�Ÿ �̸��� ����
            splitUrl = url.Split('/');
            avatarName = splitUrl[3].Split('.'); // avatarName[0] == �ƹ�Ÿ ������Ʈ �̸�

            GetAvatar(); // �ƹ�Ÿ �ҷ�����
        }
    }

    public async Task GetAvatar()
    {
        AvatarLoader avatarLoader = new AvatarLoader();
        //avatarLoader.OnCompleted += (_, args) => { avatar = args.Avatar; };
        await avatarLoader.LoadAvatar(url);
        Debug.Log(" [URL] Complete Loading Avatar");

        doAttachScript(avatarName[0]); // �ƹ�Ÿ�� �ڼ����� ��ũ��Ʈ ����
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
            Debug.Log(name + " �ƹ�Ÿ�� ã�� �� ����");
        }
    }

    private void OnDestroy()
    {
        if (avatar != null) Destroy(avatar);
    }
}