using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainButtons;     // Play / Select / Quit
    public GameObject locationSelect;  // Location buttons
    public GameObject playerNumber;    // Player count buttons

    // Stored choices
    private string selectedScene;
    private int selectedPlayers;

    public void OpenSelect()
    {
        mainButtons.SetActive(false);
        locationSelect.SetActive(true);
    }

    // Player Selects Location and store
    public void SelectLocation(string sceneName)
    {
        selectedScene = sceneName;
        Debug.Log("Selected Scene: " + sceneName);

        locationSelect.SetActive(false);
        playerNumber.SetActive(true);
    }

    // Player Selects Player Number and store
    public void SelectPlayerCount(int count)
    {
        selectedPlayers = count;
        Debug.Log("Selected Players: " + count);

        playerNumber.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(selectedScene))
        {
            PlayerPrefs.SetString("Scene", selectedScene);
            PlayerPrefs.SetInt("Players", selectedPlayers);

            SceneManager.LoadScene(selectedScene);
        }
        else
        {
            Debug.Log("No location selected yet.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
