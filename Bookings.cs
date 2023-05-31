using Microsoft.Data.Sqlite;
public static class Bookings
{
    public static void BookingSequence(User CurrentUser)
    {
        // informatie die we moeten hebben zijn de vlucht, de stoel en de gebruiker.
        List<Flight> flights = Flights.GetDepartingFlights();
        List<Seat>? seats;
        int AmountOfBookings;


        List<Flight> AllFlights = Flights.GetDepartingFlights();
        List<String> FlightStrings = new List<String>();
        // get the flight destination, if its not in the flightstrings, add it
        foreach (Flight flight in AllFlights)
        {
            if (!FlightStrings.Contains(flight.Destination))
            {
                FlightStrings.Add(flight.Destination);
            }
        }

        // ask for the destination
        string Destination = FlightStrings[AdminTool.AskMultipleOptions<string>("Selecteer een bestemming", FlightStrings)];
        List<Flight> CorrectFlights = new List<Flight>();
        // get all the flights that have the destination AllFlights
        foreach (Flight flight in AllFlights)
        {
            if (flight.Destination == Destination)
            {
                CorrectFlights.Add(flight);
            }
        }

        Flight SelectedFlight = CorrectFlights[AdminTool.AskMultipleOptions<Flight>("Selecteer een vlucht", CorrectFlights)];

        // ask for the amount of users
        AmountOfBookings = AdminTool.AskForInt(1, 10, "Hoeveel mensen wilt u boeken?");

        if (SelectedFlight.Aircraft == "Boeing 737")
        {
            Console.WriteLine("Boeing 737 moet nog geimplementeerd worden.");
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings);
        }
        if (SelectedFlight.Aircraft == "Boeing 787")
        {
            Console.WriteLine("Boeing 787 moet nog geimplementeerd worden.");
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings);
        }
        if (SelectedFlight.Aircraft == "Airbus 330")
        {
            // string seat = DrawAirbus330UI.SelectAirbus330(new Airbus330());
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings);

        }
        else
        {
            Console.WriteLine("Er is iets fout gegaan.");
            return;
        }
        // hier vragen we voor alle extra informatie die nodig is voor een booking
        // nu vragen we voor elke user om de extra informatie
        AmountOfBookings = AmountOfBookings - 1;
        Booking currentbooking = new Booking(CurrentUser, SelectedFlight, seats[0]);
        // voordat we verder kunnen gaan hebben we het paspoortnummer nodig
        string passport = User.PassportSequence();
        currentbooking.AddToDatabase();
        // dit is omdat de main user al een keer is gevraagd om de informatie
        List<ExtraUser> ExtraUsers = new List<ExtraUser>();
        for (int i = 0; i < AmountOfBookings; i++)
        {
            // we vragen voor elke user om de extra informatie
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine($"Gebruiker {i + 2} van {AmountOfBookings + 1}");
            // klik om de informatie te vragen
            Console.WriteLine("Druk op enter om de informatie in te vullen.");
            Console.ReadKey();
            Seat ExtraSeat = seats[i + 1];
            ExtraUser extra = ExtraUser.AskForInformation(CurrentUser, ExtraSeat, SelectedFlight);
            ExtraUsers.Add(extra);
        }
        // nu hebben we alle informatie die we nodig hebben om een booking te maken
        // we maken een booking aan voor de main user

        // we maken een booking aan voor elke extra user
        int seatnumber = 0;
        foreach (ExtraUser Extra in ExtraUsers)
        {
            if (seats.Count > seatnumber) seatnumber++;
            Booking extraBooking = new Booking(CurrentUser, Extra, SelectedFlight, seats[seatnumber]);
        }

        // voor we het aan de database toevoegen vragen we de gebruiker of alle informatie klopt
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Controleer of alle informatie klopt.");
        Console.WriteLine($"Vlucht van {SelectedFlight.Origin} naar {SelectedFlight.Destination} op {SelectedFlight.Date} om {SelectedFlight.Time}");
        Console.WriteLine($"Stoel: {seats[0].SeatId}");
        Console.WriteLine($"Gebruiker: {CurrentUser.First_Name} {CurrentUser.Last_Name}");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();
        // nu vragen we het zelfde voor elke extra user
        seatnumber = 0;
        foreach (ExtraUser Extra in ExtraUsers)
        {
            seatnumber++;
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine("Controleer of alle informatie klopt van de extra gebruikers.");
            Console.WriteLine($"Vlucht van {SelectedFlight.Origin} naar {SelectedFlight.Destination} op {SelectedFlight.Date} om {SelectedFlight.Time}");
            Console.WriteLine($"Stoel: {seats[seatnumber].SeatId}");
            Console.WriteLine($"Gebruiker: {Extra.FirstName} {Extra.LastName}");
            Console.WriteLine("Druk op enter om door te gaan.");
            Console.ReadLine();
        }
        double totalprice = 0;
        foreach (Seat seat in seats)
        {
            totalprice = totalprice + seat.GetTotalPrice(currentbooking.Flight);
        }
        Console.WriteLine($"De totale prijs is: {totalprice}");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();

        // wacht 2 seconden op de betaling
        Console.WriteLine("Wacht 2 seconden op de betaling.");
        Thread.Sleep(2000);
        Console.WriteLine("Betaling gelukt.");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();

    }

    public static List<Booking> GetBookings(User user)
    {
        // this is how the database looks
        // duration = '{Flight.Duration}'  date = '{Flight.Date}'  time = '{Flight.Time}'  origin = '{Flight.Origin}'  destination = '{Flight.Destination}' AND aircraft = '{Flight.Aircraft}' AND gate = '{Flight.Gate}'";

        string query = $"SELECT * FROM Bookings WHERE userEmail = '{user.Email}'";
        // we loop through every booking, make a new booking add it to a list and return that list
        List<Booking> bookings = new List<Booking>();
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand command = new SqliteCommand(query, connection);
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int flight_databaseid = reader.GetInt32(2);
            int seatid = reader.GetInt32(3);
            Flight flight = Flight.GetFlight_Database_id(flight_databaseid);
            // TIJDELIJK, TODO
            Seat seat = new Seat(seatid.ToString(), false, false, false, false, false, false, false);
            Booking booking = new Booking(user, flight, seat);
            bookings.Add(booking);
        }
        connection.Close();
        return bookings;
    }
}