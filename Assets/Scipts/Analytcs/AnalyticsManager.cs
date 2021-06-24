using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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
        Analytics.CustomEvent(elementName);
    }

    /// <summary>
    /// Send a string and the position for the unity analytics.
    /// </summary>
    /// <param name="elementName"></param>
    /// <param name="Position"></param>
    public void AnalyticsEvent(string elementName, Vector3 Position)
    {
        Analytics.CustomEvent(elementName, Position);
    }
}
