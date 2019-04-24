using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementMover : MonoBehaviour, IDragHandler
{
    public UIElementDocker docker;

    private Vector2 offset;

    void Start()
    {
        if (docker == null)
            docker = GetComponent<UIElementDocker>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (docker != null && docker.Docked)
        {
            return;
        }

        transform.position += (Vector3)eventData.delta;
    }
}
