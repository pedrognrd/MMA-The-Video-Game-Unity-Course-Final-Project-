/*
 * By Fernando Paniagua (2020)
 * 
 * Puedes utilizarlo para lo que quieras, pero si ganas mucho dinero me
 * tienes que invitar a comer cordero asado (es voluntario).
 * 
 */


using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    /*[Range(0,10)]
    public float ortographicSizeMin;
    [Range(0, 10)]
    public float ortographicSizeMax;
    [Range(0,2)]
    public float zoomInSpeed;
    [Range(0, 2)]
    public float zoomOutSpeed;
    [Range(0, 5)]
    public float timeToZoomOut;
    */
    //private float ortographicSizeCurrent;
    private CinemachineVirtualCamera cvc;
    private float offset = 0.1f;
    public float m_ScreenYInitial;
    private void Awake()
    {
        cvc = GetComponent<CinemachineVirtualCamera>();
        m_ScreenYInitial = cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY;
    }
    void Start()
    {
        //ortographicSizeCurrent = ortographicSizeMax;
    }

    void Update()
    {
        if (Mathf.Abs(playerRigidbody.velocity.x) > offset)
        {
            cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = m_ScreenYInitial + 0.08f;
        } else
        {
            cvc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = m_ScreenYInitial;
        }
    }
}
