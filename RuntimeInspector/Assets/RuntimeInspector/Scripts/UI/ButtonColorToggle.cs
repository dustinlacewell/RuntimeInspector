using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeInspector
{
    [RequireComponent(typeof(Button))]
    public class ButtonColorToggle : MonoBehaviour
    {

        private Button button;
        private ToggleButton toggle;

        void Start()
        {
            button = GetComponent<Button>();
            toggle = GetComponent<ToggleButton>();
            toggle.Toggled.AddListener(Swap);
        }

        // Update is called once per frame
        public void Swap()
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
}
