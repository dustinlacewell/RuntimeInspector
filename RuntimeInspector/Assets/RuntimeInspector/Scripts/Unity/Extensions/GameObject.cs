using UnityEngine;

namespace RuntimeInspector
{
    public static class GameObjectExtensions
    {
        public static bool ToggleActive(this GameObject gobj)
        {
            gobj.SetActive(!gobj.activeSelf);
            return gobj.activeSelf;
        }
    }
}
