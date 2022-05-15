using System;
using Cinemachine;
using UnityEngine;
using UI;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera speechVCam;
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
    private void OnEnable()
    {
        SpeechBubbleUI.OnSpeechBubbleClose += EnableNormalCam;
        SpeechBubbleUI.OnSpeechBubbleOpen += EnableSpeechVCam;
    }

    private void OnDisable()
    {
        SpeechBubbleUI.OnSpeechBubbleClose -= EnableNormalCam;
        SpeechBubbleUI.OnSpeechBubbleOpen -= EnableSpeechVCam;

    }

    private void EnableSpeechVCam()
    {
        speechVCam.enabled = true;
    }
    
    private void EnableNormalCam()
    {
        normalVCam.enabled = true;
    }
}
