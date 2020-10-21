using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInitializer : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
