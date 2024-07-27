using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class CamShake : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public float shakeTime;
    public float shakeIntensity;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Start()
    {
        StopShake();
    }

    public void Shake()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime; 
    }

    public void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0f;
        timer = 0; 
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                StopShake();
            }
        }
    }
}
