using UnityEngine;
using UnityEngine.Audio;

public class Musicmanager : MonoBehaviour
{
    private static Musicmanager instance;

   [SerializeField] private AudioSource audioSource;
   [SerializeField] public AudioClip menuMusic;
   [SerializeField] public AudioClip fightMode;

    private void Awake()
    {
        // Ensure this object persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }
    private void Start()
    {
        PlayMusic(menuMusic); // Play menu music by default
    }
    public void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return; // Avoid restarting the same clip

        audioSource.clip = clip;
        audioSource.Play();
    }
    public void SwitchToFightMusic()
    {
        PlayMusic(fightMode); // Switch to fight music
    }

    public void SwitchToMenuMusic()
    {
        PlayMusic(menuMusic); // Switch to menu music
    }
}
