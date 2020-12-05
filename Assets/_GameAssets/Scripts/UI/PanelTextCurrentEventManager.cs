using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTextCurrentEventManager : MonoBehaviour
{
    public Text textCurrentEvent;
    private void Awake()
    {
        textCurrentEvent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string currentEvent) {
        print("currentEvent " + currentEvent);
        textCurrentEvent.text = currentEvent;
    }
}
