using ReadyPlayerMe;
using UnityEngine;

public class WebAvatarLoader : MonoBehaviour
{
    private const string TAG = nameof(WebAvatarLoader);
    private GameObject avatar;
    private string avatarUrl = "";
    private string[] splitUrl;
    public string[] avatarName;

    private void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        PartnerSO partner = Resources.Load<PartnerSO>("Partner");
        
        WebInterface.SetupRpmFrame(partner.Subdomain);
#endif
    }
    
    public async void OnWebViewAvatarGeneratedAsync(string generatedUrl)
    {
        var avatarLoader = new AvatarLoader();
        avatarUrl = generatedUrl;
        splitUrl = avatarUrl.Split('/');
        avatarName = splitUrl[3].Split('.');
        avatarLoader.OnCompleted += OnAvatarLoadCompleted;
        avatarLoader.OnFailed += OnAvatarLoadFailed;
        await avatarLoader.LoadAvatar(avatarUrl);
        doAttachScript(avatarName[0]); // 아바타에 자세조정 스크립트 적용
    }

    public void doAttachScript(string name)
    {
        GameObject obj = GameObject.Find(name);
        if (obj)
        {
            obj.AddComponent<SA.FullBodyIKBehaviour>();
        }
        else
        {
            Debug.Log(name + " 아바타를 찾을 수 없음");
        }
    }

    private void OnAvatarLoadCompleted(object sender, CompletionEventArgs args)
    {
        //if (avatar) Destroy(avatar);
        avatar = args.Avatar;
    }

    private void OnAvatarLoadFailed(object sender, FailureEventArgs args)
    {
        SDKLogger.Log(TAG,$"Avatar Load failed with error: {args.Message}");
    }
}
