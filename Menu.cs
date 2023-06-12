class Menu
{

    // Wat is een stack?

    // Bovenkant stack
    // ----------------------------
    // ["Login", "Register", "Meer Informatie"] <-- String array (Begin menu)
    // ["Option 1", "Option 2", "Terug"] <-- "Terug" gaat terug naar de array hierboven (begin menu)
    // --------------------------
    // Onderkant stack

    public Stack<string[]> _menuStack;
    public int _selectedOption;
    private User _currentUser;

    Booking booking;


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
            ExtraMenuText(currentMenu);
            if (_currentUser != null)
            {
                Console.WriteLine($"Welkom {_currentUser.First_Name}!\n");
            }

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

    private void ExtraMenuText(string[] currentMenu)
    {

        //Bagage menu
        if (currentMenu.Contains("15kg ruimbagage €22,00"))
        {
            Information.DisplayLugageInfo();
        }
        //Vip-service menu
        else if (currentMenu.Contains("VIP-Pas Toevoegen voor €40,00 PP"))
        {
            Information.DisplayVipInfo();
        }
        else if (currentMenu.Contains("Entertainment toevoegen voor €10,00 PP"))
        {
            Information.DisplayEntertainmentInfo();
        }
        else if (currentMenu.Contains("Lounge toegang toevoegen €35,00 PP"))
        {
            Information.DisplayLoungeInfo();
        }
        else if (currentMenu.Contains("Vlucht-verzekering toevoegen €15,00 PP"))
        {
            Information.DiplayInsuranceInfo();
        }

    }

    private void HandleSelectedOption(string selectedOption)
    {
        _selectedOption = 0;
        Information.DisplayLogo();
        if (selectedOption == "Terug" || selectedOption == "Afmelden" || selectedOption == "Uitloggen")
        {
            if (selectedOption == "Uitloggen") _currentUser = null;

            _menuStack.Pop();
            _selectedOption = 0;
        }
        else if (selectedOption == "Login")
        {
            _currentUser = Login.LoggingIn();
            if (_currentUser == null)
            {
                AddMenu(new[] { "Login", "Registreren", "Meer Informatie" });
                return;
            }
            if (_currentUser.has_Admin)
            {
                AddMenu(new[] { "Vluchten bekijken", "Admin Menu", "Test vliegtuig selectie", "Boeken", "Boekingen bekijken", "Uitloggen" });
            }
            else
            {
                AddMenu(new[] { "Vluchten bekijken", "Boeken", "Boekingen bekijken", "Uitloggen" });
            }
        }
        else if (selectedOption == "Fast")
        {
            _currentUser = new("Issam", "benmassoud", "issam@gmail.com", "Wachtwoord123!");
            if (_currentUser.has_Admin)
            {
                AddMenu(new[] { "Vluchten bekijken", "Admin Menu", "Test vliegtuig selectie", "Uitloggen" });
            }
            else
            {
                AddMenu(new[] { "Vluchten bekijken", "Boeken", "Boekingen bekijken", "Uitloggen" });
            }
        }
        else if (selectedOption == "Fast Admin")
        {
            _currentUser = new("Barrie", "Batsbak", "barriebatsbak@pruters.nl", "Gerrie123!", true);
            _currentUser.can_Book = true;
            if (_currentUser.has_Admin)
            {
                AddMenu(new[] { "Vluchten bekijken", "Admin Menu", "Test vliegtuig selectie", "Boeken", "Boekingen bekijken", "Uitloggen" });
            }
            else
            {
                AddMenu(new[] { "Vluchten bekijken", "Boeken", "Boekingen bekijken", "Uitloggen" });
            }
        }
        else if (selectedOption == "Boekingen bekijken")
        {
            if (Bookings.GetBookings(_currentUser).Count == 0)
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.WriteLine("U heeft nog geen boekingen gemaakt.");
                Console.ReadKey();
            }
            else
            {
                booking = Bookings.GetBookings(_currentUser)[AdminTool.AskMultipleOptions<Booking>("Selecteer een booking waar U de informatie van wilt zien.", Bookings.GetBookings(_currentUser))];
                List<Booking> bookings = booking.GetExtraBookings();
                if (booking.Flight.Time == "--:--")
                {
                    booking.Flight.CancelledMessage();
                }
                else
                {
                    AddMenu(new[] { $"Informatie over vlucht", "Informatie over boeking", "Vlucht annuleren", "Terug" });
                }
            }
        }

        else if (selectedOption == "Vlucht annuleren")
        {
            booking.RemoveFromDatabase();
            Console.WriteLine("De vlucht is geannuleerd");
            Console.ReadKey();
        }
        else if (selectedOption == "Informatie over vlucht")
        {
            booking.Flight.ShowInformation();

        }
        else if (selectedOption == "Informatie over boeking")
        {
            booking.ShowInformation();
            Console.ReadKey();
        }

        else if (selectedOption == "Registreren")
        {
            _currentUser = User.Register();
            if (_currentUser == null)
            {
                Console.ResetColor();
                AddMenu(new[] { "Login", "Registreren", "Meer Informatie", "Fast", "Fast Admin" });
                return;
            }
            if (_currentUser.has_Admin)
            {
                AddMenu(new[] { "Vluchten bekijken", "Admin Menu", "Test vliegtuig selectie", "Boeken", "Boekingen bekijken", "Uitloggen" });
            }
            AddMenu(new[] { "Vluchten bekijken", "Boeken", "Boekingen bekijken", "Uitloggen" });
        }
        else if (selectedOption == "Meer Informatie")
        {
            Information.GetInformation();
        }
        else if (selectedOption == "Vluchten bekijken")
        {
            Flights.CheckFlights();
        }
        else if (selectedOption == "Boeken")
        {
            AddMenu(new[] { "Vlucht boeken", "Terug" });
        }
        else if (selectedOption == "Vluchten lijst bekijken")
        {
        }
        else if (selectedOption == "Vlucht boeken")
        {
            if (!_currentUser.can_Book)
            {
                AddMenu(new[] { "Helaas ben je te jong om te boeken! Je moet minstens 18 jaar oud zijn. Je kunt wel de vluchten bekijken.", "Terug" });
            }
            else
            {
                Bookings.BookingSequence(_currentUser);
            }
        }

        // Extra opties / features bijboeken.
        else if (selectedOption == "Vlucht ervaring uitbreiden")
        {
            AddMenu(new[] { "Bagage-upgrades", "Eten pre-orderen", "Lounge-Toegang", "In-flight entertainment", "VIP-Services", "Vlucht-verzekering", "Terug" });
        }
        else if (selectedOption == "Bagage-upgrades")
        {
            AddMenu(new[] { "15kg ruimbagage €22,00", "20kg ruimbagage €24,00", "25kg ruimbagage €29,00", "30kg ruimbagage €46,00", "Terug" });
        }
        else if (selectedOption == "Eten pre-orderen")
        {
            AddMenu(new[] { "Menu bekijken", "Bestellen", "Terug" });
        }
        else if (selectedOption == "Lounge-Toegang")
        {
            AddMenu(new[] { "Lounge toegang toevoegen €35,00 PP", "Terug" });
        }
        else if (selectedOption == "In-flight entertainment")
        {
            AddMenu(new[] { "Entertainment toevoegen voor €10,00 PP", "Terug" });
        }
        // snelle check-ins, beveiligingscontroles, bagageafhandeling en instappen
        else if (selectedOption == "VIP-Services")
        {
            AddMenu(new[] { "VIP-Pas Toevoegen voor €40,00 PP", "Terug" });
        }
        else if (selectedOption == "Vlucht-verzekering")
        {
            AddMenu(new[] { "Vlucht-verzekering toevoegen €15,00 PP", "Terug" });
        }
        else if (selectedOption == "Menu bekijken")
        {
            Information.DisplayMenuInfo();
        }




        // Admin menu options
        else if (selectedOption == "Admin Menu")
        {
            AddMenu(new[] { "Beheer Vluchten", "Beheer Gebruikers", "Terug" });
        }
        else if (selectedOption == "Beheer Vluchten")
        {
            AddMenu(new[] { "Vlucht Toevoegen", "Vlucht verwijderen", "Vlucht aanpassen", "Terug" });
        }
        else if (selectedOption == "Beheer Gebruikers")
        {
            AddMenu(new[] { "Gebruiker Toevoegen", "Gebruiker Verwijderen", "Gebruiker aanpassen", "Terug" });
        }

        else if (selectedOption == "Vlucht Toevoegen")
        {
            AddMenu(new[] { "Handmatig Toevoegen", "Automatish Genereren", "Terug" });
        }
        else if (selectedOption == "Handmatig Toevoegen")
        {
            AdminTool.AddFlight();
        }
        else if (selectedOption == "Automatish Genereren")
        {
            AddMenu(new[] { "Genereer Aankomende Vluchten", "Genereer Vertrekkende Vluchten", "Terug" });
        }

        else if (selectedOption == "Genereer Aankomende Vluchten")
        {
            AdminTool.GenerateArrivingFlights();
        }
        else if (selectedOption == "Genereer Vertrekkende Vluchten")
        {
            AdminTool.GenerateDepartingFlights();
        }
        else if (selectedOption == "Vlucht verwijderen")
        {
            AddMenu(new[] { "Handmatig Verwijderen", "Alle Vluchten Automatish Verwijderen", "Terug" });
        }

        else if (selectedOption == "Handmatig Verwijderen")
        {
            AdminTool.RemoveFlight();
        }
        else if (selectedOption == "Alle Vluchten Automatish Verwijderen")
        {
            AdminTool.RemoveAllFlights();
        }
        else if (selectedOption == "Vlucht aanpassen")
        {
            AdminTool.ChangeFlight();
        }
        else if (selectedOption == "Gebruiker Toevoegen")
        {
            AdminTool.AddUser();
        }
        else if (selectedOption == "Gebruiker Verwijderen")
        {
            AdminTool.RemoveUser();
        }
        else if (selectedOption == "Gebruiker aanpassen")
        {
            AdminTool.ChangeUser();
        }
        else if (selectedOption == "Test vliegtuig selectie")
        {
            // var seat = DrawBoeing737UI.SelectBoeing737(new Boeing737(), 3);
            var seat = DrawBoeing787UI.SelectBoeing787(new Boeing787(), 3);
            Console.WriteLine("druk op enter om terug te gaan.");
            Console.ReadLine();
        }



    }

    public void AddMenu(string[] options)
    {
        _menuStack.Push(options);
    }
}