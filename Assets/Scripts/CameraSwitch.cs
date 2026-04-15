using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera[] inventoryCameras; // Player1, Player2, AI

    private int currentIndex = -1;

    void Start()
    {
        // Start in gameplay mode
        mainCamera.enabled = true;

        foreach (Camera cam in inventoryCameras)
        {
            cam.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CycleCamera();
        }
    }

    void CycleCamera()
    {
        mainCamera.enabled = false;
        foreach (Camera cam in inventoryCameras)
        {
            cam.enabled = false;
        }

        // Next Camera Index
        currentIndex++;

        //Go back to main camera when it hits last camera
        if (currentIndex >= inventoryCameras.Length)
        {
            currentIndex = -1;
        }

        // Enable correct camera
        if (currentIndex == -1)
        {
            mainCamera.enabled = true;
        }
        else
        {
            inventoryCameras[currentIndex].enabled = true;
        }
    }
}
