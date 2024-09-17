using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorIDList : ScriptableObject
{
    public List<ColorID> colorIDList;
    public ColorID currentColor;

    private int num;

    public void SetCurrentColorRandomly()
    {
        currentColor = colorIDList[num];
        num = Random.Range(0, colorIDList.Count);
    }
}
