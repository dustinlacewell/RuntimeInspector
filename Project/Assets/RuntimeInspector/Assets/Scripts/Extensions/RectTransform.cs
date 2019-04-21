using UnityEngine;


public static class RectTransformExtensions
{
    public static void SetPointAnchor(this RectTransform rect, Vector2 position)
    {
        rect.anchorMin = rect.anchorMax = position;
    }

    public static void SetPointAnchor(this RectTransform rect)
    {
        SetPointAnchor(rect, new Vector2(0.5f, 0.5f));
    }

    public static void SetSpreadAnchor(this RectTransform rect, Vector2 min, Vector2 max)
    {
        rect.anchorMin = min;
        rect.anchorMax = max;
    }

    public static void SetSpreadAnchor(this RectTransform rect)
    {
        SetSpreadAnchor(rect, Vector2.zero, Vector2.one);
    }

    public static float Width(this RectTransform rect)
    {
        return rect.sizeDelta.x;
    }

    public static float Height(this RectTransform rect)
    {
        return rect.sizeDelta.y;
    }

    public static float HalfWidth(this RectTransform rect)
    {
        return rect.Width() / 2.0f;
    }

    public static float HalfHeight(this RectTransform rect)
    {
        return rect.Height() / 2.0f;
    }

    public static float Left(this RectTransform rect)
    {
        return rect.position.x - rect.HalfWidth();
    }

    public static float Right(this RectTransform rect)
    {
        return rect.position.x + rect.HalfWidth();
    }

    public static float Top(this RectTransform rect)
    {
        return rect.position.y - rect.HalfHeight();
    }

    public static float Bottom(this RectTransform rect)
    {
        return rect.position.y + rect.HalfHeight();
    }

    public static bool HasPointAnchor(this RectTransform rect)
    {
        return rect.anchorMin == rect.anchorMax;
    }

}
