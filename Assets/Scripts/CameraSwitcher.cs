using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    public float scrollSensitivity = 1f;
    private int currentCameraIndex = 0;

    void Start()
    {
        // Activate the first camera and deactivate others
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }

    void Update()
    {
        // Get scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0)
        {
            SwitchCamera(currentCameraIndex + 1);
        }
        else if (scrollInput < 0)
        {
            SwitchCamera(currentCameraIndex - 1);
        }
    }

    void SwitchCamera(int cameraIndex)
    {
        if (cameraIndex >= 0 && cameraIndex < virtualCameras.Length)
        {
            virtualCameras[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex = cameraIndex;
            virtualCameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}