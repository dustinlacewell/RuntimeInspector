using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeInspector
{
    [RequireComponent(typeof(ToggleButton))]
    class ObjectsActiveToggle : MonoBehaviour
    {
        public List<GameObject> objects;

        private ToggleButton toggle;

        private void Awake()
        {
            toggle = GetComponent<ToggleButton>();
            toggle.Toggled.AddListener(Toggle);
        }
        public void Toggle()
        {
            objects.ForEach(o => o.ToggleActive());
        }
    }
}
