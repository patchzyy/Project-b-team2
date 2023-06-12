using Microsoft.Data.Sqlite;
public static class AdminTool
{

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
        int currentPage = 1;
        int pageSize = 20;

        while (true)
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine($"{prompt}: ");
            if (options.Count > 19)
            {
                Console.WriteLine($"Pagina {currentPage}");
            }
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, options.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                Console.WriteLine(i == selectedIndex ? $"> {options[i]}" : $"  {options[i]}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Gebruik de pijltjestoetsen om te navigeren. Druk op Enter om te selecteren. Druk op Escape om terug te gaan.");

            if (currentPage > 1)
            {
                Console.WriteLine("Gebruik de PageUp-toets om terug te gaan naar de vorige pagina.");
            }

            if (endIndex < options.Count)
            {
                Console.WriteLine("Gebruik de PageDown-toets om naar de volgende pagina te gaan.");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex--;
                    if (selectedIndex < startIndex)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;
                            startIndex -= pageSize;
                            endIndex = Math.Min(startIndex + pageSize, options.Count);
                            selectedIndex = endIndex - 1;
                        }
                        else
                        {
                            selectedIndex = options.Count - 1;
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex++;
                    if (selectedIndex >= endIndex)
                    {
                        if (endIndex < options.Count)
                        {
                            currentPage++;
                            startIndex += pageSize;
                            endIndex = Math.Min(startIndex + pageSize, options.Count);
                            selectedIndex = startIndex;
                        }
                        else
                        {
                            selectedIndex = startIndex;
                        }
                    }
                    break;

                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    Console.Clear();
                    return selectedIndex;

                case ConsoleKey.Escape:
                    return -1;

                case ConsoleKey.PageUp:
                    if (currentPage > 1)
                    {
                        currentPage--;
                        startIndex = (currentPage - 1) * pageSize;
                        endIndex = Math.Min(startIndex + pageSize, options.Count);
                        selectedIndex = Math.Min(selectedIndex, endIndex - 1);
                    }
                    break;

                case ConsoleKey.PageDown:
                    if (endIndex < options.Count)
                    {
                        currentPage++;
                        startIndex = (currentPage - 1) * pageSize;
                        endIndex = Math.Min(startIndex + pageSize, options.Count);
                        selectedIndex = startIndex;
                    }
                    break;
            }
        }
    }




    public static void AddBooking(Flight flight, User user, Seat seat)
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Details aan het ophalen...");
        Thread.Sleep(1000);
        string First_Name = user.First_Name;
        Seat Seat = seat;

        Booking currentbooking = new Booking(user, flight, Seat);
        Console.Clear();
        Information.DisplayLogo();
        // hier vragen we voor alle extra informatie die nodig is voor een booking
        currentbooking.AddToDatabase();
        Menu menu = new Menu(new string[] { "" });
        Thread.Sleep(5000);
    }
    public static void AddFlight()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Voeg een vlucht toe.");
        Console.WriteLine("Vul de details in.");

        int duration = DurationSequence();
        string date = DateSequence();
        string time = TimeSequence();
        string origin = OriginSequence();
        string destination = DestinationSequence();
        string aircraft = AircraftSequence();
        string gate = GateSequence();

        Flight currentflight = new Flight(duration, date, time, origin, destination, aircraft, gate);
        currentflight.AddToDatabase();

        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine($"\n\nDe vlucht is toegevoegd!\n");
        Thread.Sleep(5000);
    }
    public static void RemoveFlight()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Verwijder een vlucht.");
        List<Flight> flights = new List<Flight>();
        foreach (Flight flight in Flights.GetDepartingFlights())
        {
            flights.Add(flight);
        }
        foreach (Flight flight in Flights.GetArrivingFlights())
        {
            flights.Add(flight);
        }
        Flight FlightToRemove;
        try
        {
            FlightToRemove = flights[AskMultipleOptions<Flight>("Selecteer een vlucht om te verwijderen", flights)];
        }
        catch
        {
            return;
        }
        FlightToRemove.RemoveFromDatabase();
    }

    public static void ChangeFlight()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Pas een vlucht aan.");
        List<Flight> flights = new List<Flight>();
        foreach (Flight flight in Flights.GetDepartingFlights())
        {
            flights.Add(flight);
        }
        foreach (Flight flight in Flights.GetArrivingFlights())
        {
            flights.Add(flight);
        }
        Flight selectedFlight;
        try
        {
            selectedFlight = flights[AskMultipleOptions<Flight>("Selecteer een vlucht om aan te passen", flights)];
        }
        catch
        {
            return;
        }
        List<string> optionList = new List<string>() { "Duur", "Datum", "Tijd", "Afkomst", "Bestemming", "Vliegtuig", "Gate", "Vlucht annuleren", "Terug" };
        string selectedOption = optionList[AskMultipleOptions<string>("Selecteer het onderdeel dat u wilt aanpassen", optionList)];
        Console.WriteLine("Voer de nieuwe waarde in");
        if (selectedOption == "Duur")
        {
            int duration = DurationSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, Convert.ToString(duration));
        }
        else if (selectedOption == "Datum")
        {
            string date = DateSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, date);
        }
        else if (selectedOption == "Tijd")
        {
            string time = TimeSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, time);
        }
        else if (selectedOption == "Afkomst")
        {
            string origin = OriginSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, origin);
        }
        else if (selectedOption == "Bestemming")
        {
            string destination = DestinationSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, destination);
        }
        else if (selectedOption == "Vliegtuig")
        {
            string aircraft = AircraftSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, aircraft);
        }
        else if (selectedOption == "Gate")
        {
            string gate = GateSequence();
            selectedFlight.UpdateFlightInDatabase(selectedOption, gate);
        }
        else if (selectedOption == "Vlucht annuleren")
        {
            CancelFlightSequence(selectedFlight);
        }
        else if (selectedOption == "Terug")
        {
            ChangeFlight();
        }
        Console.WriteLine("Gelukt! De aanpassingen aan de vlucht zijn doorgevoerd.");
        Console.ReadKey();
    }

    public static int DurationSequence()
    {
        return Convert.ToInt32(AskStringInformation("De duur van de vlucht (IN MINUTEN!)", 1, "120"));
    }

    public static string DateSequence()
    {
        return AskStringInformation("De datum van de vlucht (DD-MM-YY format. Dag, Maand, Jaar)", 9, "1");
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


    public static int AskForInt(int min, int max, string prompt)
    {
        while (true)
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            int number;
            try
            {
                number = Convert.ToInt32(input);
                if (number < min || number > max)
                {
                    Console.WriteLine($"Ongeldige invoer. U kunt alleen maar tussen {min} en {max} kiezen.");
                    Console.ReadKey(true);
                    continue;
                }
                return number;
            }
            catch
            {
                Console.WriteLine("Ongeldige invoer.");
                Console.ReadKey(true);
                continue;
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
        List<string> options = new List<string> { "Airbus 330", "Boeing 737", "Boeing 787" };
        return options[AskMultipleOptions<string>("Vliegtuig", options)];
    }


    public static string GateSequence()
    {
        return AskStringInformation("Gate", 2, "G6");
    }

    public static void CancelFlightSequence(Flight flight)
    {
        List<string> options = new List<string> { "Ja", "Nee" };
        string selectedOption = options[AskMultipleOptions<string>("Weet u zeker dat u deze vlucht wilt annuleren?", options)];
        if (selectedOption == "Ja")
        {
            flight.UpdateFlightInDatabase("Tijd", "--:--");
        }
        if (selectedOption == "Nee")
        {
            ChangeFlight();
        }
    }

    public static int? HasAdminSequence(bool currentlyHasAdmin)
    {
        Console.Clear();
        Information.DisplayLogo();

        if (currentlyHasAdmin)
        {
            List<string> options = new List<string> { "Ja", "Nee" };
            string selectedOption = options[AskMultipleOptions<string>("Deze gebruiker heeft op dit moment admin. Wilt u de admin rechten van deze gebruiker ontzeggen?", options)];
            if (selectedOption == "Ja")
            {
                return 0;
            }
            else if (selectedOption == "Nee")
            {
                return null;
            }
        }

        if (!currentlyHasAdmin)
        {
            List<string> options = new List<string> { "Ja", "Nee" };
            string selectedOption = options[AskMultipleOptions<string>("Deze gebruiker heeft op dit moment geen admin. Wilt u deze gebruiker admin rechten geven?", options)];
            if (selectedOption == "Ja")
            {
                return 1;
            }
            else if (selectedOption == "Nee")
            {
                return null;
            }
        }
        return null;
    }

    public static void AddUser()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Voeg een gebruiker toe.");
        Console.WriteLine("dit is een tijdelijke implementatie, er word nog niks gechecked!");
        Console.WriteLine("Vul de details in.");
        string email = AskStringInformation("Email", 3);
        string password = AskStringInformation("Wachtwoord", 3);
        string first_name = AskStringInformation("Voornaam", 3);
        string last_name = AskStringInformation("Achternaam", 3);
        List<string> options = new List<string> { "true", "false" };
        bool role = Convert.ToBoolean(options[AskMultipleOptions("admin?", options)]);
        User user = new User(first_name, last_name, email, password, role);
        user.AddToDatabase();
    }
    public static List<User> GetAllUsers()
    {
        // cconnect to database
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();

        // create command
        SqliteCommand command = new SqliteCommand("SELECT * FROM users", connection);
        // execute command
        SqliteDataReader reader = command.ExecuteReader();
        // read data and return a list of users
        List<User> users = new List<User>();
        while (reader.Read())
        {
            users.Add(new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4)));
        }
        return users;
    }

    public static void RemoveUser()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Verwijder een gebruiker.");
        List<User> users = new List<User>();
        foreach (User user in GetAllUsers())
        {
            users.Add(user);

        }
        User UserToRemove;
        try
        {
            UserToRemove = users[AskMultipleOptions<User>("Selecteer een gebruiker om te verwijderen", users)];
        }
        catch
        {
            return;
        }
        string email = UserToRemove.Email;

        // ask the user if they are sure
        Console.Clear();
        Information.DisplayLogo();
        List<string> options = new List<string> { "Ja", "Nee" };
        if (options[AskMultipleOptions($"Weet je zeker dat je {email} wilt verwijderen?", options)] == "Nee")
        {
            return;
        }
        // look thought the database and remove the matching email
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();
        string query = $"DELETE FROM users WHERE email = '{email}'";
        SqliteCommand command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
        connection.Close();

    }

    public static void ChangeUser()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Pas een gebruiker aan.");
        List<User> users = new List<User>();
        foreach (User user in GetAllUsers())
        {
            users.Add(user);

        }
        User selectedUser;
        try
        {
            selectedUser = users[AskMultipleOptions<User>("Selecteer een gebruiker om aan te passen", users)];
        }
        catch
        {
            return;
        }
        List<string> optionList = new List<string>() { "Voornaam", "Achternaam", "Email", "Wachtwoord", "Admin rechten", "Terug" };
        string selectedOption = optionList[AskMultipleOptions<string>("Selecteer het onderdeel dat u wilt aanpassen", optionList)];
        Console.WriteLine("Voer de nieuwe waarde in");
        if (selectedOption == "Voornaam")
        {
            string first_name = User.FirstNameSequence();
            selectedUser.First_Name = first_name;
        }
        else if (selectedOption == "Achternaam")
        {
            string last_name = User.LastNameSequence();
            selectedUser.Last_Name = last_name;
        }
        else if (selectedOption == "Email")
        {
            string email = User.EmailSequence();
            selectedUser.Email = email;
        }
        else if (selectedOption == "Wachtwoord")
        {
            string password = User.PasswordSequence();
            selectedUser.Password = password;
        }
        else if (selectedOption == "Admin rechten")
        {
            int? has_admin = HasAdminSequence(selectedUser.has_Admin);
            selectedUser.has_Admin = true ? has_admin == 1 : false;
        }
        else if (selectedOption == "Terug")
        {
            ChangeUser();
        }
        selectedUser.UpdateInDatabase();
        Console.WriteLine("Gelukt! De aanpassingen aan de gebruiker zijn doorgevoerd.");
        Console.ReadKey();
    }

    public static DateTime ConvertTimeDate(string date, string time)
    {
        if (time == "--:--") return DateTime.Now;
        string[] timeArray = time.Split(":");
        int hours = Convert.ToInt32(timeArray[0]);
        int minutes = Convert.ToInt32(timeArray[1]);
        string[] dateArray = date.Split("-");
        int day = Convert.ToInt32(dateArray[0]);
        int month = Convert.ToInt32(dateArray[1]);
        int year = Convert.ToInt32(dateArray[2]);
        DateTime dateTime = new DateTime(year, month, day, hours, minutes, 0);
        return dateTime;
    }

    public static int RandomDuration(string city)
    {
        Random random = new Random();
        int baseDuration = random.Next(60, 120);
        baseDuration = baseDuration - (baseDuration % 30);

        int duration;
        switch (city)
        {
            case "Barcelona":
            case "Madrid":
                duration = baseDuration + 120;
                break;
            case "Berlijn":
                duration = baseDuration + 60;
                break;
            case "Brussel":
                duration = baseDuration + 30;
                break;
            case "Dubai":
            case "New York":
            case "Tokyo":
                duration = baseDuration + 360;
                break;
            case "Londen":
            case "Parijs":
            case "Rome":
                duration = baseDuration + 90;
                break;
            default:
                duration = baseDuration;
                break;
        }

        return duration;
    }


    public static string RandomDate()
    {
        Random random = new Random();
        int month = random.Next(1, 12);
        int maxDays = 30;

        if (month == 2)
            maxDays = 28;

        int day = random.Next(1, maxDays);
        int year = random.Next(2023, 2024);

        string formattedMonth = month.ToString("00");
        string formattedDay = day.ToString("00");

        string date = $"{formattedDay}-{formattedMonth}-{year}";
        return date;
    }


    public static string RandomTime()
    {
        Random random = new Random();
        int hours = random.Next(0, 23);
        int minutes = random.Next(0, 59);
        minutes = minutes - (minutes % 10);
        // make sure its formatted 01:01 not 1:1 with lambda expression
        string hourstring = hours.ToString().Length == 1 ? $"0{hours}" : hours.ToString();
        string minutestring = minutes.ToString().Length == 1 ? $"0{minutes}" : minutes.ToString();
        string time = $"{hourstring}:{minutestring}";
        return time;
    }

    public static string RandomCity()
    {
        // HIER NOOIT ROTTERDAM AAN TOEVOEGEN
        List<string> cities = new List<string>() { "Barcelona", "Berlijn", "Brussel", "Dubai", "Londen", "Madrid", "New York", "Parijs", "Rome", "Tokyo" };
        Random random = new Random();
        int index = random.Next(0, cities.Count);
        return cities[index];
    }

    public static string RandomAircraft()
    {
        List<string> aircrafts = new List<string>() { "Boeing 737", "Airbus 330", "Boeing 787" };
        Random random = new Random();
        int index = random.Next(0, 2);
        return aircrafts[index];
    }

    public static string RandomGate()
    {
        Random random = new Random();
        int letter = random.Next(65, 71);
        int number = random.Next(1, 21);
        string gate = $"{(char)letter}{number}";
        return gate;
    }

    public static void GenerateDepartingFlights()
    {
        int amount = AskHowManyFlights();
        Flights.GenerateDepartingFlightScedule(amount);

    }

    public static void GenerateArrivingFlights()
    {
        int amount = AskHowManyFlights();
        Flights.GenerateArrivingFlightScedule(amount);

    }

    public static int AskHowManyFlights()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Hoeveel vluchten wilt u genereren?");
        int amount = AskNumber();
        return amount;
    }

    public static int AskNumber()
    {
        int number;
        while (true)
        {
            string nr = Console.ReadLine();
            try { number = Convert.ToInt32(nr); break; }
            catch
            {
                Console.WriteLine("Voer een geldig getal in.");
            }
        }
        return number;
    }

    public static void RemoveAllFlights()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Weet je zeker dat je alle vluchten wilt verwijderen?");
        List<string> options = new List<string> { "Ja", "Nee" };
        if (options[AskMultipleOptions($"Weet je zeker dat je alle vluchten wilt verwijderen?", options)] == "Nee")
        {
            return;
        }
        // look thought the database and remove the matching email
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();
        string query = $"DELETE FROM flights";
        SqliteCommand command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
        connection.Close();
        // also clear all bookings
        connection.Open();
        query = $"DELETE FROM bookings";
        command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
        connection.Close();
        // delete from extrausers
        connection.Open();
        query = $"DELETE FROM extrausers";
        command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
        connection.Close();

    }
}