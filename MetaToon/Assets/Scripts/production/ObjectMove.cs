using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public GameObject targetObject; // �̵��� ������Ʈ
    public float moveSpeed = 5.0f; // �̵� �ӵ�
    public bool isButtonClick;

    void Update()
    {
        if (targetObject != null && isButtonClick == true)
        {
            // Ű���� �Է��� ����Ͽ� ������Ʈ �̵�
            float horizontal = 0.0f;
            float vertical = 0.0f;
            float depth = 0.0f;

            // X �� �̵�
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            // Z�� �̵�
            if (Input.GetKey(KeyCode.Q))
            {
                vertical = 1.0f; 
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                vertical = -1.0f; 
            }
            // Y�� �̵�
            if (Input.GetKey(KeyCode.W))
            {
                depth = 1.0f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                depth = -1.0f;
            }

            // �̵� ���� ���
            Vector3 moveDirection = new Vector3(horizontal, vertical, depth) * moveSpeed * Time.deltaTime;

            // �̵� ���͸� ���� ��ġ�� ���Ͽ� ������Ʈ �̵�
            targetObject.transform.position += moveDirection;
        }
        
    }

    public void buttonClick()
    {
        GameObject.Find("GameObject").GetComponent<ObjectSize>().sizeUiInActive();
        GameObject.Find("GameObject").GetComponent<ObjectRotation>().rotUiInActive();

        if (targetObject != null)
        {
            isButtonClick = true;
        }
        
    }

    public void MoveObject()
    {
        // ������Ʈ �̵� ���� ���
        //Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;

        // �̵� ���͸� ���� ��ġ�� ���Ͽ� ������Ʈ �̵�
        //targetObject.transform.position += moveDirection;
    }
}
