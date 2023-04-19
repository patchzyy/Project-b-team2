public static class AdminTool{

    public static string AskStringInformation(string prompt, int minLength, string example = "")
    {
        // hier kunnen eventuele extra checks toegevoegd worden. 
        while (true)
        {
            Console.Clear();
            Information.DisplayLogo();
            if (example != "")
            {
                Console.WriteLine($"Voorbeeld: {example}");
            }
            Console.WriteLine($"{prompt}: ");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.Length < minLength)
            {
                Console.WriteLine("Ongeldig formaat.");
                Console.ReadKey();
                continue;
            }
            return input;
        }
    }

    //thanks dirk voor dit, hij returned nu de index van de list, en je kunt in princiepe elke soort list gebruiken (bij <t>)
    public static int AskMultipleOptions<T>(string prompt, List<T> options)
    {
        Console.CursorVisible = false;

        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine($"{prompt}: ");

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine(i == selectedIndex ? $"> {options[i]}" : $"  {options[i]}");
                Console.ResetColor();
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Count - 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex++;
                    if (selectedIndex >= options.Count)
                    {
                        selectedIndex = 0;
                    }
                    break;

                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    Console.Clear();
                    return selectedIndex;
            }
        }
    }

    public static void AddFlight()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Voeg een vlucht toe.");
        Console.WriteLine("Vul de details in.");

        string time = TimeSequence();
        string origin = OriginSequence();
        string destination = DestinationSequence();
        string aircraft = AircraftSequence();
        string state = "word berekend";
        string gate = GateSequence();

        Flight currentflight = new Flight(time, origin, destination, aircraft, state, gate);
        currentflight.AddToDatabase();

        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine($"\n\nDe vlucht is toegevoegd!\n");
        Thread.Sleep(5000);
    }
    public static void RemoveFlight(){
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Verwijder een vlucht.");
        List <Flight> flights = new List<Flight>();
        foreach (Flight flight in Flights.GetDepartingFlights())
        {
            flights.Add(flight);
        }
        foreach (Flight flight in Flights.GetArrivingFlights())
        {
            flights.Add(flight);
        }
        Flight FlightToRemove = flights[AskMultipleOptions<Flight>("Selecteer een vlucht om te verwijderen", flights)];
        FlightToRemove.RemoveFromDatabase();
    }

    public static string TimeSequence()
    {
        bool isValid = true;
        while (true)
        {
            if (!isValid)
            {
                Console.WriteLine("Ongeldig formaat.");
                Console.ReadKey(true); 
                isValid = true;
            }
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine("Format: 00:00");
            Console.Write("Tijd: ");

            string time = Console.ReadLine();
            if (time == null)
            {
                isValid = false;
            }
            // dit is echt verschrikkelijk, maar ik kijk handmatig naar de lengte, waar de : is en elke andere char moet een nummer zijn.
            if (time == null || time.Length != 5 || time[2] != ':' ||
            !char.IsDigit(time[0]) ||
            !char.IsDigit(time[1]) ||
            !char.IsDigit(time[3]) ||
            !char.IsDigit(time[4]))
            {
                isValid = false;
            }

            else
            {
                return time;
            }
        }
    }



    public static string OriginSequence()
    {
        return AskStringInformation("Vertrek", 3, "Rotterdam");
    }

    public static string DestinationSequence()
    {
        return AskStringInformation("Bestemming", 3, "Londen");
    }

    public static string AircraftSequence()
    {
        List<string> options = new List<string>{"Airbus 330", "Boeing 737", "Boeing 787"};
        return options[AskMultipleOptions<string>("Vliegtuig", options)];
    }


    public static string GateSequence()
    {
        return AskStringInformation("Gate", 2, "G6");
    }
}