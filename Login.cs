using Microsoft.Data.Sqlite;
// to go back to a menu, give HandleSelectedOption("Back");
class Login
{
    private static SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
    public static void LoggingIn()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Sign In\n");

        string email = AskForEmail();

        string userInfo;
        while (true)
        {
            userInfo = GetUser(email);
            if (userInfo != "")
            {
                break;
            }
            email = AskForEmail();
        }

        string userName = userInfo.Split(",")[0];
        string correctPassword = userInfo.Split(",")[2];

        while (true)
        {
            try
            {
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                if (correctPassword == password)
                {
                    // wat je ook doet, laat deze stukje aan niemand zien aub
                    // HIGH SECRET
                    Console.Clear();
                    Console.WriteLine("\n\n\n\nLogging in.");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("\n\n\n\nLogging in..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("\n\n\n\nLogging in...");
                    Thread.Sleep(190);
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.WriteLine($"Logging succesvol, welkom {userName}.");
                    Thread.Sleep(2000);
                    break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vul het juiste format in a.u.b.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    private static string AskForEmail()
    {
        string? email;
        while (true)
        {
            try
            {
                Console.WriteLine("Email: ");
                email = Console.ReadLine();
                if (!email.Contains("@"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je email moet ten minste een '@'-teken bevatten.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (!email.Contains("."))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je email moet ten minste een domain name system bevatten.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (email.Length < 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je email mag niet korter dan 8 tekens zijn.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vul het juiste format in a.u.b.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        return email;
    }

    private static string GetUser(string email)
    {
        connection.Open();

        string sql = "select * from [Users] where [email] = @email";
        SqliteCommand command = default;
        try
        {
            command = new SqliteCommand(sql, connection);
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong run error. Gebruiker hoort dit niet te zien.");
        }

        // value toevoegen aan de @email
        command.Parameters.AddWithValue("@email", email);

        // om sql queries te kunnen lezen gebruik je Reader
        SqliteDataReader reader = command.ExecuteReader();
        string userInfo = "";

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string nameValue = reader.GetString(1);
                string emailValue = reader.GetString(2);
                string passwordValue = reader.GetString(3);
                userInfo = $"{nameValue},{emailValue},{passwordValue}";
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("De email is niet gevonden, probeer het opnieuw.\n");
            Console.ForegroundColor = ConsoleColor.White;
            return userInfo;
        }
        return userInfo;
    }
}