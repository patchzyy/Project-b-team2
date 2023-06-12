using Microsoft.Data.Sqlite;
public class Booking
{
    public readonly int BookingID;
    public readonly User BookingsUser;
    public readonly ExtraUser ExtraUser;
    public readonly Flight Flight;

    public readonly Seat Seat;
    public readonly List<Seat> ExtraSeats;

    public readonly int phonenumber;


    public bool HasBaggage, HasVIP, HasEntertainment, HasLounge, HasInsurance;

    public Booking(User user, Flight flight, Seat seat)
    {
        BookingsUser = user;
        ExtraUser = null;
        Flight = flight;
        Seat = seat;
        HasBaggage = false;
        HasVIP = false;
        HasEntertainment = false;
        HasLounge = false;
        HasInsurance = false;
    }
    // deze override 
    public Booking(User user, ExtraUser extrauser, Flight flight, Seat seat)
    {
        BookingsUser = user;
        ExtraUser = extrauser;
        Flight = flight;
        Seat = seat;
        HasBaggage = false;
        HasVIP = false;
        HasEntertainment = false;
        HasLounge = false;
        HasInsurance = false;
    }
    public void EnableBaggage()
    {
        HasBaggage = true;
    }
    public void EnableVIP()
    {
        HasVIP = true;
    }
    public void EnableEntertainment()
    {
        HasEntertainment = true;
    }
    public void EnableLounge()
    {
        HasLounge = true;
    }
    public void EnableInsurance()
    {
        HasInsurance = true;
    }

    public int GetFlightID()
    {
        string query = $"SELECT id FROM Flights WHERE duration = '{Flight.Duration}' AND date = '{Flight.Date}' AND time = '{Flight.Time}' AND origin = '{Flight.Origin}' AND destination = '{Flight.Destination}' AND aircraft = '{Flight.Aircraft}' AND gate = '{Flight.Gate}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        SqliteDataReader reader = DatabaseConnection.ExecuteReader();
        int flightID = 0;
        while (reader.Read())
        {
            flightID = reader.GetInt32(0);
        }
        connection.Close();
        return flightID;

    }


