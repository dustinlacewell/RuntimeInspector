using MultiMod.Interface;
using RoR2;
using RuntimeInspectorNamespace;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StartupScript : ModBehaviour
{
    public GameObject hierarchy;
    public GameObject inspector;

    private Canvas _canvas;
    private RectTransform _hierarchy;
    private RectTransform _inspector;

    private Camera _camera;

    RectTransform AddCanvasPrefab(GameObject prefab)
    {
        var gobj = Instantiate(prefab);
        gobj.transform.SetParent(_canvas.transform);
        return gobj.GetComponent<RectTransform>();
    }

    public override void OnLoaded(ContentHandler contentHandler)
    {
        _canvas = RoR2.RoR2Application.instance.mainCanvas;
        _camera = GameObject.FindObjectOfType<CameraRigController>().sceneCam;

        var colorPicker = Instantiate(contentHandler.prefabs.Where(p => p.name == "ColorPicker").First());
        Object.DontDestroyOnLoad(colorPicker);
        ColorPicker.Instance = colorPicker.GetComponent<ColorPicker>();

        var objPicker = Instantiate(contentHandler.prefabs.Where(p => p.name == "ObjectReferencePicker").First());
        Object.DontDestroyOnLoad(objPicker);
        ObjectReferencePicker.Instance = objPicker.GetComponent<ObjectReferencePicker>();

        Debug.LogError($"Color picker is null: {ColorPicker.Instance == null}");
        Debug.LogError($"ObjectReferencePicker is null: {ObjectReferencePicker.Instance == null}");

        _hierarchy = AddCanvasPrefab(hierarchy);
        _hierarchy.SetPointAnchor();
        _hierarchy.anchoredPosition = Vector2.zero;
        _hierarchy.sizeDelta = new Vector2(300, 700);
        var rh = _hierarchy.GetComponentInChildren<RuntimeHierarchy>();

        _inspector = AddCanvasPrefab(inspector);
        _inspector.SetPointAnchor();
        _inspector.anchoredPosition = Vector2.zero;
        _inspector.sizeDelta = new Vector2(300, 700);
        var ri = _inspector.GetComponentInChildren<RuntimeInspector>();

        rh.ConnectedInspector = ri;
        ri.ConnectedHierarchy = rh;
    }
}