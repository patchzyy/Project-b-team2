using Microsoft.Data.Sqlite;
// to go back to a menu, give HandleSelectedOption("Back");
class Login
{
    private static SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
    public static User LoggingIn()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Sign In\n");

        string email = AskForEmail();

        User userInfo;
        while (true)
        {
            userInfo = GetUser(email);
            if (userInfo != null)
            {
                break;
            }
            email = AskForEmail();
        }

        while (true)
        {
            try
            {
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                if (userInfo.Password == password)
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
                    Console.WriteLine($"Logging succesvol, welkom {userInfo.First_Name}.");
                    Thread.Sleep(2000);
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Vul het juiste format in a.u.b.");
            }
        }

        return userInfo;
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
                    Console.WriteLine("Je email moet ten minste een '@'-teken bevatten.");
                    continue;
                }
                if (!email.Contains("."))
                {
                    Console.WriteLine("Je email moet ten minste een domain name system bevatten.");
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Vul het juiste format in a.u.b.");
            }
        }
        return email;
    }

    private static User GetUser(string email)
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
        User founduser = null;

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string fnameValue = reader.GetString(0);
                string lnameValue = reader.GetString(1);
                string emailValue = reader.GetString(2);
                string passwordValue = reader.GetString(3);
                founduser = new(fnameValue, lnameValue, emailValue, passwordValue);
            }
        }
        else
        {
            Console.WriteLine("De email is niet gevonden, probeer het opnieuw.");
            return null;
        }
        return founduser;
    }
}