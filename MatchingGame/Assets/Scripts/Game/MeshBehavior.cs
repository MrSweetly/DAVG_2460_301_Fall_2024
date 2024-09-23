using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshBehavior : MonoBehaviour
{
    private MeshRenderer rendererObj;

    private void Awake()
    {
        rendererObj = GetComponent<MeshRenderer>();
        
        if (rendererObj == null) {
            rendererObj = gameObject.AddComponent<MeshRenderer>(); }
    }
    public void ChangeRendererColor(ColorID obj)
    {
        rendererObj.material.color = obj.value;
    }

    public void ChangeRendererColor(ColorIDList obj)
    {
        obj.SetCurrentColorRandomly();
        rendererObj.material.color = obj.currentColor.value;
    }
}
