using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ToonShaderScript : MonoBehaviour
{
    public Shader EffectShader; // assign your custom shader in inspector

    void Start()
    {
        // replace all shaders with EffectShader that have "RenderType" tag
        Camera.main.SetReplacementShader(EffectShader, "Opaque");
    }
}