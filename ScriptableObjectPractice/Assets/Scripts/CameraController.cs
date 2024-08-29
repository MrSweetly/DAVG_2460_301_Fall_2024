using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3Data cameraSettings;

    void Start()
    {
        // At Start, move camera to a specified point
        Camera.main.transform.position = cameraSettings.cameraPosition;
        Camera.main.transform.eulerAngles = cameraSettings.cameraRotation;
    }
}
