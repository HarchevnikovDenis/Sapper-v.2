using UnityEngine;

public class CellColorManager : MonoBehaviour
{
    [SerializeField] private GameObject boomEffect;
    [SerializeField] private Color openCellColor;
    [SerializeField] private Color openMineColor;
    [SerializeField] private Color color_0, color_1, color_2, color_3, color_4;

    public static CellColorManager Instance { get; private set; }

    public GameObject BoomEffect => boomEffect;
    public Color OpenCellColor => openCellColor;
    public Color OpenMineColor => openMineColor;
    public Color Color_0 => color_0;
    public Color Color_1 => color_1;
    public Color Color_2 => color_2;
    public Color Color_3 => color_3;
    public Color Color_4 => color_4;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
