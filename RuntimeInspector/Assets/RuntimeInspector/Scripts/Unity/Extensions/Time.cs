using UnityEngine;

namespace RuntimeInspector
{
    public static class TimeScale
    {
        static float oldScale = 0.0f;
        public static void Toggle()
        {
            if (Time.timeScale > 0.0f)
            {
                oldScale = Time.timeScale;
                Time.timeScale = 0.0f;
            } else
            {
                Time.timeScale = Mathf.Min(oldScale, 1.0f);
            }
        }
    }
}
