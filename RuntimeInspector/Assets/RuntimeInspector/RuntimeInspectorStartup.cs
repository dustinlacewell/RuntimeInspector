using MultiMod.Interface;
using System.Linq;
using UnityEngine;
using System;

namespace RuntimeInspector
{
    public class RuntimeInspectorStartup : ModBehaviour
    {
        public static event EventHandler onLoaded;
        public RuntimeHierarchy Hierarchy { get; private set; }
        public RuntimeInspector Inspector { get; private set; }

        static RuntimeInspectorStartup instance;

        void BuildWindowSingletons()
        {
            Hierarchy = GetComponentInChildren<RuntimeHierarchy>(true);
            Inspector = GetComponentInChildren<RuntimeInspector>(true);


            var colorPicker = Instantiate(contentHandler.prefabs.Where(p => p.name == "ColorPicker").First());
            DontDestroyOnLoad(colorPicker);
            ColorPicker.Instance = colorPicker.GetComponent<ColorPicker>();
            ColorPicker.Instance.Close();

            var objPicker = Instantiate(contentHandler.prefabs.Where(p => p.name == "ObjectReferencePicker").First());
            DontDestroyOnLoad(objPicker);
            ObjectReferencePicker.Instance = objPicker.GetComponent<ObjectReferencePicker>();
            ObjectReferencePicker.Instance.Close();
        }

        public static void AddListener(EventHandler handler)
        {
            if (instance != null)
            {
                handler.Invoke(instance, EventArgs.Empty);
            } else
            {
                onLoaded += handler;
            }
        }

        public override void OnLoaded(ContentHandler contentHandler)
        {
            BuildWindowSingletons();
            instance = this;
            onLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                TimeScale.Toggle();
            }
        }
    }
}