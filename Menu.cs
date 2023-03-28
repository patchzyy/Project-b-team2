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

    public Menu(string[] options)
    {
        _menuStack = new Stack<string[]>();
        _menuStack.Push(options);
        _selectedOption = 0;
    }

    public int Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            string[] currentMenu = _menuStack.Peek();
            Console.WriteLine("Please select an option:");
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
        if (selectedOption == "Back" || selectedOption == "Log Out")
        {
            _menuStack.Pop();
            _selectedOption = 0;
        }
        else if (selectedOption == "Login")
        {
            Login.LoggingIn();
            AddMenu(new[]{"Check Flights", "Log Out"});
        }
        else if (selectedOption == "Register")
        {
            if(User.Register())
            {
                AddMenu(new[]{"Check Flights", "Log Out"});
            }
        }
        else if (selectedOption == "More Info")
        {
            
        }
    }

    public void AddMenu(string[] options)
    {
        _menuStack.Push(options);
    }
}