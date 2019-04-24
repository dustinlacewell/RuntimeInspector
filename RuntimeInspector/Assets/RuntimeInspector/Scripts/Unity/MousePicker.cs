using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeInspector
{
    public static class MousePicker
    {
        public static GameObject Pick()
        {
            // this code show nameobject with click   
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    return hit.collider.gameObject;
                }
            }
            return null;
        }
    }
}
