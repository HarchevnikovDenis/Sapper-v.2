using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private SapperFieldManager sapperFieldManager;
    [SerializeField] private FlagToDeminingToggle flagToDeminingToggle;
    [SerializeField] private FlagsController flagsController;
    private bool isFirstCellOpened;
    private int minesDefused;

    private void Update()
    {
        if(gameStateManager.isPlayerLost) return;

        if(Input.touchCount > 0)
        {
            CatchPlayerInput();
        }
    }

    private void CatchPlayerInput()
    {
        Touch[] touches = Input.touches;
        foreach(Touch touch in touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 1));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.GetComponent<Cell>() && touch.phase == TouchPhase.Began)
                {
                    Cell cell = hit.collider.gameObject.GetComponent<Cell>();

                    if(!cell.isChecked && !cell.isOpened)
                    {
                        if(flagToDeminingToggle.isFlagSelected)
                        {
                            // Ставим Флаг
                            flagsController.flagsCount--;
                            flagsController.UpdateFlagsUI();
                            cell.SetFlag();

                            if(cell.CellStatus == "*")
                            {
                                minesDefused++;
                                CheckLevelComplete();
                            }
                        }
                        else
                        {
                            OpenCell(cell);
                            CheckLevelComplete();
                        }
                        continue;
                    }

                    if(cell.isChecked && flagToDeminingToggle.isFlagSelected)
                    {
                        // Снимаем флаг
                        flagsController.flagsCount++;
                        flagsController.UpdateFlagsUI();
                        cell.ResetFlag();

                        if(cell.CellStatus == "*")
                        {
                            minesDefused--;
                            CheckLevelComplete();
                        }
                    }
                }
            }
        }
    }

    private void OpenCell(Cell cell)
    {
        cell.isOpened = true;
        cell.OpenCell();

        if(!isFirstCellOpened)
        {
            sapperFieldManager.SetRandomMines();
            isFirstCellOpened = true;
        }

        if(cell.CellStatus == "0")
        {
            sapperFieldManager.OpenCellsAround(cell);
        }

        if(cell.CellStatus == "*")
        {
            GameOver();
        }
    }

    private void CheckLevelComplete()
    {
        if(minesDefused >= CellsGenerator.Instance.MinesCount)
        {
            PlayerWin();
        }
    }

    private void PlayerWin()
    {
        gameStateManager.LevelCompleted();
    }

    private void GameOver()
    {
        gameStateManager.GameOver();
    }
}
