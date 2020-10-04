using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private int width;
    [SerializeField] private int height;
    private float offset = 0.5f;

    private void Start()
    {
        SpawnCellField();
    }

    private void SpawnCellField()
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Vector3 instantiatePosition = new Vector2(transform.position.x + j * offset, transform.position.y - i * offset);
                Instantiate(cellPrefab, instantiatePosition, Quaternion.identity);
            }
        }
    }
}
