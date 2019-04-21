using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementMover : MonoBehaviour
{
    public UIElementDragger dragger;

    private Vector2 offset;

    void Start()
    {
        dragger.OnDragStart += (sender, evt) => {
            offset = transform.position - (Vector3)evt.position;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (dragger.Dragging)
        {
            transform.position = offset + (Vector2)Input.mousePosition;
        }
    }
}
