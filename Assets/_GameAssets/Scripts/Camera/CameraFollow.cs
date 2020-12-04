using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    float xInitPosPlayer;
    float xInitPosCamera;
    float xCurrentPosPlayer;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        xInitPosCamera = transform.position.x;
        xInitPosPlayer = target.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        xCurrentPosPlayer = target.transform.position.x;
        xOffset = xInitPosPlayer - xCurrentPosPlayer;
        transform.position = new Vector3(
            xInitPosCamera - xOffset,
            transform.position.y,
            transform.position.z);
    }
}
