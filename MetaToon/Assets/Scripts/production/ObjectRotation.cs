using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
    public GameObject targetObject; // ȸ����ų ������Ʈ
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
}