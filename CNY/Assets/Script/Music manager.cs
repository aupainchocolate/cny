using UnityEngine;

public class Musicmanager : MonoBehaviour
{
    private static Musicmanager instance;

    private void Awake()
    {
        // Ensure this object persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }
}
