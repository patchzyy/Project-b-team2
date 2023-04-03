public class Information
{
    public static void GetInformation()
    {
        Console.Clear();
        Information.DisplayLogo();
        #pragma warning restore format
        Console.WriteLine(@"Rotterdam Airlines is gevestigd in Rotterdam South Airport in:
        Driemanssteeweg 107,
        3011 WN,
        Rotterdam
        ");
        Thread.Sleep(1000);
        Console.WriteLine(@"
        U kunt ons bereiken via:
        E-Mail: RotterdamAirlines@RDamSouthAirport.nl
        Telefoon: 010-85785619");
        Thread.Sleep(1000);
        Console.WriteLine("Druk op enter om terug te gaan.");
        Console.ReadLine();
    }
    public static void DisplayLogo()
    {
        string logo = @"
 ____       _   _               _                        _    _      _ _       
|  _ \ ___ | |_| |_ ___ _ __ __| | __ _ _ __ ___        / \  (_)_ __| (_)_ __    ___  ___ 
| |_) / _ \| __| __/ _ \ '__/ _` |/ _` | '_ ` _ \      / _ \ | | '__| | | '_ \  / _ \/ __|
|  _ < (_) | |_| ||  __/ | | (_| | (_| | | | | | |    / ___ \| | |  | | | | | ||  __/\__ \
|_| \_\___/ \__|\__\___|_|  \__,_|\__,_|_| |_| |_|   /_/   \_\_|_|  |_|_|_| |_| \___||___/
        
        ";
        Console.WriteLine(logo);
    }
    public static void DisplayControls()
    {
        Console.WriteLine(@"
        Instructies om door het menu te navigeren.
        -----------------------------------------------------------------------------------------------------------------------
        Gebruik de pijltjestoetsen om naar boven en beneden te gaan, de pijl (->) geeft aan welke optie U geselecteerd heeft.
        Druk op de ENTER toets om een optie te kiezen
        -----------------------------------------------------------------------------------------------------------------------");
    }
}