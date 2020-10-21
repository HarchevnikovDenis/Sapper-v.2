using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cellStatus;
    [SerializeField] private GameObject flagImage;
    [SerializeField] private GameObject bombImage;
    [SerializeField] private Color openCellColor;
    [SerializeField] private Color openMineColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color color_0, color_1, color_2, color_3, color_4;
    private Color startColor;
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

    private void Start()
    {
        startColor = spriteRenderer.color;
    }

    public void OpenCell()
    {
        if(isOpened)
        {
            spriteRenderer.color = openCellColor;
            cellStatus.gameObject.SetActive(true);
        }
    }

    public void OpenMine()
    {
        if(!isChecked) spriteRenderer.color = openMineColor;
        cellStatus.gameObject.SetActive(true);
        bombImage.SetActive(true);
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
                cellStatus.color = color_0;
                break;
            case "1":
                cellStatus.color = color_1;
                break;
             case "2":
                cellStatus.color = color_2;
                break;
            case "3":
                cellStatus.color = color_3;
                break;
            case "4":
                cellStatus.color = color_4;
                break;   
        }
    }
}
