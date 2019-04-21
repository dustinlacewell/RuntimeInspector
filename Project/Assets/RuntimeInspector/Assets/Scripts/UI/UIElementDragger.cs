using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementDragger : EventTrigger
{

    public bool Dragging { get; private set; }

    private Vector2 offset;

    public event EventHandler<PointerEventData> OnDragStart;
    public event EventHandler<PointerEventData> OnDragEnd;

    public override void OnPointerDown(PointerEventData eventData)
    {
        Dragging = true;
        OnDragStart?.Invoke(this, eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Dragging = false;
        OnDragEnd?.Invoke(this, eventData);
    }
}