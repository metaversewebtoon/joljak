using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
    public GameObject rot_ui;
    public GameObject targetObject; // 회전시킬 오브젝트
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;

    // 슬라이드 변경 전 값
    float preXvalue;// = 5.0f;
    float preYvalue;// = 5.0f;
    float preZvalue;// = 5.0f;

    // 슬라이드 변경 후 값 - 변경 전 값
    float xRotation;
    float yRotation;
    float zRotation;

    public void objectRotate()
    {
        // 오브젝트의 기존 회전 값
        Vector3 eulerRotation = targetObject.transform.eulerAngles;

        // 오브젝트의 변경 후 회전 값
        float xNewRotation = eulerRotation.x + xRotation*10;
        float yNewRotation = eulerRotation.y + yRotation*10;
        float zNewRotation = eulerRotation.z + zRotation*10;
        Debug.Log("변경 후: " + xNewRotation);

        // 오브젝트의 회전을 조정
        targetObject.transform.rotation = Quaternion.Euler(xNewRotation, yNewRotation, zNewRotation);
    }
    
    public void XRotate()
    {
        xRotation = xSlider.value - 5.0f - preXvalue;
        objectRotate();
        preXvalue = xSlider.value - 5.0f;

    }

    public void YRotate()
    {
        yRotation = ySlider.value - 5.0f - preYvalue;
        objectRotate();
        preYvalue = ySlider.value - 5.0f;
    }

    public void ZRotate()
    {
        zRotation = zSlider.value - 5.0f - preZvalue;
        objectRotate();
        preZvalue = zSlider.value - 5.0f;
    }
    


    public void rotateOff()
    {
        preXvalue = 0.0f;
        preYvalue = 0.0f;
        preZvalue = 0.0f;

        xSlider.value = 5.0f;
        ySlider.value = 5.0f;
        zSlider.value = 5.0f;
    }

    public void rotUiActive()
    {
        GameObject.Find("GameObject").GetComponent<ObjectMove>().isButtonClick = false;
        GameObject.Find("GameObject").GetComponent<ObjectSize>().sizeUiInActive();

        if (targetObject != null)
        {
            rot_ui.SetActive(true);
        }
    }

    public void rotUiInActive()
    {
        rot_ui.SetActive(false);
    }



    /*
    public float sensitivity = 1.0f; // 회전 감도
    private Vector3 lastMousePosition; // 이전 마우스 위치
    public GameObject rot_ui;


    void Start()
    {
        targetObject = GameObject.Find("GameObject").GetComponent<ObjectRotation>().targetObject;
        //rot_ui = GameObject.Find("ui_3d").transform.Find("rot_ui").gameObject;
    }

    void Update()
    {
        if (gameObject.activeSelf && targetObject != null)
        {
             rot_ui.transform.position = targetObject.transform.position;
        }
    }

    // 드래그 중일 때 호출되는 함수
    public void OnMouseDrag()
    {
        // 현재 마우스 위치와 이전 마우스 위치의 차이를 구함
        Vector3 delta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;

        // 회전 각도를 구함
        float angle = delta.magnitude * sensitivity;

        // 회전 축을 구함
        Vector3 axis = Vector3.Cross(delta.normalized, Camera.main.transform.forward);

        // 회전 중심 변경
        Vector3 pivot = targetObject.transform.position + new Vector3(0, 1, 0);

        // 회전
        targetObject.transform.Rotate(axis, angle, Space.World);    

    }

    // 마우스 버튼을 누르면 호출되는 함수
    public void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
    }
    
    public void rotUiActive()
    {
        GameObject.Find("GameObject").GetComponent<ObjectMove>().isButtonClick=false;
        GameObject.Find("GameObject").GetComponent<ObjectSize>().sizeUiInActive();

        if (targetObject != null)
        {
            rot_ui.SetActive(true);
        }
    }

    public void rotUiInActive()
    {
        rot_ui.SetActive(false);
    }

    */



}
