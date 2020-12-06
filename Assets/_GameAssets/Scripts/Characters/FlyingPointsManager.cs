using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPointsManager : MonoBehaviour
{
    public GameObject flyingPointsPrefab;
    public void InstantiateFlyingPoints(int points) 
    {
        GameObject fn = GameObject.Instantiate(flyingPointsPrefab, transform.position, transform.rotation);
        fn.GetComponent<FlyingPoints>().SetPoints(points);
    }
}
