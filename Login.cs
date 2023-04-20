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
                Console.Write("Password: ");
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
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Verkeerde wachtwoord, probeer opnieuw.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vul het juiste format in a.u.b.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        return userInfo;
    }

    private static string AskForEmail()
    {
        string? email = "";
        while (true)
        {
            try
            {
                Console.Write("Email: ");
                // email = Console.ReadLine();
                // Console.WriteLine();

                email = CheckEmail();

                string leftover = "";
                if (email.Contains("."))
                {
                    email = InvertString(email);
                    string[] splitEmail = email.Split('.');
                    leftover = splitEmail[0];
                }

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
                if (leftover.Length < 2)
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je email moet een domein bevatten (.com, .nl).\n");
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

    private static string InvertString(string text)
    {
        string originalString = text;
        char[] charArray = originalString.ToCharArray();
        Array.Reverse(charArray);
        string invertedString = new string(charArray);
        return invertedString;

    }
    // idee: oranje toevoegen als 1 eis goed is maar niet alle
    private static bool IsValidEmail(string email)
    {
        string leftover = "";
        if (email.Contains("."))
        {
            email = InvertString(email);
            string[] splitEmail = email.Split('.');
            leftover = splitEmail[0];
        }

        if (email.Length < 8)
        {
            return false;
        }
        if (!email.Contains("@"))
        {
            return false;
        }
        if (!email.Contains("."))
        {
            return false;
        }
        if (leftover.Length < 2)
        {
            return false;
        }
        return true;
    }

    private static string CheckEmail()
    {
        string? email = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (c == '\r') { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (email.Length > 0) {
                    email = email.Remove(email.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(7, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                email += c;
            }

            if (IsValidEmail(email)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(email);
        }
        Console.WriteLine();
        Console.ResetColor();
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
                string has_admin = reader.GetString(4);
                bool roleValue = has_admin == "1" ? true : false;
                founduser = new(fnameValue, lnameValue, emailValue, passwordValue, roleValue);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("De email is niet gevonden, probeer het opnieuw.\n");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }
        return founduser;
    }
}