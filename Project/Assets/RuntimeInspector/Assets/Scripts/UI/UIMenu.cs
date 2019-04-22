using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class UIMenu : MonoBehaviour
{
    public GameObject[] items;

    public event Action OnShow;
    public event Action OnHide;

    bool _active;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    public bool Active { get { return _active; }
        set {
            _active = value;
            if (_active)
                Show();
            else
                Hide();
        }
    }

    public void Toggle()
    {
        if (_active)
        {
            Hide();
        } 
        else
        {
            Show();
        }
    }

    public void Show()
    {
        foreach (var gobj in items) gobj.SetActive(true);
        _active = true;
        OnShow?.Invoke();
    }

    public void Hide()
    {
        foreach (var gobj in items) gobj.SetActive(false);
        _active = false;
        OnHide?.Invoke();
    }
}
