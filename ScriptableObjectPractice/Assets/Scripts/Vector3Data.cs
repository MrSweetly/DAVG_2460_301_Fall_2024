using UnityEngine;

[CreateAssetMenu(menuName = "CameraSettings", fileName = "NewCameraSettings", order = 1)]
public class Vector3Data : ScriptableObject
{
    // Saved Camera position
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;
}
