using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointsMoveDeepOne : MonoBehaviour
{
    public Transform initPos;
    public Transform endPos;
    public GameObject objectToMove;
    private Vector2 newPosition;
    private float pct = 0f;//Porcentaje de desplazamiento
    public bool moved; 
    public float speed;

    private void Awake()
    {
        moved = false;
    }


    void Update()
    {
        if (!moved) 
        {
            // Some enemies and objects can move between two points
            newPosition = Vector2.Lerp(initPos.position, endPos.position, pct);
            objectToMove.transform.position = newPosition;

            GetComponentInChildren<Animator>().enabled = false;

            pct += Time.deltaTime * speed;
            if (pct <= 0)
            {
                pct = 0;
                speed *= -1;
            }

            Invoke("EnableAnimations", 5.0f);
        }
        
        
    }

    private void EnableAnimations()
    {
        // Animations are enabled again
        GetComponentInChildren<Animator>().enabled = true;
        moved = true;
    }
}
