using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("FightScene"); // Make sure the scene name matches exactly
    }
}
