using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObject
{
    private Transform _head;
    private Transform _leftWrist;
    private Transform _rightWrist;
    private Transform _leftFoot;
    private Transform _rightFoot;

    public Transform head { get; set; }
    public Transform leftWrist { get; set; }
    public Transform rightWrist { get; set; }
    public Transform leftFoot { get; set; }
    public Transform rightFoot { get; set; }

    public void SetControlObjectsTransform(SA.FullBodyIK fk, GameObject prefab)
	{
        GameObject tempControlObject;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "HeadControl";
        head = tempControlObject.transform;
        head.position = fk.headEffectors.head.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "LeftWristControl";
        leftWrist = tempControlObject.transform;
        leftWrist.position = fk.leftArmBones.wrist.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "RightWristControl";
        rightWrist = tempControlObject.transform;
        rightWrist.position = fk.rightArmBones.wrist.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "LefFootControl";
        leftFoot = tempControlObject.transform;
        leftFoot.position = fk.leftLegBones.foot.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "RightFootControl";
        rightFoot = tempControlObject.transform;
        rightFoot.position = fk.rightLegBones.foot.transform.position;
    }
}
