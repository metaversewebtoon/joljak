using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookScript : MonoBehaviour
{
    string avatarName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(this.transform.position + Vector3.up, Vector3.forward * 10, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("avatar"))
                {
                    Debug.Log(hit.transform.name);
                    avatarName = hit.transform.name;
                }
                
                

            }
        }
    }

    public void LookAply()
    {
        string lookName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);
        Animator animator = GameObject.Find(avatarName).GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load(lookName, typeof(RuntimeAnimatorController)));


    }
}
