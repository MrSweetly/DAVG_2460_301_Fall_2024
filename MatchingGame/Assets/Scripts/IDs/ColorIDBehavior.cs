using UnityEngine;

public class ColorIDBehavior : IDContainerBehavior
{
    public ColorIDList colorIdDataListObj;

    private void Awake()
    {
        idObj = colorIdDataListObj.currentColor;
    }
}
