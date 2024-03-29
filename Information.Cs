public class Information
{

    public static void InputBar()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.Write("Verkeerde input");
        Console.ResetColor();
        Console.Write("  |  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Juiste input");
        Console.ResetColor();
        Console.Write("  |  ");
        Console.Write("Druk op ESC om terug te gaan.\n\n");
    }

    public static void BackKey()
    {
        Console.WriteLine("Druk op escape of backspace om terug te gaan");
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape || keyInfo.Key == ConsoleKey.Backspace)
            {
                return;
            }

        } while (keyInfo.Key != ConsoleKey.Enter);
    }

    public static void NextKey()
    {
        Console.WriteLine("Druk op enter om door te gaan");
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                return;
            }

        } while (keyInfo.Key != ConsoleKey.Enter);
    }

    public static void Progressbar(int step, int totalsteps)
    {
        double percentage = (step / (double)totalsteps) * 100;

        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < percentage; i++)
        {
            Console.Write("█");
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i < (100 - percentage); i++)
        {
            Console.Write("░");
        }

        Console.Write($" {Math.Round(percentage, 2)}% ");
        Console.WriteLine("\n");
        Information.InputBar();
        Console.ForegroundColor = ConsoleColor.White;
    }

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
        Console.WriteLine(@"
        U kunt ons bereiken via:
        E-Mail: RotterdamAirlines@RDamSouthAirport.nl
        Telefoon: 010-85785619");
        BackKey();
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

    public static void DisplayLugageInfo()
    {
        Console.WriteLine(@"
Wat zijn de tarieven voor ruimbagage?
-----------------------------------------------------------------------------------------------------------------------
Kom je op de luchthaven met ruimbagage die niet vooraf geboekt en betaald is, dan kun je ter plekke ruimbagage bijkopen.
Er is 10 kg handbagage PP en 0 kg ruimbagage PP inbegrepen. 
-----------------------------------------------------------------------------------------------------------------------

De tarieven voor ruimbagage zijn:
        ");
    }

    public static void DisplayMenuInfo()
    {
        Console.WriteLine(@"
Menu aan boord
-----------------------------------------------------------------------------------------------------------------------
Welkom aan boord bij Rotterdam Airlines. Hieronder vindt u onze selectie van heerlijke gerechten en drankjes die u kunt bestellen.
-----------------------------------------------------------------------------------------------------------------------

Maaltijden:
- Kippenpasta met romige tomatensaus: €12
- Beef stroganoff met rijst: €14
- Vegetarische lasagne: €10
- Salade met gegrilde kip: €8
- Sandwich met gerookte zalm: €9

Snacks:
- Gemengde noten: €4
- Chips: €3
- Olijven: €4

Desserts:
- Brownie: €5
- Vers fruit: €4

Dranken:
- Frisdranken: €2
- Koffie en thee: €3
- Bier: €5
- Wijn: €6

-----------------------------------------------------------------------------------------------------------------------
Laat ons weten als u speciale dieetwensen heeft. Wij hopen dat u geniet van uw vlucht!"
            );

        Console.WriteLine("Druk op enter om terug te gaan.");
        Console.ReadLine();
    }

    public static void DisplayVipInfo()
    {
        Console.WriteLine(@"
VIP services Rotterdam Airlines
-----------------------------------------------------------------------------------------------------------------------
Geen gedoe op de airport? 
Onze Vip Services zorgen voor meer comfort.

VIP-services:
- Snelle check-ins
- Snellere toegang bij beveiligingscontroles
- In-Person bagageafhandeling
- Voorrang bij het instappen

Upgrade naar VIP-services voor slechts €40 per persoon.

----------------------------------------------------------------------------------------------------------------------- 
        ");
    }

    public static void DisplayEntertainmentInfo()
    {
        Console.WriteLine(@"
On-Flight Entertainment
-----------------------------------------------------------------------------------------------------------------------
Maak je vlieg ervaring leuker via On-Flight Entertainment

Bevat:
- Film-Arrangement
    200 films met IMDB rating boven 6,5! 
- Games
    20 games + een controller.
- Muziek
    On-Flight radio
- 1 frisdrank naar keuze

Breidt uit met de entertainment bundel voor slechts €10 per persoon.

----------------------------------------------------------------------------------------------------------------------- 
        ");
    }


    public static void DisplayLoungeInfo()
    {
        Console.WriteLine(@"
Lounge Acces
-----------------------------------------------------------------------------------------------------------------------
Rust nodig? Dat kan!

Met Lounge-Acces kan je genieten van een afgesloten omgeving op het vliegveld
(Deze lounge is alleen beschikbaar voor zij die betaald hebben)

De lounge bevat:
    - Zitplaatsen
    - Sleeppods
    - Verschillende automaten

Beschikbaar voor €35,00 PP
----------------------------------------------------------------------------------------------------------------------- 
        ");
    }

    public static void DiplayInsuranceInfo()
    {
        Console.WriteLine(@"
Vlieg verzekering
-----------------------------------------------------------------------------------------------------------------------
Reizen met meer zekerheid?

Kies voor onze vluchtverzekering:
    Dekking bij reisannulering en onderbreking
    Medische noodgevallen gedekt
    Verlies of vertraging van bagage opgelost
    Vluchtvertraging of annulering vergoed
    24/7 Assistentie beschikbaar

Reis met mentale rust. Sluit vandaag nog uw vluchtverzekering af!

----------------------------------------------------------------------------------------------------------------------- 
        ");
    }
}