class Menu
{

    // Wat is een stack?

    // Bovenkant stack
    // ----------------------------
    // ["Login", "Register", "More Information"] <-- String array (Begin menu)
    // ["Option 1", "Option 2", "Back"] <-- "Back" gaat terug naar de array hierboven (begin menu)
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
        if (selectedOption == "Back" || selectedOption == "Log Out")
        {
            if(selectedOption == "Log Out") _currentUser = null;

            _menuStack.Pop();
            _selectedOption = 0;
        }
        else if (selectedOption == "Login")
        {
            _currentUser = Login.LoggingIn();
            if (_currentUser.has_Admin){
                AddMenu(new[] { "Check Flights", "Admin Menu", "Log Out" });
            }
            else{
                AddMenu(new[] { "Check Flights", "Log Out" });
            }
        }
        else if (selectedOption == "Register")
        {
            _currentUser = User.Register();
            AddMenu(new[] { "Check Flights", "Log Out" });
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
            AddMenu(new[] { "Manage Flights", "Manage Users", "Back" });
        }
        else if (selectedOption == "Manage Flights")
        {
            AddMenu(new[] { "Add Flight", "Remove Flight", "Back" });
        }
        else if (selectedOption == "Manage Users")
        {
            AddMenu(new[] { "Add User", "Remove User", "Back" });
        }

        else if (selectedOption == "Add Flight")
        {
            Flight.AddFlight();
        }


    }

    public void AddMenu(string[] options)
    {
        _menuStack.Push(options);
    }
}