using Microsoft.Data.Sqlite;
public static class Bookings{
    public static void BookingSequence(User CurrentUser){
        // informatie die we moeten hebben zijn de vlucht, de stoel en de gebruiker.
        List <Flight> flights = Flights.GetDepartingFlights();
        string? seat;
        Flight SelectedFlight = flights[AdminTool.AskMultipleOptions<Flight>("tijdelijk menu om een vlucht te selecteren", flights)];
        if (SelectedFlight.Aircraft == "Boeing 737"){
            seat = DrawBoeing737UI.SelectBoeing737(new Boeing737());
        }
        if (SelectedFlight.Aircraft == "Boeing 787"){
            // string seat = DrawBoeing787UI.SelectBoeing787(new Boeing787());
            seat = DrawBoeing737UI.SelectBoeing737(new Boeing737());
            Console.WriteLine("Er is iets fout gegaan.");
            Console.WriteLine("We moeten nog de UI voor de Boeing 787 werkend maken dus dit is de ui van de 737.");

        }
        if (SelectedFlight.Aircraft == "Airbus 330"){
            // string seat = DrawAirbus330UI.SelectAirbus330(new Airbus330());
            seat = DrawBoeing737UI.SelectBoeing737(new Boeing737());
            Console.WriteLine("Er is iets fout gegaan.");
            Console.WriteLine("We moeten nog de UI voor de Airbus 330 werkend maken dus dit is de ui van de 737.");
        }
        else{
            Console.WriteLine("Er is iets fout gegaan.");
            seat = "a-1 nep seat";
        }
        // hier vragen we voor alle extra informatie die nodig is voor een booking
        Seat SeatObj = new Seat(seat, false,false,false,false,false,false,false);
        Booking currentbooking = new Booking(CurrentUser, SelectedFlight, SeatObj);
        // voor we het aan de database toevoegen vragen we de gebruiker of alle informatie klopt
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Controleer of alle informatie klopt.");
        Console.WriteLine($"Vlucht van {SelectedFlight.Origin} naar {SelectedFlight.Destination} op {SelectedFlight.Date} om {SelectedFlight.Time}");
        Console.WriteLine($"Stoel: {seat}");
        Console.WriteLine($"Gebruiker: {CurrentUser.First_Name} {CurrentUser.Last_Name}");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();
        currentbooking.AddToDatabase();
        
    }

    public static void MakeDatabaseTables()
    {
        // dit is een method om de tabellen aan te maken, zodat als we ooit iets veranderen aan de database, we niet de hele database opnieuw hoeven te maken vanaf niks.
        string query = $"CREATE TABLE IF NOT EXISTS Bookings (bookingID INTEGER PRIMARY KEY, userEmail STRING, flight INTEGER, seatID INTEGER, baggage BOOLEAN, vip BOOLEAN, entertainment BOOLEAN, lounge BOOLEAN, insurance BOOLEAN)";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }
}