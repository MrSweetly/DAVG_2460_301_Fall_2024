using UnityEngine;
using HoudiniEngineUnity;

public class StarPulse : MonoBehaviour
{
    public HEU_HoudiniAsset myStarAsset;

    public float pulseSpeed = 1f;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    private float evenScale;
    private float oddScale;
    private float time;

    void Update()
    {
        time += Time.deltaTime * pulseSpeed;

        evenScale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(time, 1f));
        oddScale = Mathf.Lerp(maxScale, minScale, Mathf.PingPong(time, 1f));

        // Check if the asset is valid and ready to have parameters updated
        if (myStarAsset != null && myStarAsset.Parameters != null)
        {
            // Set the parameter values for Even_Point_Scale and Odd_Point_Scale
            myStarAsset.Parameters.SetFloatParameterValue("scale2", evenScale);
            myStarAsset.Parameters.SetFloatParameterValue("scale3", oddScale);

            // Request the HDA to recook with updated parameters
            myStarAsset.RequestCook(true, false, true, true);
        }
    }
}