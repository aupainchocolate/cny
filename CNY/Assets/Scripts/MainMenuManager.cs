using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public SliderJoint2D volumSlider;

    public AudioSource bgmSource; 
    public void Start()
    {
        bgmSource.Play();

        if (volumSlider != null)
        { 
           
        }
    }

    public void StartGame()
    {
        bgmSource.Stop(); 

        
    }
    void Update()
    {
        
    }
}
