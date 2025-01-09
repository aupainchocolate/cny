using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Initialize the volume slider value
        if (MusicManager.instance != null)
        {
            volumeSlider.value = MusicManager.instance.GetComponent<AudioSource>().volume;
        }

        // Add a listener to handle volume changes
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }
    public void StartGame()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayGameMusic(); 
        }
        SceneManager.LoadScene("GameScene"); // Replace with the actual name of your game scene
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // Debug message for testing in the editor
    }

    private void SetVolume(float volume)
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(volume);
        }
    }
}
