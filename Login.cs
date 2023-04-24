using Microsoft.Data.Sqlite;
// to go back to a menu, give HandleSelectedOption("Back");
class Login
{
    private static SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
    public static User? LoggingIn()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Aanmelden\n");

        string email = AskForEmail();
        if (email == null)
        {
            Console.ResetColor();
            return null;
        }

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
        bool falsePassword = false;
        while (true)
        {
            try
            {
                if (!falsePassword)
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.WriteLine("Aanmelden\n");
                    Console.Write("Email: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(email);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write("Wachtwoord: ");
                }
                else
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.WriteLine("Aanmelden\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Verkeerde wachtwoord, probeer opnieuw.");
                    Console.ResetColor();
                    Console.Write("Email: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(email);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write("Wachtwoord: ");
                }
                string password = CheckPassword();
                if (password == null)
                {
                    return null;
                }
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
                    falsePassword = true;
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

    private static string? AskForEmail()
    {
        string? email = "";
        bool falseEmail = false;
        while (true)
        {
            try
            {
                if (!falseEmail)
                {
                    Console.Write("Email: ");
                }
                else
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.WriteLine("Aanmelden\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Verkeerde email, probeer opnieuw.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Email: ");
                }

                email = CheckEmail();
                if (email == null)
                {
                    return email;
                }

                string leftover = "";
                string invertedEmail;
                if (email.Contains("."))
                {
                    invertedEmail = InvertString(email);
                    string[] splitEmail = email.Split('.');
                    leftover = splitEmail[0];
                }
                if (email.Contains("@."))
                {
                    EmailError("Je email moet een domein bevatten.\n");
                    falseEmail = true;
                    continue;
                }
                if (!email.Contains("@"))
                {
                    EmailError("Je email moet ten minste een '@'-teken bevatten.\n");
                    falseEmail = true;
                    continue;
                }
                if (!email.Contains("."))
                {
                    EmailError("Je email moet ten minste een extension bevatten (.com, .nl).\n");
                    falseEmail = true;
                    continue;
                }
                if (email.Length < 8)
                {
                    EmailError("Je email mag niet korter dan 8 tekens zijn.\n");
                    falseEmail = true;
                    continue;
                }
                if (leftover.Length < 2)
                {
                    EmailError("Je email moet een extension bevatten (.com, .nl).\n");
                    falseEmail = true;
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

private static void EmailError(string errorText)
{
    Console.Clear();
    Information.DisplayLogo();
    Console.WriteLine("Aanmelden\n");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(errorText);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Email: ");
    Thread.Sleep(1250);
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
        string invertedEmail = "";
        if (email.Contains("."))
        {
            invertedEmail = InvertString(email);
            string[] splitEmail = invertedEmail.Split('.');
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
        if (email.Contains("@."))
        {
            return false;
        }
        return true;
    }

    private static string? CheckEmail()
    {
        return Input.GetInput(IsValidEmail, 7);
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

    private static bool IsValidPassword(string password)
    {
        if (password.Length > 8 && ContainsSpecialChar(password) && ContainsDigit(password))
        {
            return true;
        }
        return false;
    }

    private static string CheckPassword()
    {
        return Input.GetInput(IsValidPassword, 12);
    }

    private static bool ContainsSpecialChar(string password) {
        foreach (char c in password) {
            if (!Char.IsLetterOrDigit(c)) {
                return true;
            }
        }
        return false;
    }

        private static bool ContainsDigit(string password) {
        foreach (char c in password) {
            if (Char.IsDigit(c)) {
                return true;
            }
        }
        return false;
    }
}