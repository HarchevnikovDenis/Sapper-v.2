using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cellStatus;
    [SerializeField] private GameObject flagImage;
    [SerializeField] private GameObject bombImage;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private CellColorManager cellColorManager => CellColorManager.Instance;

    public string CellStatus
    {
        get
        {
            return cellStatus.text;
        }
        set
        {
            cellStatus.text = value;
            SetFontColor();
        }
    }
    public bool isOpened { get; set;}
    public bool isChecked { get; set;}

    public void OpenCell()
    {
        if(isOpened)
        {
            spriteRenderer.color = cellColorManager.OpenCellColor;
            cellStatus.gameObject.SetActive(true);
        }
    }

    public void OpenMine()
    {
        if(!isChecked) spriteRenderer.color = cellColorManager.OpenMineColor;
        
        cellStatus.gameObject.SetActive(true);
        bombImage.SetActive(true);
        Instantiate(cellColorManager.BoomEffect, transform.position, Quaternion.identity);
    }

    public void SetFlag()
    {
        flagImage.SetActive(true);
        isChecked = true;
    }

    public void ResetFlag()
    {
        flagImage.SetActive(false);
        isChecked = false;
    }

    private void SetFontColor()
    {
        switch (CellStatus)
        {
            case "0":
                cellStatus.color = cellColorManager.Color_0;
                break;
            case "1":
                cellStatus.color = cellColorManager.Color_1;
                break;
             case "2":
                cellStatus.color = cellColorManager.Color_2;
                break;
            case "3":
                cellStatus.color = cellColorManager.Color_3;
                break;
            case "4":
                cellStatus.color = cellColorManager.Color_4;
                break;   
        }
    }
}
