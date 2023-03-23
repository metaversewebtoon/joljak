using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 클릭한 버튼 이름 추출 함수
    public string ButtonName(int a)
    {
        // 클릭한 버튼 오브젝트의 이름 저장
        string objectName = EventSystem.current.currentSelectedGameObject.name;

        print("버튼 클릭");
        print("버튼 이름: " + objectName);

        if (a == 0)
        {
            // 버튼 이름을 '_' 기준으로 자르기
            int strIndex = objectName.LastIndexOf('_');
            string buttonName = objectName.Substring(strIndex + 1);

            return buttonName;
        }

        else
        {
            return objectName;
        }

        
    }


    // 씬 변환 함수
    public void SceneChange()
    {
        string sceneName = ButtonName(0);

        // 씬 변환
        SceneManager.LoadScene(sceneName);
    }
}
