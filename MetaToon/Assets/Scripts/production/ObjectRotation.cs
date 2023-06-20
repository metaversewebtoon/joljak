using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
    public GameObject rot_ui;
    public GameObject targetObject; // ȸ����ų ������Ʈ
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;

    // �����̵� ���� �� ��
    float preXvalue;// = 5.0f;
    float preYvalue;// = 5.0f;
    float preZvalue;// = 5.0f;

    // �����̵� ���� �� �� - ���� �� ��
    float xRotation;
    float yRotation;
    float zRotation;

    public void objectRotate()
    {
        // ������Ʈ�� ���� ȸ�� ��
        Vector3 eulerRotation = targetObject.transform.eulerAngles;

        // ������Ʈ�� ���� �� ȸ�� ��
        float xNewRotation = eulerRotation.x + xRotation*10;
        float yNewRotation = eulerRotation.y + yRotation*10;
        float zNewRotation = eulerRotation.z + zRotation*10;
        Debug.Log("���� ��: " + xNewRotation);

        // ������Ʈ�� ȸ���� ����
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
    public float sensitivity = 1.0f; // ȸ�� ����
    private Vector3 lastMousePosition; // ���� ���콺 ��ġ
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

    // �巡�� ���� �� ȣ��Ǵ� �Լ�
    public void OnMouseDrag()
    {
        // ���� ���콺 ��ġ�� ���� ���콺 ��ġ�� ���̸� ����
        Vector3 delta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;

        // ȸ�� ������ ����
        float angle = delta.magnitude * sensitivity;

        // ȸ�� ���� ����
        Vector3 axis = Vector3.Cross(delta.normalized, Camera.main.transform.forward);

        // ȸ�� �߽� ����
        Vector3 pivot = targetObject.transform.position + new Vector3(0, 1, 0);

        // ȸ��
        targetObject.transform.Rotate(axis, angle, Space.World);    

    }

    // ���콺 ��ư�� ������ ȣ��Ǵ� �Լ�
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
