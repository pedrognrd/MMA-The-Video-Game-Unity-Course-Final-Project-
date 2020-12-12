using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTextEventManager : MonoBehaviour
{
    public Text textCurrentEvent;
    private void Awake()
    {
        textCurrentEvent = GetComponent<Text>();
        textCurrentEvent.enabled = false;
    }
    public void UpdateText(string currentEvent) {
        textCurrentEvent.enabled = true;
        textCurrentEvent.text = currentEvent;
        Invoke("HideText", 2);//this will happen after X seconds
    }
    public void HideText() 
    {
        textCurrentEvent.enabled = false;
    }
}
