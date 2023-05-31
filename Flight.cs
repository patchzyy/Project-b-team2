using Microsoft.Data.Sqlite;
public class Flight
{
    public readonly int Duration;
    public readonly string? Date, Time, Origin, Destination, Aircraft, Gate;
    public Flight(int duration, string date, string time, string origin, string destination, string aircraft, string gate)
    {
        Duration = duration;
        Date = date;
        Time = time;
        Origin = origin;
        Destination = destination;
        Aircraft = aircraft;
        Gate = gate;
    }

    public void AddToDatabase()
    {
        string query = $"INSERT INTO Flights (duration, date, time, origin, destination, aircraft, gate) VALUES ('{Duration}', '{Date}', '{Time}', '{Origin}', '{Destination}', '{Aircraft}', '{Gate}')";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();

    }
    public void RemoveFromDatabase()
    {
        string query = $"DELETE FROM Flights WHERE duration = '{Duration}' AND date = '{Date}' AND time = '{Time}' AND origin = '{Origin}' AND destination = '{Destination}' AND aircraft = '{Aircraft}' AND gate = '{Gate}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }

    public void UpdateFlightInDatabase(string valueToChange, string newValue)
    {
        string query = valueToChange switch
        {
            "Duur" => $"UPDATE Flights SET duration = '{Convert.ToInt32(newValue)}'",
            "Datum" => $"UPDATE Flights SET date = '{newValue}'",
            "Tijd" => $"UPDATE Flights SET time = '{newValue}'",
            "Afkomst" => $"UPDATE Flights SET origin = '{newValue}'",
            "Bestemming" => $"UPDATE Flights SET destination = '{newValue}'",
            "Vliegtuig" => $"UPDATE Flights SET aircraft = '{newValue}'",
            "Gate" => $"UPDATE Flights SET gate = '{newValue}'",
        };
        query += $" WHERE duration = '{Duration}' AND date = '{Date}' AND time = '{Time}' AND origin = '{Origin}' AND destination = '{Destination}' AND aircraft = '{Aircraft}' AND gate = '{Gate}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }

    public override string ToString()
    {
        return @$"Duration: {Duration} - "
            + @$"Date: {Date} - "
            + @$"Time: {Time} - "
            + @$"Origin: {Origin} - "
            + @$"Destination: {Destination} - "
            + @$"Aircraft: {Aircraft} - "
            + @$"Gate: {Gate}";
    }
    public string GenerateFlightID()
    {
        // FlightID must start with RA- and end with 6 numbers that are unique and generated with the information used for this flight, and end with 2 letters of the destination
        // Example: RA-123456-LO

        // Get the first 2 letters of the destination
        string Destination = this.Destination.Substring(0, 2).ToUpper();
        string Time = this.Time.Replace(":", "");
        string Date = this.Date.Replace("-", "");
        string FlightID = $"RA-{Time}{Date}-{Destination}";
        return FlightID;
    }

    public static Flight GetFlight_Database_id(int id)
    {
        string query = $"SELECT * FROM Flights WHERE id = '{id}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        SqliteDataReader reader = DatabaseConnection.ExecuteReader();
        while (reader.Read())
        {
            int duration = reader.GetInt32(1);
            string date = reader.GetString(2);
            string time = reader.GetString(3);
            string origin = reader.GetString(4);
            string destination = reader.GetString(5);
            string aircraft = reader.GetString(6);
            string gate = reader.GetString(7);
            Flight flight = new Flight(duration, date, time, origin, destination, aircraft, gate);
            return flight;
        }
        return null;

    }
}
