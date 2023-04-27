
int menuOptionSelected = 0;
bool menuOptionIsOk = false;

// generate static score data
List<String> listOfScores = new List<String>(){"0", "15", "30", "40"};
Dictionary<Players, List<String>> playerScores = new Dictionary<Players, List<String>>();

playerScores.Add(Players.P1, new List<string>(){"0","30"});
playerScores.Add(Players.P2, new List<string>(){"40","30"});

while(menuOptionIsOk != true){
    ShowMainMenu();
    menuOptionSelected = GetMenuOption();
    menuOptionIsOk = ValidateMenuOptionSelected(menuOptionSelected);
    
    Console.ReadLine();
    Console.Clear();
}

GetGameResults();

// get results of the game 
void GetGameResults() {
    int pointsForP1 = 0;
    int pointsForP2 = 0;
    
    var listOfScoresP1 = playerScores[Players.P1];
    var listOfScoresP2 = playerScores[Players.P2];

    for (int i = 0; i <= listOfScoresP1.Count - 1; i++){
        if (Int32.Parse(listOfScoresP1[i]) >  Int32.Parse(listOfScoresP2[i]))
        {
            pointsForP1 += 1;
        }
        if(Int32.Parse(listOfScoresP1[i]) < Int32.Parse(listOfScoresP2[i])) {
            pointsForP2 += 1;
        }
    }

    if (pointsForP1 > pointsForP2){
        Console.WriteLine($"Winner: {Players.P1}, points: {pointsForP2}");
    } else if (pointsForP2 > pointsForP1) {
        Console.WriteLine($"Winner: {Players.P2}, points: {pointsForP2}");
    } else {
        Console.WriteLine("Game matched");
    }
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
    int MenuLength = Enum.GetValues(typeof(MainMenu)).Length;

    if(menuOption < 1 || menuOption > MenuLength) {
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

enum Players {
    P1 = 1,
    P2 = 2
}
