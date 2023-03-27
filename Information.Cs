public class Information
{
    public static void GetInformation()
    {
        Console.Write(@"Rotterdam Airlines is gevestigd in Rotterdam South Airport in:
        Driemanssteeweg 107,
        3011 WN,
        Rotterdam
        ");
        Thread.Sleep(1000);
        Console.Write(@"
        U kunt ons bereiken via:
        E-Mail: RotterdamAirlines@RDamSouthAirport.nl
        Telefoon: 010-85785619");
        Thread.Sleep(1000);
    }
    public static void DisplayLogo()
    {
        string logo = @"
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
        
        ";
        Console.WriteLine(logo);
    }
}