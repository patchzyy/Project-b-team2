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
}
