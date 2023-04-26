using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    [SerializeField] private Button createAvatarButton;

    // Start is called before the first frame update
    void Start()
    {
        if (createAvatarButton != null)
        {
            createAvatarButton.onClick.AddListener(OnCreateAvatar);
        }
    }

    public void OnCreateAvatar()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        WebInterface.SetIFrameVisibility(true);
#endif
    }
}
