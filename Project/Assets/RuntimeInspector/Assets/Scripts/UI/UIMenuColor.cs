using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(UIMenu))]
public class UIMenuColor : MonoBehaviour
{

    private Button button;
    private UIMenu menu;

    void Start()
    {
        button = GetComponent<Button>();
        menu = GetComponent<UIMenu>();

        menu.OnHide += Swap;
        menu.OnShow += Swap;
    }

    // Update is called once per frame
    void Swap()
    {
        var block = new ColorBlock();
        block.highlightedColor = button.colors.normalColor;
        block.normalColor = button.colors.highlightedColor; 
        block.pressedColor = block.normalColor;
        block.colorMultiplier = button.colors.colorMultiplier;
        block.fadeDuration = button.colors.fadeDuration;

        button.colors = block;
    }
}
