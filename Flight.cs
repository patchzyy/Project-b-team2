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
        string flightID = GenerateFlightID();

        string origin = $"Van: {Origin}";
        string destination = $"Naar: {Destination}";

        return $"Vlucht ID: {flightID,-20} - Date: {Date,-25} - Time: {Time,-25}";
    }

    public string GenerateFlightID()
    {
        // FlightID must start with RA- and end with 6 numbers that are unique and generated with the information used for this flight, and end with 2 letters of the destination
        // Example: RA-123456-LO

        // Get the first 2 letters of the destination
        string Destination_short = this.Destination.Substring(0, 2).ToUpper();
        string Origin_short = this.Origin.Substring(0, 2).ToUpper();
        string Time = this.Time.Replace(":", "");
        string Date = this.Date.Replace("-", "");
        string FlightID;
        if (Origin == "Rotterdam") FlightID = $"RA-{Time}{Date}-{Destination_short}";
        else FlightID = $"{Origin_short}-{Time}{Date}-RA";
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
            connection.Close();
            return flight;
        }
        connection.Close();
        return null;

    }

    public static Flight GenerateDepartingFlight()
    {
        int duration = AdminTool.RandomDuration();
        string date = AdminTool.RandomDate();
        string time = AdminTool.RandomTime();
        string origin = "Rotterdam";
        string destination = AdminTool.RandomCity();
        string aircraft = AdminTool.RandomAircraft();
        string gate = AdminTool.RandomGate();
        Flight flight = new Flight(duration, date, time, origin, destination, aircraft, gate);
        return flight;

    }

    public static Flight GenerateArrivingFlight()
    {
        int duration = AdminTool.RandomDuration();
        string date = AdminTool.RandomDate();
        string time = AdminTool.RandomTime();
        string origin = AdminTool.RandomCity();
        string destination = "Rotterdam";
        string aircraft = AdminTool.RandomAircraft();
        string gate = AdminTool.RandomGate();
        Flight flight = new Flight(duration, date, time, origin, destination, aircraft, gate);
        return flight;
    }
    public void ShowInformation()
    {
        Console.Clear();
        Information.DisplayLogo();
        if (Time == "--:--")
        {
            // Console.WriteLine("Deze vlucht is geannuleerd.");
            // print this but make geannuleerd red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Deze vlucht is geannuleerd.");
            Console.ResetColor();
            Console.WriteLine($"U word op de hoogte gehouden over de nieuwe vluchtinformatie van {Origin} naar {Destination}.");
        }
        else
        {
            Console.WriteLine("Vlucht informatie:");
            Console.WriteLine($"Duur: {Duration}");
            Console.WriteLine($"Datum: {Date}");
            Console.WriteLine($"Tijd: {Time}");
            Console.WriteLine($"Afkomst: {Origin}");
            Console.WriteLine($"Bestemming: {Destination}");
            Console.WriteLine($"Vliegtuig: {Aircraft}");
            Console.WriteLine($"Gate: {Gate}");
        }

        Console.WriteLine("Druk op een toets om terug te gaan.");
        Console.ReadKey();
    }

    public void CancelledMessage()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Deze vlucht is geannuleerd.");
        Console.ResetColor();
        Console.WriteLine($"U word op de hoogte gehouden over de nieuwe vluchtinformatie van {Origin} naar {Destination}.");
        Console.WriteLine("Druk op een toets om terug te gaan.");
        Console.ReadKey();
    }
}
