using RoR2;
using RoR2.UI;
using RuntimeInspectorNamespace;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIHierarchyPing : MonoBehaviour
{
    public RuntimeHierarchy hierarchy;

    private Transform currentSelection;
    private GameObject lastPing;
    private GameObject indicator;

    private void Start()
    {
        hierarchy.OnSelectionChanged += SetPing;
    }

    private GameObject GetInstance()
    {
        if (indicator != null)
            return indicator;

        indicator = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/PositionIndicators/PoiPositionIndicator"));
        return indicator;
    }

    public void SetPing(Transform t)
    {
        var indicator = GetInstance();
        indicator.transform.parent = t;
        indicator.transform.position = t.position;
        indicator.transform.rotation = t.rotation;

        indicator.GetComponent<PositionIndicator>().targetTransform = t;
    }
}
