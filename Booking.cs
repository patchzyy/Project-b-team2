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


    public void AddToDatabase()
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
        string querynew;
        if (ExtraUser != null)
        {
            // eerst moeten we het booking ID vinden van de main booking
            query = $"SELECT bookingID FROM Bookings WHERE userEmail = '{BookingsUser.Email}' AND flight = '{flightID}'";
            DatabaseConnection = new(query, connection);
            reader = DatabaseConnection.ExecuteReader();
            int BookingID = 0;
            while (reader.Read())
            {
                BookingID = reader.GetInt32(0);
            }

            querynew = $"INSERT INTO ExtraUsers (bookingID, masterUserEmail, firstName, lastName) VALUES ('{BookingID}', '{ExtraUser.MasterUser.Email}', '{ExtraUser.FirstName}', '{ExtraUser.LastName}')";

        }
        else
        {
            querynew = $"INSERT INTO Bookings (userEmail, flight, seatID, baggage, vip, entertainment, lounge, insurance) VALUES ('{BookingsUser.Email}', '{flightID}', '{Seat.SeatId}', '{HasBaggage}', '{HasVIP}', '{HasEntertainment}', '{HasLounge}', '{HasInsurance}')";
        }
        DatabaseConnection = new(querynew, connection);
        DatabaseConnection.ExecuteNonQuery();
        Console.WriteLine("Booking added to database");
        //sleep for 3 seconds
        Thread.Sleep(3000);
        connection.Close();

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

}
