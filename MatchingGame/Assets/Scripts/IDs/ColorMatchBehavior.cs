using System;
using UnityEngine;

public class ColorMatchBehavior : MatchBehavior
{
    public ColorIDList colorIDDataListObj;

    private void Awake()
    {
        idObj = colorIDDataListObj.currentColor;
    }

    public void ChangeColor(MeshRenderer renderer)
    {
        var newColor = idObj as ColorID;
        renderer.material.color = newColor.value;
    }
}
