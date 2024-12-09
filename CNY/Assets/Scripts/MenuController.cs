using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public void StartGame()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SwitchToFightMusic();  // Switch to fight music
        }
        else
        {
            Debug.LogError("AudioManager instance is not available.");
        }
        // Load the fight scene
        SceneManager.LoadScene("FightScene"); // Replace with your fight scene's name
    }

    public void ExitGame()
    {
        // Exit the application
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
