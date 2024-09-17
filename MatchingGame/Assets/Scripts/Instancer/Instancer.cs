using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    private int num;

    public void CreateInstance()
    {
        Instantiate(prefab);
    }

    public void CreateInstance(Vector3Data obj)
    {
        Instantiate(prefab, obj.value, Quaternion.identity);
    }

    public void CreateInstanceFromList(Vector3DataList obj)
    {
        if (obj.Vector3Datas == null || obj.Vector3Datas.Count == 0) {
            return; }

        foreach (var t in obj.Vector3Datas) {
            Instantiate(prefab, t.value, Quaternion.identity); }
    }

    public void CreateInstanceFromListCounting(Vector3DataList obj)
    {
        if (obj.Vector3Datas == null || obj.Vector3Datas.Count == 0) {
            return; }

        // Ensure 'num' is within the bounds of the list
        if (num < 0 || num >= obj.Vector3Datas.Count) {
            num = 0; }

        Instantiate(prefab, obj.Vector3Datas[num].value, Quaternion.identity);

        num++;

        // Loop the index back to 0 if we reach the end of the list
        if (num >= obj.Vector3Datas.Count) {
            num = 0; }
    }
    
    public void CreateInstanceListRandomly(Vector3DataList obj)
    {
        num = Random.Range(0, obj.Vector3Datas.Count - 1);

        Instantiate(prefab, obj.Vector3Datas[num].value, Quaternion.identity);
    }
}