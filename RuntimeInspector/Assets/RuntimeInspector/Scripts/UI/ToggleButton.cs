using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ToggleButton : MonoBehaviour
{
    public UnityEvent ToggleOn;
    public UnityEvent ToggleOff;
    public UnityEvent Toggled;

    bool _active;

    private void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    public bool Active {
        get { return _active; }
        set {
            _active = value;
            if (_active)
                TurnOn();
            else
                TurnOff();
        }
    }

    public void Toggle()
    {
        if (_active)
        {
            TurnOff();
        } else
        {
            TurnOn();
        }
        Toggled?.Invoke();
    }

    public void TurnOn()
    {
        _active = true;
        ToggleOn?.Invoke();
    }

    public void TurnOff()
    {
        _active = false;
        ToggleOff?.Invoke();
    }
}
