using MultiMod.Interface;
using RoR2;
using RuntimeInspectorNamespace;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StartupScript : ModBehaviour
{
    private Canvas _canvas;

    public override void OnLoaded(ContentHandler contentHandler)
    {
        _canvas = RoR2.RoR2Application.instance.mainCanvas;
        var scaler = _canvas.GetComponent<CanvasScaler>();
        scaler.scaleFactor = 1.0f;
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;

        var colorPicker = Instantiate(contentHandler.prefabs.Where(p => p.name == "ColorPicker").First());
        Object.DontDestroyOnLoad(colorPicker);
        ColorPicker.Instance = colorPicker.GetComponent<ColorPicker>();
        ColorPicker.Instance.Close();

        var objPicker = Instantiate(contentHandler.prefabs.Where(p => p.name == "ObjectReferencePicker").First());
        Object.DontDestroyOnLoad(objPicker);
        ObjectReferencePicker.Instance = objPicker.GetComponent<ObjectReferencePicker>();
        ObjectReferencePicker.Instance.Close();

        transform.SetParent(_canvas.transform);
        var rect = transform as RectTransform;
        rect.SetSpreadAnchor();
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.one;
        rect.localScale = Vector3.one;
    }

    public void DoDebug()
    {
        Debug.Log("Debug button pressed.");
    }
}