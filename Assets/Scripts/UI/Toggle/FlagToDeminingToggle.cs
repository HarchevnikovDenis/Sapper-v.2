using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagToDeminingToggle : SwitchHandler
{
    public bool isFlagSelected { get; set;}

    public override void OnSwitchButtonClicked()
    {
        base.OnSwitchButtonClicked();
        isFlagSelected = !isFlagSelected;
    }
}
