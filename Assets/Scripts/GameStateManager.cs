using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private SapperFieldManager sapperFieldManager;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;
    public bool isPlayerLost { get; set;}

    public void GameOver()
    {
        sapperFieldManager?.ShowMinesOnField();
        lostPanel.SetActive(true);
        isPlayerLost = true;
    }

    public void LevelCompleted()
    {
        winPanel.SetActive(true);
    }
}
