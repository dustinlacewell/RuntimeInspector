using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UITimeSlider : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("UITimeSlider couldn't find sibling Slider component!");
        }
        slider.onValueChanged.AddListener(val => {
            Time.timeScale = val;
        });
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            var delta = Input.mouseScrollDelta.y * 0.15f;
            Time.timeScale = Mathf.Min(2.0f, Time.timeScale + delta);
        }
        slider.value = Time.timeScale;
    }
}