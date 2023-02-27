using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ToonShaderScript : MonoBehaviour
{
    public Shader replacementShader;
    public string replacementTag = "Opaque";

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.SetReplacementShader(replacementShader, replacementTag);
    }
}