    public int GetBookingID()
    {
        string query = $"SELECT bookingID FROM Bookings WHERE userEmail = '{BookingsUser.Email}' AND flight = '{GetFlightID()}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        SqliteDataReader reader = DatabaseConnection.ExecuteReader();
        int bookingID = 0;
        while (reader.Read())
        {
            bookingID = reader.GetInt32(0);
        }
        connection.Close();
        return bookingID;
    }
    public void AddToDatabase()
    {
        int flightID = GetFlightID();
        string connectionString = "Data Source=airline_data.db";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            if (ExtraUser != null)
            {
                string bookingQuery = $"SELECT bookingID FROM Bookings WHERE userEmail = '{BookingsUser.Email}' AND flight = '{flightID}'";
                using (SqliteCommand bookingCommand = new SqliteCommand(bookingQuery, connection))
                {
                    int bookingID = 0;
                    using (SqliteDataReader reader = bookingCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookingID = reader.GetInt32(0);
                        }
                    }
                    string extraUserQuery = $"INSERT INTO ExtraUsers (bookingID, masterUserEmail, firstName, lastName) VALUES ('{bookingID}', '{ExtraUser.MasterUser.Email}', '{ExtraUser.FirstName}', '{ExtraUser.LastName}')";
                    using (SqliteCommand extraUserCommand = new SqliteCommand(extraUserQuery, connection))
                    {
                        extraUserCommand.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                string bookingQuery = $"INSERT INTO Bookings (userEmail, flight, seatID, baggage, vip, entertainment, lounge, insurance) VALUES ('{BookingsUser.Email}', '{flightID}', '{Seat.SeatId}', '{HasBaggage}', '{HasVIP}', '{HasEntertainment}', '{HasLounge}', '{HasInsurance}')";
                using (SqliteCommand bookingCommand = new SqliteCommand(bookingQuery, connection))
                {
                    bookingCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
    }

    public void RemoveFromDatabase()
    {
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();
        // eerst de extra users verwijderen
        string extraUserQuery = $"DELETE FROM ExtraUsers WHERE masterUserEmail = '{BookingsUser.Email}' AND bookingID = '{GetBookingID()}'";
        SqliteCommand extraUserCommand = new(extraUserQuery, connection);
        extraUserCommand.ExecuteNonQuery();
        // dan de booking verwijderen
        string bookingQuery = $"DELETE FROM Bookings WHERE userEmail = '{BookingsUser.Email}' AND bookingID = '{GetBookingID()}'";
        SqliteCommand bookingCommand = new(bookingQuery, connection);
        bookingCommand.ExecuteNonQuery();
        connection.Close();


    }

    public void ShowInformation()
    {
        Console.WriteLine($"Booking ID: {GetBookingID()}");
        Console.WriteLine($"Flight ID: {GetFlightID()}");
        Console.WriteLine($"User: {BookingsUser.Email}");
        Console.WriteLine($"Seat: {Seat.SeatId}");
        if (ExtraUser != null)
        {
            Console.WriteLine($"Extra user: {ExtraUser.FirstName} {ExtraUser.LastName}");
        }
        //you have no baggage / you have baggage one liners
        if (HasBaggage)
            Console.WriteLine("You have baggage");
        if (HasVIP)
            Console.WriteLine("You have VIP");
        if (HasEntertainment)
            Console.WriteLine("You have entertainment");
        if (HasLounge)
            Console.WriteLine("You have lounge");
        if (HasInsurance)
            Console.WriteLine("You have insurance");




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
    public static void MakeDataBaseExtraUsers()
    {
        // deze database gebruikt de extra users, en linkt deze aan bookingen die staan in de bookings database
        string query = $"CREATE TABLE IF NOT EXISTS ExtraUsers (masterUserEmail STRING, firstName STRING, lastName STRING, age INTEGER, seat string, bookingID INTEGER)";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }

    public static void AskForPassportNumber()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Wat is uw paspoortnummer?");
        string passportNumber = Console.ReadLine();
        if (passportNumber.Length == 9)
        {
            Console.WriteLine("Uw paspoortnummer is geldig!");
            Thread.Sleep(2000);
        }
        else
        {
            Console.WriteLine("Uw paspoortnummer is niet geldig!");
            Thread.Sleep(2000);
            AskForPassportNumber();
        }

    }

    public static void ClearDataBase()
    {
        // deze method is om de database te clearen, zodat we niet elke keer de database hoeven te clearen als we iets willen testen, maar niet de hele database willen verwijderen
        string query = $"DROP TABLE Bookings";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();

    }

    public override string ToString()
    {
        // first see how many extra users, use the main user's email to look through the extrausers in the database
        int BookingDatabaseID = GetBookingID();
        string query = $"SELECT * FROM ExtraUsers WHERE masterUserEmail = '{BookingsUser.Email}' AND bookingID = '{BookingDatabaseID}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        SqliteDataReader reader = DatabaseConnection.ExecuteReader();
        int extraUsers = 0;
        while (reader.Read())
        {
            extraUsers++;
        }
        Flight currentflight = Flight;
        connection.Close();
        return $"Vlucht ID: {currentflight.GenerateFlightID()}, Aantal passagiers: {extraUsers + 1}, naar {currentflight.Destination}";
    }


    public List<Booking> GetExtraBookings()
    {
        string mastermail = BookingsUser.Email;
        User MasterUser = BookingsUser;
        int Booking_databaseid = GetFlightID();
        string query = $"SELECT * FROM ExtraUsers WHERE MasterUserEmail = '{mastermail}' AND bookingID = '{Booking_databaseid}'";
        List<Booking> bookings = new List<Booking>();
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand command = new SqliteCommand(query, connection);
        SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string firstname = reader.GetString(1);
            string lastname = reader.GetString(2);
            int seatid = reader.GetInt32(4);
            int age = reader.GetInt32(3);
            Seat seat = new Seat(seatid.ToString(), false, false, false, false, false, false, false);
            ExtraUser extra = new ExtraUser(firstname, lastname, age, MasterUser, seat, Flight);
            Booking extraBooking = new Booking(MasterUser, extra, Flight, seat);
            bookings.Add(extraBooking);
        }
        connection.Close();
        return bookings;
    }

}
