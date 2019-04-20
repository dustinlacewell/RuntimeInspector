using MultiMod.Interface;
using RoR2;
using RuntimeInspectorNamespace;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ExampleMod : ModBehaviour
{
    public GameObject hierarchy;
    public GameObject inspector;

    private Canvas _canvas;
    private RectTransform _hierarchy;
    private RectTransform _inspector;

    private Camera _camera;
    

    void SetPointAnchor(RectTransform rect, Vector2 position)
    {
        rect.anchorMin = rect.anchorMax = position;
    }

    void SetPointAnchor(RectTransform rect)
    {
        SetPointAnchor(rect, new Vector2(0.5f, 0.5f));
    }

    void SetSpreadAnchor(RectTransform rect, Vector2 min, Vector2 max)
    {
        rect.anchorMin = min;
        rect.anchorMax = max;
    }

    void SetSpreadAnchor(RectTransform rect)
    {
        SetSpreadAnchor(rect, Vector2.zero, Vector2.one);
    }

    RectTransform AddCanvasPrefab(GameObject prefab)
    {
        var gobj = Instantiate(prefab);
        gobj.transform.SetParent(_canvas.transform);
        return gobj.GetComponent<RectTransform>();
    }

    //void Update()
    //{
    //    //if mouse button (left hand side) pressed instantiate a raycast
    //    if (_camera != null && Input.GetMouseButtonDown(0))
    //    {
    //        //create a ray cast and set it to the mouses cursor position in game

    //        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit, 50.0f))
    //        {
    //            //draw invisible ray cast/vector
    //            Debug.DrawLine(ray.origin, hit.point);
    //            //log hit area to the console
    //            Debug.Log(hit.point);
    //            hit.transform.gameObject.SetActive(false);
    //        }
    //    }
    //}

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
        SetPointAnchor(_hierarchy);
        _hierarchy.anchoredPosition = Vector2.zero;
        _hierarchy.sizeDelta = new Vector2(300, 700);
        var rh = _hierarchy.GetComponentInChildren<RuntimeHierarchy>();

        _inspector = AddCanvasPrefab(inspector);
        SetPointAnchor(_inspector);
        _inspector.anchoredPosition = Vector2.zero;
        _inspector.sizeDelta = new Vector2(300, 700);
        var ri = _inspector.GetComponentInChildren<RuntimeInspector>();

        rh.ConnectedInspector = ri;
        ri.ConnectedHierarchy = rh;
    }
}