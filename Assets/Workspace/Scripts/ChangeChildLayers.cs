using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChildLayers : MonoBehaviour
{
    private bool hasChangedChildren = false;

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.childCount > 0)
        {
            hasChangedChildren = true;
            ChangeLayersRecursively(this.transform, this.gameObject.layer);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasChangedChildren && this.transform.childCount > 0)
        {
            hasChangedChildren = true;
            ChangeLayersRecursively(this.transform, this.gameObject.layer);
        }
    }

    public static void ChangeLayersRecursively(Transform trans, int layerNum)
    {
        trans.gameObject.layer = layerNum;
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, layerNum);
        }
    }
}