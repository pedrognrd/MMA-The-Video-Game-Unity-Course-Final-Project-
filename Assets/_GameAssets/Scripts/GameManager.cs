using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("CHARACTER SELECTED")]
    //Configuracion
    public bool characterSelected = false;
    public GameObject currentCharacterSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectCharacter();
        }
    }

    public void SelectCharacter()
    {
        //Debug.Log("Mouse is down");
    }
}
