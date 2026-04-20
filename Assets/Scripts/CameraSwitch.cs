using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera[] inventoryCameras; // Player1, Player2, AI
    public Camera topDownCamera;

    public static Camera wantedCamera;
    public static Camera currentCamera;

    private int currentIndex = -1;

    void Start()
    {
        wantedCamera = mainCamera;
        // Start in gameplay mode
        CycleCamera();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CycleCamera();
        }
    }

    public void CycleCamera()
    {
        mainCamera.enabled = false;
        foreach (Camera cam in inventoryCameras)
        {
            cam.enabled = false;
        }
        topDownCamera.enabled = false;

        // Check if a specific camera is wanted
        if (wantedCamera != null)
        {
            wantedCamera.enabled = true;
            currentCamera = wantedCamera;
            wantedCamera = null;
            return;
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
