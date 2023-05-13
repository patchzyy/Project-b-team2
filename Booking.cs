using Microsoft.Data.Sqlite;
public class Booking
{
    public readonly int BookingID;
    public readonly User User;
    public readonly Flight Flight;

    public readonly Seat seat;

    public bool HasBaggage, HasVIP, HasEntertainment, HasLounge, HasInsurance;

    public Booking(User user, Flight flight, Seat seat)
    {
        User = user;
        Flight = flight;
        this.seat = seat;
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

    public void MakeDatabaseTables()
    {
        // dit is een method om de tabellen aan te maken, zodat als we ooit iets veranderen aan de database, we niet de hele database opnieuw hoeven te maken vanaf niks.
        string query = $"CREATE TABLE IF NOT EXISTS Bookings (bookingID INTEGER PRIMARY KEY, userEmail STRING, flight INTEGER, seatID INTEGER, baggage BOOLEAN, vip BOOLEAN, entertainment BOOLEAN, lounge BOOLEAN, insurance BOOLEAN)";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }

    public void AddToDatabase(){
        string query = $"SELECT flightID FROM Flights WHERE duration = '{Flight.Duration}' AND date = '{Flight.Date}' AND time = '{Flight.Time}' AND origin = '{Flight.Origin}' AND destination = '{Flight.Destination}' AND aircraft = '{Flight.Aircraft}' AND gate = '{Flight.Gate}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        SqliteDataReader reader = DatabaseConnection.ExecuteReader();
        int flightID = 0;
        while (reader.Read())
        {
            flightID = reader.GetInt32(0);
        }
        query = $"INSERT INTO Bookings (userEmail, flight, seatID, baggage, vip, entertainment, lounge, insurance) VALUES ('{User.Email}', '{flightID}', '{seat.SeatId}', '{HasBaggage}', '{HasVIP}', '{HasEntertainment}', '{HasLounge}', '{HasInsurance}')";
    }
}
