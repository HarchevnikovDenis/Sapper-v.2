using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : SwitchHandler
{
    [SerializeField] private Color enableColor;
    [SerializeField] private Color disableColor;

    public bool isActive
    {
        get
        {
            return AudioManager.audio.music > 0;
        }
        set
        {
            if(value)
            {
                backgroundImage.color = enableColor;
                AudioManager.audio.music = 1;
            }
            else
            {
                backgroundImage.color = disableColor;
                AudioManager.audio.music = 0;
            }
        }
    }

    private void Start()
    {
        if(isActive)
        {
            backgroundImage.color = enableColor;
            switchButton.localPosition = new Vector2(-25.0f, 0.0f);
        }
        else
        {
            backgroundImage.color = disableColor;
            switchButton.localPosition = new Vector2(25.0f, 0.0f);
        }
    }

    public override void OnSwitchButtonClicked()
    {
        base.OnSwitchButtonClicked();
        isActive = !isActive;
    }
}
