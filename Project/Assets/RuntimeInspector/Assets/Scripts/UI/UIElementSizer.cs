using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum HandleLocation
{
    Left, BottomLeft, Bottom, BottomRight, Right
}

public class UIElementSizer : MonoBehaviour, IDragHandler
{

    public RectTransform owner;
    public UIElementDragger dragger;

    public HandleLocation handleLocation;

    private Vector2 growDirection;
    private Vector2 moveDirection;

    private Vector2 originalOwnerPosition;
    private Vector2 originalOwnerSize;
    private Vector2 originalMousePosition;

    private Dictionary<HandleLocation, Vector2> growMap = new Dictionary<HandleLocation, Vector2>();
    private Dictionary<HandleLocation, Vector2> moveMap = new Dictionary<HandleLocation, Vector2>();

    void Start()
    {
        growMap[HandleLocation.Left] = new Vector2(-1, 0);
        moveMap[HandleLocation.Left] = new Vector2(1, 0);

        growMap[HandleLocation.BottomLeft] = new Vector2(-1, -1);
        moveMap[HandleLocation.BottomLeft] = new Vector2(1, 1);

        growMap[HandleLocation.BottomRight] = new Vector2(1, -1);
        moveMap[HandleLocation.BottomRight] = new Vector2(1, 1);

        growMap[HandleLocation.Bottom] = new Vector2(0, -1);
        moveMap[HandleLocation.Bottom] = new Vector2(0, 1);

        growMap[HandleLocation.Right] = new Vector2(1, 0);
        moveMap[HandleLocation.Right] = new Vector2(1, 0);

        growDirection = growMap[handleLocation];
        moveDirection = moveMap[handleLocation];

        dragger.OnDragStart += (sender, evt) => {
            originalMousePosition = evt.position;
            originalOwnerPosition = owner.position;
            originalOwnerSize = new Vector3(owner.Width(), owner.Height());
        };
    }

    // Update is called once per frame
    public void OnDrag(PointerEventData eventData)
    {
        owner.sizeDelta += eventData.delta * growDirection;
        owner.position += (Vector3)(eventData.delta * 0.5f * moveDirection);
    }
}
