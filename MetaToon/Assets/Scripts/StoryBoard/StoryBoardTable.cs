using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryBoardTable", menuName = "Scriptable Objects/StoryBoardTable", order = int.MaxValue)]
public class StoryBoardTable : ScriptableObject
{
    public string serverIP;
    public string resourceDir;
    public string storyBoardDir;
    public string zipPath;
    public SceneImage sceneImagePrefab;
    public Cut cutPrefab;
}
