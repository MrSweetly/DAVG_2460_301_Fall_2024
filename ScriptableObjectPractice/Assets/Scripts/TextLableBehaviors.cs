using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLableBehaviors : MonoBehaviour
{
    public Text label;
    public FloatData dataObj;

    private void Start()
    {
        label = GetComponent<Text>();
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
