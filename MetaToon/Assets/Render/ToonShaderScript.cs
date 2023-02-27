using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class ToonShaderScript : MonoBehaviour
{
    // Choose a shader to use from inspector menu
    public Shader replacementShader;

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        // replacementShader : The shader to use for every game object captured through camera.
        // "" : Render type tag(e.g. Opaque, Transparent). Empty by default.
        cam.SetReplacementShader(replacementShader, "");
    }
}