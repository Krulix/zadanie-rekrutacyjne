using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodRenderer : MonoBehaviour
{
    public List<GameObject> rodList;
    public int lastRod;

    public Transform rodParent;
    
    public void ChangeRod()
    {
        if(rodParent.childCount > 0)
        {
            ClearChildren();
        }
        lastRod++;
        lastRod = lastRod % 2;
        GameObject newRod = Instantiate(rodList[lastRod]);
        newRod.transform.SetParent(rodParent);
        newRod.transform.localPosition = Vector3.zero;
        newRod.transform.localRotation = Quaternion.EulerAngles(Vector3.zero);
    }

    private void ClearChildren()
    {
        while (rodParent.childCount > 0)
        {
            Transform child = rodParent.GetChild(0);
            DestroyImmediate(child.gameObject);
        }
    }
}
