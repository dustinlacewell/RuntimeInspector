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
    private Vector2 previousOffset;

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
        previousSize = rect.sizeDelta;
        previousOffset = Input.mousePosition - rect.position;

        Resize();
        Position(side);

        Docked = true;
        OnDockStart?.Invoke(this, EventArgs.Empty);
    }

    void Undock()
    {
        if (Docked)
        {
            rect.sizeDelta = previousSize;
            rect.position = (Vector2)Input.mousePosition - previousOffset;

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
