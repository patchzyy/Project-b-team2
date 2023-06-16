using Microsoft.Data.Sqlite;
using System.Linq;
using System.Globalization;

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
        List<Flight> CorrectFlights = new List<Flight>();

        foreach (Flight flight in AllFlights)
        {
            if (!FlightStrings.Contains(flight.Destination))
            {
                FlightStrings.Add(flight.Destination);
            }
        }
        foreach (Flight flight in AllFlights)
        {
            if (flight.Time == "--:--")
            {
                CorrectFlights.Remove(flight);
                continue;
            }
            if (AdminTool.ConvertTimeDate(flight.Date, flight.Time) < DateTime.Now)
            {
                CorrectFlights.Remove(flight);
            }
            CorrectFlights.Add(flight);

        }
        if (CorrectFlights.Count == 0)
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Er zijn geen vluchten beschikbaar.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }
        // ask for the destination
        string Destination;
        try
        {
            Destination = FlightStrings[AdminTool.AskMultipleOptions<string>("Selecteer een bestemming", FlightStrings)];
        }
        catch { return; }
        // get all the flights that have the destination AllFlights
        CorrectFlights.Clear();
        foreach (Flight flight in AllFlights)
        {
            if (flight.Destination == Destination)
            {
                CorrectFlights.Add(flight);
            }
        }
        Flight SelectedFlight;
        try
        {
            CorrectFlights = CorrectFlights.OrderBy(flight => DateTime.ParseExact(flight.Date, "dd-MM-yyyy", new CultureInfo("nl-NL"))).ToList();

            SelectedFlight = CorrectFlights[AdminTool.AskMultipleOptions<Flight>("Selecteer een vlucht", CorrectFlights)];
        }
        catch
        {
            return;
        }
        List<Booking> bookings = Bookings.GetBookings(CurrentUser);
        foreach (Booking booking in bookings)
        {
            if (booking.Flight.GenerateFlightID() == SelectedFlight.GenerateFlightID())
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("U heeft deze vlucht al geboekt. Klik op een toets om terug te gaan.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
        }
        // ask for the amount of users
        AmountOfBookings = AdminTool.AskForInt(1, 10, "Voor hoeveel mensen wilt U boeken?\n U kunt voor maximaal 10 mensen boeken.");

        if (SelectedFlight.Aircraft == "Boeing 737")
        {
            seats = DrawBoeing737UI.SelectBoeing737(new Boeing737(), AmountOfBookings, SelectedFlight);
            if (seats.Count == 0)
            {
                Bookings.BookingSequence(CurrentUser);
            }
        }
        else if (SelectedFlight.Aircraft == "Boeing 787")
        {
            seats = DrawBoeing787UI.SelectBoeing787(new Boeing787(), AmountOfBookings, SelectedFlight);
            if (seats.Count == 0)
            {
                Bookings.BookingSequence(CurrentUser);
            }
        }
        else if (SelectedFlight.Aircraft == "Airbus 330")
        {
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings, SelectedFlight);
            if (seats.Count == 0)
            {
                Bookings.BookingSequence(CurrentUser);
            }

        }
        else
        {
            Console.WriteLine("Er is iets fout gegaan.");
            Console.ReadKey();
            return;
        }
        if (seats.Count == 0) return;
        // hier vragen we voor alle extra informatie die nodig is voor een booking
        // nu vragen we voor elke user om de extra informatie
        AmountOfBookings = AmountOfBookings - 1;
        Booking currentbooking = new Booking(CurrentUser, SelectedFlight, seats[0]);
        // voordat we verder kunnen gaan hebben we het paspoortnummer nodig
        // string passport = User.PassportSequence();
        currentbooking.AddToDatabase();
        // dit is omdat de main user al een keer is gevraagd om de informatie
        List<ExtraUser> ExtraUsers = new List<ExtraUser>();
        for (int i = 0; i < AmountOfBookings; i++)
        {
            // we vragen voor elke user om de extra informatie
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine($"Gebruiker {i + 2} van {AmountOfBookings + 1}");
            Console.WriteLine($"Klik op een knop om de informatie voor gebruiker {i + 2} in te vullen.");
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
        Console.WriteLine($"Vlucht van {SelectedFlight.Origin} \n naar {SelectedFlight.Destination} \n Datum: {SelectedFlight.Date} \n Tijd van vertrek {SelectedFlight.Time}");
        Console.WriteLine($"Stoel: {seats[0].SeatId}");
        Console.WriteLine($"Gebruiker: {CurrentUser.First_Name} {CurrentUser.Last_Name}");
        Console.WriteLine("Druk op een knop om verder te gaan.");
        Console.ReadKey();
        // nu vragen we het zelfde voor elke extra user
        seatnumber = 0;
        foreach (ExtraUser Extra in ExtraUsers)
        {
            seatnumber++;
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine("Controleer of alle informatie klopt van de extra gebruikers.");
            Console.WriteLine($"Vlucht van {SelectedFlight.Origin} \n naar {SelectedFlight.Destination} \n Datum: {SelectedFlight.Date} \n Tijd van vertrek {SelectedFlight.Time}");
            Console.WriteLine($"Stoel: {seats[seatnumber].SeatId}");
            Console.WriteLine($"Gebruiker: {Extra.FirstName} {Extra.LastName}");
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey();
        }
        double totalprice = 0;
        foreach (Seat seat in seats)
        {
            totalprice = totalprice + seat.GetTotalPrice(currentbooking.Flight);
        }
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine($"De totale prijs is: {totalprice}");
        Console.WriteLine("Druk op een knop om verder te gaan.");
        Console.ReadKey();
        List<string> options = new List<string>() { "Ja", "Nee" };
        string choice = options[AdminTool.AskMultipleOptions<string>("Wilt u verder gaan met de betaling?", options)];
        if (choice == "Nee")
        {
            Console.WriteLine("Betaling geannuleerd.");
            currentbooking.RemoveFromDatabase();
            foreach (ExtraUser Extra in ExtraUsers)
            {
                Extra.RemoveFromDatabase();
            }
            Console.WriteLine("Druk op enter om door te gaan.");
            Console.ReadLine();
            return;
        }

        List<string> paymentoptions = new List<string>() { "iDeal", "Creditcard" };
        string paymentchoice = paymentoptions[AdminTool.AskMultipleOptions<string>("Kies een betaalmethode.", paymentoptions)];
        // fake loading bar
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Betaling gelukt.");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();

    }

    //in een refactoring van de code is deze statis in de user class met user.Getbookings() is veel logisher haha
    public static List<Booking> GetBookings(User user)
    {
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
            string seatid = reader.GetString(3);
            Flight flight = Flight.GetFlight_Database_id(flight_databaseid);
            String airplane = flight.Aircraft;
            Seat seat = Seat.seat_from_string(seatid, flight.Aircraft);
            Booking booking = new Booking(user, flight, seat);
            bookings.Add(booking);
        }
        connection.Close();
        return bookings;
    }
}