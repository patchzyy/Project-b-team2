class Menu
{

    // Wat is een stack?

    // Bovenkant stack
    // ----------------------------
    // ["Login", "Register", "More Information"] <-- String array (Begin menu)
    // ["Option 1", "Option 2", "Terug"] <-- "Terug" gaat terug naar de array hierboven (begin menu)
    // --------------------------
    // Onderkant stack

    private Stack<string[]> _menuStack;
    private int _selectedOption;
    private User _currentUser;

    public Menu(string[] options)
    {
        _menuStack = new Stack<string[]>();
        _menuStack.Push(options);
        _selectedOption = 0;
        _currentUser = null;
    }

    public int Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Information.DisplayLogo();
            string[] currentMenu = _menuStack.Peek();
            Console.WriteLine("Selecteer een optie:");
            for (int i = 0; i < currentMenu.Length; i++)
            {
                Console.WriteLine(i == _selectedOption ? $"> {currentMenu[i]}" : $"  {currentMenu[i]}");
            }

            var keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_selectedOption > 0)
                    {
                        _selectedOption--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_selectedOption < currentMenu.Length - 1)
                    {
                        _selectedOption++;
                    }
                    break;
                case ConsoleKey.Enter:
                    string selectedOption = currentMenu[_selectedOption];
                    HandleSelectedOption(selectedOption);
                    break;
                case ConsoleKey.Escape:
                    if (_menuStack.Count > 1)
                    {
                        _menuStack.Pop();
                        _selectedOption = 0;
                    }
                    break;
            }
        }

        return _selectedOption;
    }

    private void HandleSelectedOption(string selectedOption)
    {
        Information.DisplayLogo();
        if (selectedOption == "Terug" || selectedOption == "Afmelden")
        {
            if(selectedOption == "Uitloggen") _currentUser = null;

            _menuStack.Pop();
            _selectedOption = 0;
        }
        else if (selectedOption == "Login")
        {
            _currentUser = Login.LoggingIn();
            if (_currentUser == null)
            {
                AddMenu(new[] { "Login", "Register", "More Information" });
                return;
            }
            if (_currentUser.has_Admin){
                AddMenu(new[] { "Check Flights", "Admin Menu", "Uitloggen" });
            }
            else{
                AddMenu(new[] { "Check Flights", "Uitloggen" });
            }
        }
        else if (selectedOption == "Register")
        {
            _currentUser = User.Register();
            if (_currentUser == null)
            {
                Console.ResetColor();
                AddMenu(new[] { "Login", "Register", "More Information" });
                return;
            }
            AddMenu(new[] { "Check Flights", "Uitloggen" });
        }
        else if (selectedOption == "More Information")
        {
            Information.GetInformation();
        }
        else if (selectedOption == "Check Flights")
        {
            Thread.Sleep(1000);
            Information.DisplayLogo();
            Flights.DisplayArrivingFlights();
            Console.WriteLine("");
            Flights.DisplayDepartingFlights();
            Console.WriteLine("\n\nDruk op enter om terug te gaan.");
            Console.ReadLine();
        }


        // Admin menu options
        else if (selectedOption == "Admin Menu")
        {
            AddMenu(new[] { "Beheer Vluchten", "Beheer Gebruikers", "Terug" });
        }
        else if (selectedOption == "Beheer Vluchten")
        {
            AddMenu(new[] { "Vlucht Toevoegen", "Vlucht verwijderen", "Terug" });
        }
        else if (selectedOption == "Beheer Gebruikers")
        {
            AddMenu(new[] { "Gebruiker Toevoegen", "Gebruiker Verwijderen", "Terug" });
        }

        else if (selectedOption == "Vlucht Toevoegen")
        {
            AdminTool.AddFlight();
        }
        else if (selectedOption == "Vlucht verwijderen")
        {
            AdminTool.RemoveFlight();
        }
        else if (selectedOption == "Gebruiker Toevoegen"){
            AdminTool.AddUser();
        }
        else if (selectedOption == "Gebruiker Verwijderen"){
            AdminTool.RemoveUser();
        }



    }

    public void AddMenu(string[] options)
    {
        _menuStack.Push(options);
    }
}