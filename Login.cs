using Microsoft.Data.Sqlite;
using System.Text.RegularExpressions;
// to go back to a menu, give HandleSelectedOption("Back");
class Login
{
    private static SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
    private static string WelcomeUser;
    public static User? LoggingIn()
    {
        Console.Clear();
        Information.DisplayLogo();
        // Console.WriteLine("Aanmelden\n");

        string email = AskForEmail(null);
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
            email = AskForEmail("De gegeven email is niet gevonden, probeer het opnieuw.");
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
                    Information.InputBar();
                    Console.WriteLine("Aanmelden");
                    Console.WriteLine("Email: ");
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
                    Information.InputBar();
                    Console.WriteLine("Aanmelden");
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
                    WelcomeUser = userInfo.First_Name;
                    SuccesLogin(userInfo.First_Name);
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

    private static string? AskForEmail(string errortext)
    {
        string? email = "";
        bool falseEmail = false;
        while (true)
        {
            try
            {
                if (!falseEmail)
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Information.InputBar();
                    Console.WriteLine("Aanmelden");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errortext);
                    Console.ResetColor();
                    Console.Write("Email: ");
                }
                else
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Information.InputBar();
                    Console.WriteLine("Aanmelden");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(errortext);
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
                    errortext = ("Uw email moet een domein bevatten.\n");
                    falseEmail = true;
                    continue;
                }
                if (!email.Contains("@"))
                {
                    errortext = ("Uw email moet ten minste een '@'-teken bevatten.\n");
                    falseEmail = true;
                    continue;
                }
                if (!email.Contains("."))
                {
                    errortext = ("Uw email moet ten minste een extension bevatten (.com, .nl).\n");
                    falseEmail = true;
                    continue;
                }
                if (email.Length < 8)
                {
                    errortext = ("Uw email mag niet korter dan 8 tekens zijn.\n");
                    falseEmail = true;
                    continue;
                }
                if (leftover.Length < 2)
                {
                    errortext = ("Uw email moet een extension bevatten (.com, .nl).\n");
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
        // string leftover = "";
        // string invertedEmail = "";
        // if (email.Contains("."))
        // {
        //     invertedEmail = InvertString(email);
        //     string[] splitEmail = invertedEmail.Split('.');
        //     leftover = splitEmail[0];
        // }

        // if (email.Length < 8)
        // {
        //     return false;
        // }
        // if (!email.Contains("@"))
        // {
        //     return false;
        // }
        // if (!email.Contains("."))
        // {
        //     return false;
        // }
        // if (leftover.Length < 2)
        // {
        //     return false;
        // }
        // if (email.Contains("@."))
        // {
        //     return false;
        // }
        // return true;

        string regex = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        if (Regex.IsMatch(email, regex))
        {
            return true;
        }
        return false;
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
                string phonenumber = reader.GetString(5);
                string dateofbirth = reader.GetString(5);
                string can_book = reader.GetString(5);
                string passport_number = reader.GetString(6);
                string origin = reader.GetString(7);

                bool roleValue = has_admin == "1" ? true : false;
                bool bookValue = can_book == "1" ? true : false;
                founduser = new(fnameValue, lnameValue, emailValue, passwordValue, roleValue);
                founduser.Phonenumber = phonenumber;
                founduser.Date_of_Birth = DateOnly.Parse(dateofbirth);
                founduser.can_Book = bookValue;
                founduser.Passport_Number = passport_number;
                founduser.Origin = origin;
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

    private static void SuccesLogin(string firstname)
    {
        Console.Clear();
        Console.WriteLine("\n\n\n\nLogging in.");
        Thread.Sleep(300);
        Console.Clear();
        Console.WriteLine("\n\n\n\nLogging in..");
        Thread.Sleep(500);
        Console.Clear();
        Console.WriteLine("\n\n\n\nLogging in...");
        Thread.Sleep(190);


        while (true)
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine($"Login succesvol, welkom {firstname}.\n");
            Console.Write("Druk op enter om door te gaan.\n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else
            {
                continue;
            }
        }
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
        // return Input.GetPasswordInput(IsValidPassword, 12);
        string? password = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return null;
            }

            if (c == '\r')
            { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(12, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                password += c;
            }

            foreach (char letter in password)
            {
                Console.Write("*");
            }
        }
        return password;
    }

    private static bool ContainsSpecialChar(string password)
    {
        foreach (char c in password)
        {
            if (!Char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    private static bool ContainsDigit(string password)
    {
        foreach (char c in password)
        {
            if (Char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}