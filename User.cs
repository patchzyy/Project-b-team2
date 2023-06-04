using Microsoft.Data.Sqlite;
using System.Text.RegularExpressions;

// Admin is geinherrit van User class.
public class User
{
    public int id { get; set; }
    public string First_Name { get; set; }

    public string Last_Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool has_Admin { get; set; }

    public bool can_Book { get; set; }
    public string? Phonenumber { get; set; }
    public DateOnly Date_of_Birth { get; set; }

    public string Passport_Number { get; set; }

    public string Origin { get; set; }



    // Even een constructor om te testen.. Deze test helaas niet of de data wel goed is
    // daarom is het de bedoeling dat de static method "Register" gebruikt wordt.
    public User(string first_name, string last_name, string email, string password, bool has_admin = false)
    {
        First_Name = first_name;
        Last_Name = last_name;
        Email = email;
        Password = password;
        has_Admin = has_admin;
    }

    override public string ToString()
    {
        // gebruik deze methode om de user te printen.
        //Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4}", "Tijd", "Bestemming", "Toestel", "Status", "Gate");
        return $"email: {Email,-20}\t name: {First_Name} {Last_Name}";

    }


    public static User Register()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Laten we elkaar leren kennen!");
        Console.WriteLine("Vul je details in.");

        string first_name = FirstNameSequence();
        if (first_name == null) return null;

        string last_name = LastNameSequence();
        if (last_name == null) return null;

        string email = EmailSequence();
        if (email == null) return null;

        string password = PasswordSequence();
        if (password == null) return null;

        string phonenumber = PhonenumberSequence();
        if (phonenumber == null) return null;

        DateOnly date_of_birth = DateOfBirthSequence();
        if (date_of_birth == null) return null;

        string passport_number = PassportSequence();
        if (passport_number == null) return null;


        string origin = OriginSequence();
        if (origin == null) return null;





        User currentuser = new User(first_name, last_name, email, password);
        currentuser.Phonenumber = phonenumber;
        currentuser.Date_of_Birth = date_of_birth;
        currentuser.Passport_Number = passport_number;
        currentuser.Origin = origin;
        currentuser.AddToDatabase();

        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine($"\n\nWelkom in Rotterdam Airlines, {first_name} {last_name}!\n");
        Thread.Sleep(5000);

