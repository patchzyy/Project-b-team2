class Program
{
    
    public static void Main()
    {
        Console.WriteLine(@"
 ____       _   _               _                 
|  _ \ ___ | |_| |_ ___ _ __ __| | __ _ _ __ ___  
| |_) / _ \| __| __/ _ \ '__/ _` |/ _` | '_ ` _ \ 
|  _ < (_) | |_| ||  __/ | | (_| | (_| | | | | | |
|_| \_\___/ \__|\__\___|_|  \__,_|\__,_|_| |_| |_|
                                                  
    _    _      _ _                 
   / \  (_)_ __| (_)_ __   ___  ___ 
  / _ \ | | '__| | | '_ \ / _ \/ __|
 / ___ \| | |  | | | | | |  __/\__ \
/_/   \_\_|_|  |_|_|_| |_|\___||___/
        
        ");
        Thread.Sleep(2000);
        Console.Write(@"
        Rotterdam Airlines is gevestigd in Rotterdam South Airport in
        ");
        Thread.Sleep(1000);
        Console.WriteLine(@"
        Driemanssteeweg 107,
        3011 WN,
        Rotterdam
        ");
        Thread.Sleep(1000);
        User currentuser = null;
        if (currentuser == null)
        {
        int selectedOption = Menu.ShowMenu(new List<string>() {"Login", "Registreer", "Informatie", "Boeken"});
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
        else{
            int selectedOption = Menu.ShowMenu(new List<string>() {"Informatie", "Boeken", "Logout"});
            switch(selectedOption){
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