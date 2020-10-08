using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class SwitchHandler : MonoBehaviour
{
    [SerializeField] protected Transform switchButton;
    [SerializeField] protected RawImage backgroundImage;
    
    protected bool canClick
    {
        get
        {
            return Mathf.Abs(switchButton.localPosition.x) == 25.0f;
        }
    }

    public virtual void OnSwitchButtonClicked()
    {
        if(!canClick) return;

        switchButton.DOLocalMoveX(-switchButton.localPosition.x, 0.25f);
    }
}
