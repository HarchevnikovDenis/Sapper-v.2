using System.Collections.Generic;
using UnityEngine;

public class SapperFieldManager : MonoBehaviour
{
    private Cell[,] cells;
    private int width => CellsGenerator.Instance.Width;
    private int height => CellsGenerator.Instance.Height;
    private int minesCount => CellsGenerator.Instance.MinesCount;

    public void SetCells(List<Cell> cells)
    {
        this.cells = new Cell[height, width];

        if(width * height != cells.Count)
            throw new System.Exception("The size of the accepted values is not equal to the size of the set values");

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                this.cells[i, j] = cells[0];
                cells.RemoveAt(0);
            }
        }
    }

    public void SetRandomMines()
    {
        int x = cells.GetLength(1);
        int y = cells.GetLength(0);
        int countMines = minesCount;

        while(countMines > 0)
        {
            int randomX = Random.Range(0, x);
            int randomY = Random.Range(0, y);

            if(cells[randomY, randomX].CellStatus != "*" && !cells[randomY, randomX].isOpened)
            {
                cells[randomY, randomX].CellStatus = "*";
                countMines--;
            }
        }

        CountCellsStatus();
    }

    private void CountCellsStatus()
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(cells[i ,j].CellStatus != "*")
                {
                    int count = 0;
                    count += TryFindMine(i - 1, j - 1);
                    count += TryFindMine(i - 1, j);
                    count += TryFindMine(i - 1, j + 1);
                    count += TryFindMine(i, j - 1);
                    count += TryFindMine(i, j + 1);
                    count += TryFindMine(i + 1, j - 1);
                    count += TryFindMine(i + 1, j);
                    count += TryFindMine(i + 1, j + 1);

                    cells[i, j].CellStatus = count.ToString();
                }
            }
        }
    }

    private int TryFindMine(int y, int x)
    {
        if(x < 0 || y < 0 || x >= width || y >= height || !string.Equals(cells[y, x].CellStatus, "*"))
            return 0;
        else
            return 1;
    }

    public void OpenCellsAround(Cell zeroCell)
    {
        bool flag = false;
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(cells[i, j] == zeroCell)
                {
                    OpenAround(i ,j);
                    flag = true;
                    break;
                }
            }
            if(flag) break;
        }
    }

    private void OpenAround(int i, int j)
    {
        TryGetAndOpen(i - 1, j - 1);
        TryGetAndOpen(i - 1, j);
        TryGetAndOpen(i - 1, j + 1);
        TryGetAndOpen(i, j - 1);
        TryGetAndOpen(i, j + 1);
        TryGetAndOpen(i + 1, j - 1);
        TryGetAndOpen(i + 1, j);
        TryGetAndOpen(i + 1, j + 1);
    }

    private void TryGetAndOpen(int i, int j)
    {
        if(i < 0 || j < 0 || i >= CellsGenerator.Instance.Height || j >= CellsGenerator.Instance.Width) return;

        if(cells[i, j].isOpened) return;

        cells[i, j].isOpened = true;
        cells[i, j].OpenCell();
        if(cells[i, j].CellStatus == "0")
            OpenAround(i, j);
    }

    public void ShowMinesOnField()
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(cells[i, j].CellStatus == "*")
                {
                    if(!cells[i, j].isOpened) cells[i, j].isOpened = true;
                    
                    cells[i, j].OpenMine();
                }
            }
        }
    }
}
