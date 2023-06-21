using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

public class AttachControlTarget : MonoBehaviour
{
    private PoseTable _poseTable;

    private List<Transform> _controlTargetList;
    private List<Transform> _boneList;

    private FullBodyIK _fullbodyik;
    private ControlObject _controlObject;
    // Start is called before the first frame update
    void Start()
    {
        _poseTable = Resources.Load<PoseTable>($"Tables/PoseTable");
        _fullbodyik = this.gameObject.GetComponent<FullBodyIKBehaviour>().fullBodyIK;
        _controlObject = new ControlObject();
        _controlObject.SetControlObjectsTransform(_fullbodyik, _poseTable.controlPrefab, this.transform);


    }

    // Update is called once per frame
    void Update()
    {
        SyncPosition();
    }

    private void SyncPosition()
	{
        _fullbodyik.headEffectors.head.transform.position = _controlObject.head.position;
        _fullbodyik.leftArmEffectors.wrist.transform.position = _controlObject.leftWrist.position;
        _fullbodyik.rightArmEffectors.wrist.transform.position= _controlObject.rightWrist.position;
        _fullbodyik.leftLegEffectors.foot.transform.position= _controlObject.leftFoot.position;
        _fullbodyik.rightLegEffectors.foot.transform.position= _controlObject.rightFoot.position;
    }
}
