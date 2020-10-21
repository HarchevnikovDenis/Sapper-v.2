public class FlagToDeminingToggle : SwitchHandler
{
    public bool isFlagSelected { get; set;}

    public override void OnSwitchButtonClicked()
    {
        base.OnSwitchButtonClicked();
        isFlagSelected = !isFlagSelected;
    }
}
