using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class lookScript : MonoBehaviour
{

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LookApply()
    {
        string buttonName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);

        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load(buttonName, typeof(RuntimeAnimatorController)));
    }


}
