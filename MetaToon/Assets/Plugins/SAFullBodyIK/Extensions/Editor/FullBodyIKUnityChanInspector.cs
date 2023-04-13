// Copyright (c) 2016 Nora
// Released under the "Unity-Chan" license
// http://unity-chan.com/contents/license_en/
// http://unity-chan.com/contents/license_jp/

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using EditorUtil = SA.FullBodyIKEditorUtility;
#endif
using System.Collections.Generic;


namespace SA
{
#if UNITY_EDITOR
	[CustomEditor( typeof( SA.FullBodyIKUnityChanBehaviour ) )]
	public class FullBodyIKUnityChanInspector : FullBodyIKInspectorBase
	{
	}
#endif
}
