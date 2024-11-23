using System.Collections;
using UnityEngine;

public class MaterialTransparencyLooper : MonoBehaviour
{
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private static readonly int Mode = Shader.PropertyToID("_Mode");
    private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
    private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
    private static readonly int ZWrite = Shader.PropertyToID("_ZWrite");
    public Renderer targetRenderer;
    public float fadeDuration = 2f;

    private Material targetMaterial;

    private void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Target Renderer is not assigned.");
            return;
        }
        // End of if

        targetMaterial = targetRenderer.material;

        SetMaterialToTransparent(targetMaterial);

        StartCoroutine(FadeLoop());
    }
    // End of Start

    private IEnumerator FadeLoop()
    {
        while (true)
        {
            // Fade out to full transparency
            yield return StartCoroutine(Fade(1f, 0f));
            // Fade in to full opacity
            yield return StartCoroutine(Fade(0f, 1f));
        }
        // End of while
    }
    // End of FadeLoop

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color initialColor = targetMaterial.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            targetMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // End of while

        targetMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, endAlpha);
    }
    // End of Fade

    private void SetMaterialToTransparent(Material material)
    {
        if (material.HasProperty(Color1))
        {
            material.SetFloat(Mode, 3);
            material.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt(ZWrite, 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;
        }
        // End of if
    }
    // End of SetMaterialToTransparent
}