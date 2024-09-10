using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshBehavior : MonoBehaviour
{
    private MeshRenderer rendererObj;

    private void Start()
    {
        rendererObj = GetComponent<MeshRenderer>();
    }

    public void ChangeRendererColor(ColorID obj)
    {
        rendererObj.material.color = obj.value;
    }
}
