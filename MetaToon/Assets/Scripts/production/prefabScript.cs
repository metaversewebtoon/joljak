using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class prefabScript : MonoBehaviour
{

    private bool createmode;

    private string buttonName;
    private string prefabName;

    // Start is called before the first frame update
    void Start()
    {
        createmode = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Ray가 충돌한 물체를 인식한 경우 오브젝트 조정
            if (Physics.Raycast(ray, out hit) && createmode )
            {
                if(hit.transform.name.Contains("Terrain"))
				{
                    GameObject obj = Instantiate(Resources.Load<GameObject>(prefabName));
                    obj.transform.position = hit.point;
                    Debug.Log("벼튼 이름" + buttonName);
                    if (buttonName.Contains("avatar"))
                    {
                        obj.AddComponent<SA.FullBodyIKBehaviour>();
                        obj.AddComponent<AttachControlTarget>();

                    }
                    createmode = false;
                }
                
    
            }
        }
    }

    public void prefabCreate()
    {
        createmode = true;

        buttonName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);
        prefabName = buttonName + "_prefab";
    }
}
