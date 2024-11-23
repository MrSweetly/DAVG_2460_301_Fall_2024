using System.Collections;
using UnityEngine;

public class MaterialTransparencyLooper : MonoBehaviour
{
    public Renderer targetRenderer; // Assign the object's Renderer in the Inspector
    public float fadeDuration = 2f; // Time it takes to fade in or out

    private Material targetMaterial;

    private void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Target Renderer is not assigned.");
            return;
        }

        // Get the material from the Renderer
        targetMaterial = targetRenderer.material;

        // Ensure the material is in Transparent mode
        SetMaterialToTransparent(targetMaterial);

        // Start the fade loop coroutine
        StartCoroutine(FadeLoop());
    }

    private IEnumerator FadeLoop()
    {
        while (true) // Infinite loop
        {
            // Fade out to full transparency
            yield return StartCoroutine(Fade(1f, 0f));
            // Fade in to full opacity
            yield return StartCoroutine(Fade(0f, 1f));
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color initialColor = targetMaterial.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            targetMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is set to the exact target at the end
        targetMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, endAlpha);
    }

    private void SetMaterialToTransparent(Material material)
    {
        if (material.HasProperty("_Color"))
        {
            material.SetFloat("_Mode", 3); // 3 = Transparent in Standard Shader
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;
        }
    }
}