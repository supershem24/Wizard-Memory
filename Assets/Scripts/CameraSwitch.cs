using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera inventoryCamera;

    private bool showingInventory = false;

    void Start()
    {
        // Start in gameplay mode
        mainCamera.enabled = true;
        inventoryCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showingInventory = !showingInventory;

            mainCamera.enabled = !showingInventory;
            inventoryCamera.enabled = showingInventory;
        }
    }
}
