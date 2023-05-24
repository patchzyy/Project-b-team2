using Microsoft.Data.Sqlite;
public static class Bookings
{
    public static void BookingSequence(User CurrentUser)
    {
        // informatie die we moeten hebben zijn de vlucht, de stoel en de gebruiker.
        List<Flight> flights = Flights.GetDepartingFlights();
        List<Seat>? seats;
        int AmountOfBookings;
        Flight SelectedFlight = flights[AdminTool.AskMultipleOptions<Flight>("tijdelijk menu om een vlucht te selecteren", flights)];

        // ask for the amount of users
        AmountOfBookings = AdminTool.AskForInt(1, 10, "Hoeveel mensen wilt u boeken?");

        if (SelectedFlight.Aircraft == "Boeing 737")
        {
            Console.WriteLine("Boeing 737 moet nog geimplementeerd worden.");
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings);
        }
        if (SelectedFlight.Aircraft == "Boeing 787")
        {
            Console.WriteLine("Boeing 787 moet nog geimplementeerd worden.");
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings);
        }
        if (SelectedFlight.Aircraft == "Airbus 330")
        {
            // string seat = DrawAirbus330UI.SelectAirbus330(new Airbus330());
            seats = DrawAirbus330UI.SelectAirbus330(new Airbus330(), AmountOfBookings);

        }
        else
        {
            Console.WriteLine("Er is iets fout gegaan.");
            return;
        }
        // hier vragen we voor alle extra informatie die nodig is voor een booking
        // nu vragen we voor elke user om de extra informatie
        AmountOfBookings = AmountOfBookings - 1;
        Booking currentbooking = new Booking(CurrentUser, SelectedFlight, seats[0]);
        currentbooking.AddToDatabase();
        // dit is omdat de main user al een keer is gevraagd om de informatie
        List<ExtraUser> ExtraUsers = new List<ExtraUser>();
        for (int i = 0; i < AmountOfBookings; i++)
        {
            // we vragen voor elke user om de extra informatie
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine($"Gebruiker {i + 2} van {AmountOfBookings + 1}");
            // klik om de informatie te vragen
            Console.WriteLine("Druk op enter om de informatie in te vullen.");
            Console.ReadKey();
            Seat ExtraSeat = seats[i + 1];
            ExtraUser extra = ExtraUser.AskForInformation(CurrentUser, ExtraSeat, SelectedFlight);
            ExtraUsers.Add(extra);
        }
        // nu hebben we alle informatie die we nodig hebben om een booking te maken
        // we maken een booking aan voor de main user

        // we maken een booking aan voor elke extra user
        foreach (ExtraUser Extra in ExtraUsers)
        {
            int seatnumber = 0;
            if (seats.Count > seatnumber) seatnumber++;
            Booking extraBooking = new Booking(CurrentUser, Extra, SelectedFlight, seats[seatnumber]);
        }

        // voor we het aan de database toevoegen vragen we de gebruiker of alle informatie klopt
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Controleer of alle informatie klopt.");
        Console.WriteLine($"Vlucht van {SelectedFlight.Origin} naar {SelectedFlight.Destination} op {SelectedFlight.Date} om {SelectedFlight.Time}");
        Console.WriteLine($"Stoel: {seats[0]}");
        Console.WriteLine($"Gebruiker: {CurrentUser.First_Name} {CurrentUser.Last_Name}");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();
        double totalprice = 0;
        foreach (Seat seat in seats)
        {
            totalprice = totalprice + seat.GetTotalPrice(currentbooking.Flight);
        }
        Console.WriteLine($"De totale prijs is: {totalprice}");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();

        // wacht 4 seconden op de betaling
        Console.WriteLine("Wacht 4 seconden op de betaling.");
        Thread.Sleep(4000);
        Console.WriteLine("Betaling gelukt.");
        Console.WriteLine("Druk op enter om door te gaan.");
        Console.ReadLine();
        currentbooking.AddToDatabase();

    }


}