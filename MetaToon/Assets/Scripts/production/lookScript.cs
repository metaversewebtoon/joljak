using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookScript : MonoBehaviour
{
    public GameObject avatar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LookAply()
    {
        string lookName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);
        Animator animator = avatar.GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load(lookName, typeof(RuntimeAnimatorController)));

        // 만약 캐릭터 선택 전에 표정 선택시 알림 메시지 
    }
}
