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
        // Ŭ���� ��ư �̸� ����
        string lookName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);

        // �ƹ�Ÿ�� �ִϸ����� ��Ʈ�ѷ� �߰�
        Animator animator = avatar.GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lookAnimator", typeof(RuntimeAnimatorController)));
        
        // �ִϸ��̼� Ŭ�� ����
        animator.Play(lookName);


        // ���� ĳ���� ���� ���� ǥ�� ���ý� �˸� �޽��� 
    }
}
