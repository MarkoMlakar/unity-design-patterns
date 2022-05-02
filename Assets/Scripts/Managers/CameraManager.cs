using System;
using Cinemachine;
using UnityEngine;
using UI;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera introVCam;
    [SerializeField] private CinemachineVirtualCamera normalVCam;
    [SerializeField] private CinemachineVirtualCamera aimVCam;
    public void EnableAimCam()
    {
        aimVCam.enabled = true;
        aimVCam.Priority += 10;
    }

    public void DisableAimCam()
    {
        aimVCam.enabled = false;
        aimVCam.Priority -= 10;
    }
    private void Start()
    {
        EnableIntroCam();
    }

    private void OnEnable()
    {
        SpeechBubbleUI.OnSpeechBubbleEnd += EnableNormalCam;
    }

    private void OnDisable()
    {
        SpeechBubbleUI.OnSpeechBubbleEnd -= EnableNormalCam;

    }

    private void EnableIntroCam()
    {
        introVCam.enabled = true;
    }
    
    private void EnableNormalCam()
    {
        normalVCam.enabled = true;
    }
}
