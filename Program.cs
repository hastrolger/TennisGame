
int menuOptionSelected = 0;
bool menuOptionIsOk = false;

while(menuOptionIsOk != true){
    ShowMainMenu();
    menuOptionSelected = GetMenuOption();
    menuOptionIsOk = ValidateMenuOptionSelected(menuOptionSelected);

    Console.ReadLine();
    Console.Clear();
}

// show main menu
void ShowMainMenu() {
    int countMenu = 1;
    foreach (MainMenu menu in Enum.GetValues(typeof(MainMenu))) {
        Console.WriteLine(countMenu + ".- " + menu);
        countMenu++;
    }    
}

// get menu option and return it as an integer
int GetMenuOption() {
    Console.WriteLine("Select menu option: ");
    int input = Convert.ToInt16(Console.ReadLine());

    return input;
}

// validate menu option and return true if it's in range 
bool ValidateMenuOptionSelected(int menuOption) {
    bool isOk = false;
    int MenuOptionLength = Enum.GetValues(typeof(MainMenu)).Length;

    if(menuOption < 1 || menuOption > MenuOptionLength) {
        Console.WriteLine("Option is out of range.");
        isOk = false;
    }
    else {
        isOk = true;
    }

    return isOk;
}

enum MainMenu {
    StartGame = 1,
    Exit = 2
}

