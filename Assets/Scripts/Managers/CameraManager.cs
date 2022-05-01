using Cinemachine;
using UnityEngine;
using UI;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

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

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        EnableIntroCam();
        SpeechBubbleUI.OnSpeechBubbleEnd += EnableNormalCam;
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
