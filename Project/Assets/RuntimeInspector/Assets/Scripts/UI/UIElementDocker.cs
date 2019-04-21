using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementDocker : MonoBehaviour
{
    public UIElementDragger dragger;

    private RectTransform rect;
    private Canvas canvas;
    private RectTransform canvasRect;

    private Vector2 previousSize;
    private Vector2 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        canvas = GetComponentInParent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Parent canvas could not be found.");
            return;
        }

        canvasRect = canvas.GetComponent<RectTransform>();

        if (dragger == null)
        {
            Debug.LogError("UIElementDragger dragger was null.");
            return;
        }

        dragger.OnDragStart += (sender, evt) => {
            Debug.Log("Started dragging.");
        };

        dragger.OnDragEnd += (sender, evt) => {
            Debug.Log("Stopped dragging.");
            HandleDrop();
        };
    }




    void HandleDrop()
    {
        if (rect.Left() < 0)
        {
            transform.position = new Vector3(rect.HalfWidth(), transform.position.y, 0);
        } else if (rect.Right() > Screen.width)
        {
            transform.position = new Vector3(Screen.width - rect.HalfWidth(), transform.position.y, 0);
        }
    }
}
