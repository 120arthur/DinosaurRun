using UnityEngine;
using UnityEngine.Analytics;

namespace Analytics
{
    public class AnalyticsManager : MonoBehaviour
    {
        public static AnalyticsManager analyticsManagerInstance;
        private void Awake()
        {
            analyticsManagerInstance = this;
        }
        /// <summary>
        /// Send a String for unity analytics.
        /// </summary>
        /// <param name="elementName"></param>
        public void AnalyticsEvent(string elementName)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(elementName);
        }

        /// <summary>
        /// Send a string and the position for the unity analytics.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="position"></param>
        public void AnalyticsEvent(string elementName, Vector3 position)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(elementName, position);
        }
    }
}
