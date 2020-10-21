using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUIController : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
