using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagsController : MonoBehaviour
{
    [SerializeField] private Text flagsText;
    public int flagsCount { get; set;}

    private void Start()
    {
        flagsCount = CellsGenerator.Instance.MinesCount;
        UpdateFlagsUI();
    }

    public void UpdateFlagsUI()
    {
        flagsText.text = flagsCount.ToString();
    }
}
