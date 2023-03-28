class Program
{

    public static void Main()
    {
        Information.DisplayLogo();
        Thread.Sleep(2000);
        User currentuser = null;
        if (currentuser == null)
        {
            Menu mainmenu = new Menu(new List<string>() { "Login", "Registreer", "Informatie", "Boeken" });
            int selectedOption = mainmenu.ShowMenu();
            // 1: Login, 2: Registreer, 3: Informatie, 4: Boeken
            switch (selectedOption)
            {
                case 1:
                    // Login code
                    break;
                case 2:
                    // Registreer code
                    break;
                case 3:
                    // Informatie code
                    break;
                case 4:
                    // Boeken code
                    break;


            }
        }
        else
        {
            Menu usermenu = new Menu(new List<string>() { "Informatie", "Boeken", "Logout" });
            int selectedOption = usermenu.ShowMenu();
            switch (selectedOption)
            {
                case 1:
                    // Informatie code
                    break;
                case 2:
                    // Boeken code
                    break;
                case 3:
                    // Logout code
                    break;
            }
        }
    }


    /*
    BELANGRIJK:
    Om code te besparen is het hetbeste als we hier de connectie aanmaken naar de database!
    via:
        connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();

    Zo kunnen we de connection meegeven als parameter bij het gebruik van class methods!
    dank alsvast

    -Siebe
    
    */
}