        return currentuser;
    }

    // moet in overleg
    public static string OriginSequence()
    {
        Console.Clear();
        Information.DisplayLogo();

        bool validcountry = false;
        string pattern = @"^(?!.*\d)[^\n]{0,58}$";
        string country;
        
        do{
            Console.WriteLine("Wat is uw land van herkomst?");
            country = Console.ReadLine();
            if (Regex.IsMatch(country, pattern)) validcountry = true;
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw invoer is niet goed ingevuld, zorg ervoor dat het \n-Geen nummers heeft\n-Minder dan 58 tekens heeft.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        while(!validcountry);

        return country;
    }

    public static string PassportSequence()
    {
        Console.Clear();
        Information.DisplayLogo();

        bool validnumber = false;
        string pattern = @"^\d{9}$";
        string passportnumber;

        do
        {
            Console.WriteLine("Wat is uw passpoort nummer? (Max 9 getallen)");
            passportnumber = Console.ReadLine();

            if (Regex.IsMatch(passportnumber, pattern)) validnumber = true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zorg ervoor dat het passpoort nummer correct is ingevoerd\nHet bestaat uit 9 getallen en is te vinden op zowel uw id-kaart als passpoort.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

        } while (!validnumber);

        return passportnumber;
    }

    public static string PhonenumberSequence()
    {
        Console.Clear();
        Information.DisplayLogo();

        bool isValidInput = false;
        string phonenumber;

        do
        {
            Console.Write("Wat is uw telefoon nummer? \n+");
            phonenumber = Console.ReadLine();
            phonenumber = phonenumber.Replace(" ", "");

            if (ContainsDigit(phonenumber) && phonenumber.Length > 8 && phonenumber.Length <= 15)
            {
                isValidInput = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zorg ervoor dat het telefoon nummer correct is ingevoerd\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        while (!isValidInput);

        return phonenumber;

    }


    public static DateOnly DateOfBirthSequence()
    {
        Information.DisplayLogo();
        Console.Clear();
        Console.WriteLine("Wat is uw geboorte datum\n DD-MM-JJJJ?\n");

        string pattern = @"^(0[1-9]|1\d|2\d|3[01])-(0[1-9]|1[0-2])-(19|20)\d{2}$";
        int day, month, year;
        string raw_date;
        bool isValidInput = false;

        do
        {
            Console.WriteLine("Geboorte datum: ");
            raw_date = Console.ReadLine();
            if (Regex.IsMatch(raw_date, pattern)) isValidInput = true;

            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Datum verkeerd ingevoerd probeer het opniew (DD-MM-JJJJ)\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        while (!isValidInput);

        string[] date_of_birth = raw_date.Split('-', '/');

        day = int.Parse(date_of_birth[0]);
        month = int.Parse(date_of_birth[1]);
        year = int.Parse(date_of_birth[2]);


        return new DateOnly(year, month, day);
    }





    //Voegt toe nieuwe User toe aan de database..
    // datbase wrapper die de verbinding instand houdt.
    // last rowid, bij user inserrt en dan ID ophalen.
    public void AddToDatabase()
    {
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();

        string sql = "INSERT INTO users (first_name, last_name, email, password, has_admin) VALUES (@first_name, @last_name, @email, @password, @has_admin)";
        using (SqliteCommand command = new SqliteCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@first_name", this.First_Name);
            command.Parameters.AddWithValue("@last_name", this.Last_Name);
            command.Parameters.AddWithValue("@email", this.Email);
            command.Parameters.AddWithValue("@password", this.Password);
            command.Parameters.AddWithValue("@has_admin", this.has_Admin ? 1 : 0);
            command.ExecuteNonQuery();
        }

        connection.Close();
    }

    public void UpdateInDatabase()
    {
        SqliteConnection connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();

        string sql = "UPDATE users SET first_name = @first_name, last_name = @last_name, email = @email, "
                     + "password = @password, has_admin = @has_admin WHERE email = @email2";

        using (SqliteCommand command = new SqliteCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@first_name", this.First_Name);
            command.Parameters.AddWithValue("@last_name", this.Last_Name);
            command.Parameters.AddWithValue("@email", this.Email);
            command.Parameters.AddWithValue("@password", this.Password);
            command.Parameters.AddWithValue("@has_admin", this.has_Admin ? 1 : 0);
            command.Parameters.AddWithValue("@email2", this.Email);
            command.ExecuteNonQuery();
        }

        connection.Close();
    }

    // Hieronder staat alles dat te maken heeft met register... 
    // TODO:    -checken op hoofdletter
    //          -password zo doen dat ipv chars bolletjes komen ter bescherming?
    public static string FirstNameSequence()
    {
        string firstname;
        while (true)
        {
            Console.Write("\nVul je voornaam in: ");
            firstname = CheckFirstName();
            if (firstname == null)
            {
                return null;
            }
            // firstname = Console.ReadLine()!;


            if (string.IsNullOrWhiteSpace(firstname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je voornaam mag niet niks zijn.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }
            if (firstname.Any(char.IsDigit) || ContainsSpecialChar(firstname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je voornaam mag alleen letters bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            return firstname;
        }
    }

    public static bool IsValidFirstName(string firstname)
    {
        if (string.IsNullOrWhiteSpace(firstname))
        {

            return false;
        }
        if (firstname.Any(char.IsDigit) || ContainsSpecialChar(firstname))
        {
            return false;
        }
        return true;
    }

    public static string CheckFirstName()
    {
        return Input.GetInput(IsValidFirstName, 20);
    }


    //last name
    public static string LastNameSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
        while (true)
        {
            Console.Write("Vul je achternaam in: ");
            string lastname = CheckLastName();
            if (lastname == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(lastname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je achternaam mag niet leeg zijn.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            else if (lastname.Any(char.IsDigit) || ContainsSpecialChar(lastname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je achternaam mag alleen letters bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }
            if (lastname.Length < 3)
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je ingevoerde achternaam is te kort om gezien te worden als echt.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            return lastname;
        }

    }

    public static bool IsValidLastName(string lastname)
    {
        if (string.IsNullOrWhiteSpace(lastname))
        {
            return false;
        }
        if (lastname.Any(char.IsDigit) || ContainsSpecialChar(lastname))
        {
            return false;
        }
        return true;
    }

    public static string CheckLastName()
    {
        return Input.GetInput(IsValidLastName, 22);
    }

    public static string EmailSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
        string email = "";
        while (true)
        {
            Console.Write("Vul je emailadres in: ");
            email = CheckEmail();
            if (email == null)
            {
                return null;
            }

            string leftover = "";
            string invertedEmail = "";
            if (email.Contains("."))
            {
                invertedEmail = InvertString(email);
                string[] splitEmail = invertedEmail.Split('.');
                leftover = splitEmail[0];
            }

            if (!email.Contains("@"))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je emailadres moet ten minste een '@' bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            if (!email.Contains("."))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je emailadres moet ten minste een '.' bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }
            if (email.Length < 8)
            {
                Console.Clear();
                Information.DisplayLogo();
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
        return email;
    }

    public static string InvertString(string text)
    {
        string originalString = text;
        char[] charArray = originalString.ToCharArray();
        Array.Reverse(charArray);
        string invertedString = new string(charArray);
        return invertedString;
    }

    public static bool IsValidEmail(string email)
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
        return Input.GetInput(IsValidEmail, 22);
    }

    public static string PasswordSequence()
    {
        Console.Clear();
        Information.DisplayLogo();

        string password = "";
        string? confirmpassword = "";

        while (true)
        {
            Console.WriteLine(@"Vul een wachtwoord in van 8 of meer tekens met:
    - Ten minste 1 numerieke waarde (0-9)
    - Ten minste 1 speciale teken
    ");
            Console.Write("Vul een wachtwoord in: ");
            password = CheckPassword();
            if (password == null)
            {
                return null;
            }

            if (password.Length > 8 && ContainsSpecialChar(password) && ContainsDigit(password))
            {
                Console.WriteLine("Wachtwoord voldoet aan de eisen!\n");
                Console.Write("Bevestig je wachtwoord: ");
                confirmpassword = Console.ReadLine();

                // gebruiker optie geven nieuwe ww of opnieuw duplicate proberen
                if (password != confirmpassword)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("De wachtwoorden verschillen van elkaar, probeer het opnieuw.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Je wachtwoord is correct. Een moment alstublieft.");
                    Thread.Sleep(750);
                    return password;
                }
            }
            // hier missen we nog specifiek laten zien waar user verkeerde input geeft

        }

        return password;
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
        return Input.GetInput(IsValidPassword, 23);
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