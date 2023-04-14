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
        // 클릭한 버튼 이름 추출
        string lookName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);

        // 아바타에 애니메이터 컨트롤러 추가
        Animator animator = avatar.GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lookAnimator", typeof(RuntimeAnimatorController)));
        
        // 애니메이션 클립 변경
        animator.Play(lookName);


        // 만약 캐릭터 선택 전에 표정 선택시 알림 메시지 
    }
}
