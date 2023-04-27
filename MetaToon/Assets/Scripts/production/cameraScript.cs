using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameraScript : MonoBehaviour
{
	public float rotateSpeed = 500.0f;
	public float scrollSpeed = 10.0f;
	float dragSpeed = 30.0f;
	private float xRotate, yRotate, xRotateMove, yRotateMove;
	LayerMask layerMask;
	bool isAlt;
	Vector2 clickPoint;

	GameObject hitObject;

	private Transform _lookTarget;

	private Vector3 _lookVec;
	private float _distance = 10.0f;

	private bool _isDrag = false;

	private void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt)) isAlt = true;
		if (Input.GetKeyUp(KeyCode.LeftAlt)) isAlt = false;
		if (Input.GetMouseButtonDown(0)) clickPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		// ���콺 ���� ��ư�� Ŭ���� ��
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			// ��ũ�� ��Ȱ��ȭ
			GameObject.Find("GameObject").GetComponent<scrollScript>().ScrollInactive();
			_isDrag = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���� ���콺 ��ġ���� Ray ����

			RaycastHit hit;
			// Ray�� �浹�� ��ü�� �ν��� ��� ������Ʈ ����
			if (Physics.Raycast(ray, out hit) && hit.transform.name.Contains("avatar"))
			{
				hitObject = hit.collider.gameObject;

				_lookVec = Vector3.Normalize(hitObject.transform.position - this.transform.position);
				_distance = Vector3.Distance(hitObject.transform.position, this.transform.position);

				Debug.Log("�νĵ� ��ü: " + hitObject.name);
				if (hitObject.layer != LayerMask.NameToLayer("UI"))
				{
					objectClick();
				}
			}
			// �νĵ� ��ü�� ���� ��� ī�޶� ����

		}
		if (Input.GetMouseButton(0))
		{
			objectClickNo();
			// AltŰ ���� ��� ī�޶� �̵�
			if (isAlt)
			{
				Vector3 position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

				position.z = position.y;
				position.y = .0f;

				Vector3 move = position * (Time.deltaTime * dragSpeed);

				transform.Translate(move);
			}
			// AltŰ ������ ���� ��� ī�޶� ȸ��
			else
			{
				xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
				yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

				yRotate = transform.eulerAngles.y + yRotateMove;

				xRotate = xRotate + xRotateMove;

				xRotate = Mathf.Clamp(xRotate, -90, 90); // ��, �Ʒ� ����

				transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
			}
			// ���� �ܾƿ�
			if (hitObject)
			{
				MouseScrollEvent();
			}
			else
			{
				float scroollWheel = Input.GetAxis("Mouse ScrollWheel");
				Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + scroollWheel * Time.deltaTime * scrollSpeed);
				this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 1);
			}
		}
	}

	void objectClick()
	{
		if (hitObject.layer == LayerMask.NameToLayer("avatar"))
		{
			GameObject.Find("GameObject").GetComponent<lookScript>().avatar = hitObject;
		}
		GameObject.Find("GameObject").GetComponent<ObjectMove>().targetObject = hitObject;
		GameObject.Find("GameObject").GetComponent<ObjectRotation>().targetObject = hitObject;
		GameObject.Find("GameObject").GetComponent<ObjectSize>().targetObject = hitObject;
	}

	void objectClickNo()
	{
		GameObject.Find("GameObject").GetComponent<lookScript>().avatar = null;
		GameObject.Find("GameObject").GetComponent<ObjectMove>().targetObject = null;
		GameObject.Find("GameObject").GetComponent<ObjectRotation>().targetObject = null;
		GameObject.Find("GameObject").GetComponent<ObjectSize>().targetObject = null;

		GameObject.Find("GameObject").GetComponent<ObjectMove>().isButtonClick = false;
		GameObject.Find("GameObject").GetComponent<ObjectSize>().sizeUiInActive();
		GameObject.Find("GameObject").GetComponent<ObjectRotation>().rotUiInActive();
	}

	private void MouseScrollEvent()
	{
		Vector2 scrollDelta = Input.mouseScrollDelta;
		Vector3 targetPos = this.transform.position + _lookVec * scrollDelta.y * Time.deltaTime * scrollSpeed;
		this.transform.position = targetPos;
	}

}
