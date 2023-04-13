using Microsoft.Data.Sqlite;
public class Flight
{
    public readonly string? Time, Origin, Destination, Aircraft, State, Gate;
    public Flight(string time, string origin, string destination, string aircraft, string state, string gate)
    {
        Time = time;
        Origin = origin;
        Destination = destination;
        Aircraft = aircraft;
        State = state;
        Gate = gate;
    }

    //"INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('07:00', 'Rotterdam', 'Londen', 'Airbus 330', 'Inactief', 'G6')",

    public static void AddFlight()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Voeg een vlucht toe.");
        Console.WriteLine("Vul de details in.");

        string time = TimeSequence();
        string origin = OriginSequence();
        string destination = DestinationSequence();
        string aircraft = AircraftSequence();
        string state = StateSequence();
        string gate = GateSequence();

        Flight currentflight = new Flight(time, origin, destination, aircraft, state, gate);
        currentflight.AddToDatabase();

        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine($"\n\nDe vlucht is toegevoegd!\n");
        Thread.Sleep(5000);
    }

    private static string AskInformation(string prompt, int minLength)
    {
        // hier kunnen eventuele extra checks toegevoegd worden. 
        while (true)
        {
            Console.WriteLine($"{prompt}: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.Length < minLength)
            {
                Console.WriteLine("Ongeldig formaat.");
                continue;
            }
            return input;
        }
    }

    private static string TimeSequence()
    {
        // deze is met de hand gemaakt, omdat het een speciaal formaat heeft.
        Console.WriteLine("Format: 00:00");
        Console.WriteLine("Tijd: ");
        while (true){
            string time = Console.ReadLine();
            if (time == null){
                continue;
            }
            else if (time.Length != 5){
                Console.WriteLine("Ongeldig formaat.");
                continue;
            }
            else if (time[2] != ':'){
                Console.WriteLine("Ongeldig formaat.");
                continue;
            }
            else{
                return time;
            }
        }
    }

    public static string OriginSequence()
    {
        Console.WriteLine("Voorbeeld: Rotterdam");
        return AskInformation("Vertrek", 3);
    }

    public static string DestinationSequence()
    {
        Console.WriteLine("Voorbeeld: Londen");
        return AskInformation("Bestemming", 3);
    }

    public static string AircraftSequence()
    {
        Console.WriteLine("Voorbeeld: Airbus 330");
        return AskInformation("Vliegtuig", 3);
    }

    public static string StateSequence()
    {
        Console.WriteLine("Voorbeeld: Inactief");
        return AskInformation("Status", 3);
    }

    public static string GateSequence()
    {
        Console.WriteLine("Voorbeeld: G6");
        return AskInformation("Gate", 1);
    }

    public void AddToDatabase()
    {
        string query = $"INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('{Time}', '{Origin}', '{Destination}', '{Aircraft}', '{State}', '{Gate}')";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();

    }
}
