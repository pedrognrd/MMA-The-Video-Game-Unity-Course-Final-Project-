using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;

    protected virtual void Awake()
    {
        //ClearLog();
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        // Initializing turn manager variables
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Save the city, Blue Ghost!");
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Dagon is at the end of the street!");
    }

    /*public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }*/
}
