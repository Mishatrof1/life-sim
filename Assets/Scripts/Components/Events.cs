using System.Collections.Generic;
using Core.NpcCommunication;
using Modules.Navigation;

public class NavigationPointChanged
{
    public NavigationPoint PreviousPoint { get; set; }
    public NavigationPoint CurrentPoint { get; set; }
    public TransitionType TransitionType { get; set; }
}

public class NavigationPointClick
{
    public NavigationPoint Point { get; set; }
}

public class NavigationBackClick
{
}

public class NavigationHomeClick
{
}

public class Popup_Close
{
}

public class MainScreen_AgeButtonClick
{
}

public class MainScreen_MenuButtonClick
{
}

public class MainScreen_SocialButtonClick
{
}

public class MainScreen_AssetsButtonClick
{
}

public class MainScreen_ProfileButtonClick
{
}

public class MainScreen_ActivityButtonClick
{
}

public class MainScreen_OccupationButtonCLick
{
}

public class ActionsScreen_BackButtonClick
{
}

public class ActionsScreen_HomeButtonClick
{
}

public class CharacterScreen_BackButtonClick
{
}

public class CharacterScreen_HomeButtonClick
{
}

public class CharacterScreen_DropDownValueChanged
{
    public int Value { get; set; }
}

public class CharacterScreen_InputValueChanged
{
    public int Value { get; set; }
}

public class CharacterScreen_EmptionButtonClick
{
}

public class LoadingScreen_Click
{
}

public class StartScreen_NewCharacterClick
{
}

public class StartScreen_CharacterChoose
{
}

public class StartScreen_SoundClick
{
}

public class DialogChoiceButton_Click
{
    public int ChoiceIndex { get; set; }
    public int CurrentDropDownIndex { get; set; }
}
    
public class DialogCurrentChoices_Changed
{
    public string Message { get; set; }
    public List<CommunicationChoice> CurrentChoices { get; set; }
    public List<CommunicationChoice> DropListChoices { get; set; }
}

public class ParametersChanged
{
    public Person Person;
}