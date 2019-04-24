using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementDocker : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public event EventHandler OnDockStart;
    public event EventHandler OnDockEnd;
    public bool Docked { get; private set; }

    private RectTransform rect;
    private Canvas canvas;

    private Vector2 previousSize;
    private Vector2 normalizedMousePosition;

    private enum Side { Left, Right }
    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Parent canvas could not be found.");
            return;
        }
    }

    void Resize()
    {
        previousSize = rect.sizeDelta;
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, Screen.height);
        rect.position = new Vector2(rect.position.x, Screen.height / 2.0f);
    }

    void Position(Side side)
    {
        switch (side)
        {
            case Side.Left:
                transform.position = new Vector3(rect.HalfWidth(), transform.position.y, 0);
                break;
            case Side.Right:
                transform.position = new Vector3(Screen.width - rect.HalfWidth(), transform.position.y, 0);
                break;
        }
    }

    void Dock(Side side)
    {
        Resize();
        Position(side);

        Docked = true;
        OnDockStart?.Invoke(this, EventArgs.Empty);
    }

    void Undock()
    {
        if (Docked)
        {
            // get mouse's current normalized position within the window
            Vector2 localMousePosition = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, canvas.worldCamera, out localMousePosition);
            var normalizedMousePosition = Rect.PointToNormalized(rect.rect, localMousePosition);

            // resize - this doesn't change the mouse's local position
            // but does change its normalized position since the size has changed
            rect.sizeDelta = previousSize;

            // calculate the target local position by applying the normalized position to our new rect
            var localTargetPosition = previousSize * normalizedMousePosition - new Vector2(previousSize.x / 2.0f, previousSize.y / 2.0f);

            // get the difference between the mouse's current local position and the target one
            var difference = localTargetPosition - localMousePosition;

            // apply the difference
            rect.position = rect.position - (Vector3)difference;

            Docked = false;
            OnDockEnd?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag.");
        Undock();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag.");
        if (rect.Left() < 0)
        {
            Dock(Side.Left);
        } 
        else if (rect.Right() > Screen.width)
        {
            Dock(Side.Right);
        }
    }
}
