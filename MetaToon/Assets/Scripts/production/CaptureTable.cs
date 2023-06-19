using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="CaptureTable",menuName ="Scriptable Objects/CaptureTable",order = int.MaxValue)]
public class CaptureTable : ScriptableObject
{
    public string dirName;
    public string fileName;
    public string serverIP;

}
