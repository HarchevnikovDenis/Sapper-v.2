using System.Collections.Generic;
using UnityEngine;

public class CellsGenerator : MonoBehaviour 
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int minesCount;
    [SerializeField] private SapperFieldManager sapperFieldManager;
    private float offset = 0.5f;

    public static CellsGenerator Instance { get; private set;}
    public int Width => width;
    public int Height => height;
    public int MinesCount => minesCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnCellField();
    }

    private void SpawnCellField()
    {
        List<Cell> cells = new List<Cell>();
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Vector3 instantiatePosition = new Vector2(transform.position.x + j * offset, transform.position.y - i * offset);
                GameObject cell = Instantiate(cellPrefab, instantiatePosition, Quaternion.identity);
                cells.Add(cell?.GetComponent<Cell>());
            }
        }

        sapperFieldManager.SetCells(cells);
    }
}
