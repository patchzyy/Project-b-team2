public class Seat
{
    public string SeatId { get; set; }
    public bool ExtraBeenRuimte { get; set; }
    public bool IsReserved { get; set; }
    public bool IsClubClass { get; set; }
    public bool IsDoubleSeat { get; set; }
    public bool IsFrontSeat { get; set; }
    public bool IsBusinessClass { get; set; }
    public bool IsEconomyPlus { get; set; }
    public bool IsEconomy { get; set; }
    public int BasePrice { get; set; }
    public Seat(string seatId, bool extraBeenRuimte, bool isClubClass, bool isDoubleSeat, bool isFrontSeat, bool isBusinessClass, bool isEconomyPlus, bool isEconomy)
    {
        this.SeatId = seatId;
        this.ExtraBeenRuimte = extraBeenRuimte;
        this.IsClubClass = isClubClass;
        this.IsDoubleSeat = isDoubleSeat;
        this.IsFrontSeat = isFrontSeat;
        this.IsBusinessClass = isBusinessClass;
        this.IsEconomyPlus = isEconomyPlus;
        this.IsEconomy = isEconomy;
        this.BasePrice = 100;
    }

    public double SeatPrice()
    {
        double beenruimte = 1.2;
        double clubclass = 2;
        double doubleseat = 1.3;
        double frontseat = 1.25;
        double businessclass = 2;
        double economyplus = 1.5;
        double economy = 1;

        double Price = BasePrice;
        /* 
        als ik de FlightDuration weet kan ik iet doen van Price (Basisprijs + factor van eventuele bijzonderheden)
        en dan daar de DuurPrijs daar bij vermenigvuldigen met het aantal uren (bijvoorbeeld 50 euro per uur erbij bij)
        
        *voorbeeld*
        dan krijg je de (basisprijs + extra beenruimte) + Duurprijs * aantal uren
        dus (100 * 1.2) + (50 * 6)
        dat is dan een vlucht van 6 uur waarbij een stoel met extra beenruimte is gereserveerd

        factor kan trouwens ook nog gewoon een vaste prijs zijn die erbij komt dat is misschien makkelijker
        */
        if (ExtraBeenRuimte)
        {
            if (IsFrontSeat)
            {
                Price = BasePrice * beenruimte * frontseat;
                return Price;
            }
            else
            {
                Price = BasePrice * beenruimte;
                return Price;
            }
        }
        if (IsClubClass)
        {
            Price = BasePrice * clubclass;
            return Price;
        }
        if (IsDoubleSeat)
        {
            Price = BasePrice * doubleseat;
            return Price;
        }
        if (IsFrontSeat)
        {
            Price = BasePrice * frontseat;
            return Price;
        }
        if (IsBusinessClass)
        {
            Price = BasePrice * businessclass;
            return Price;
        }
        if (IsEconomyPlus)
        {
            Price = BasePrice * economyplus;
            return Price;
        }
        if (IsEconomy)
        {
            Price = BasePrice * economy;
            return Price;
        }
        else
            return Price;
    }

    public double GetTotalPrice(Flight flight)
    {
        return SeatPrice() + DurationPrice(flight);
    }

    public double DurationPrice(Flight flight)
    {
        double PricePerMinute = 0.75;
        double DurationPrice = 0.0;
        return DurationPrice + flight.Duration * PricePerMinute;
    }

    public static Seat seat_from_string(string seat_id, string plane)
    {
        if (plane == "Airbus 330")
        {
            Airbus330 airplane = new Airbus330();
            airplane.PopulateSeats();
            foreach (Seat seat in airplane.Seats)
            {
                if (seat.SeatId == seat_id)
                {
                    return seat;
                }
            }
        }
        if (plane == "Boeing 737")
        {
            Boeing737 airplane = new Boeing737();
            airplane.PopulateSeats();
            foreach (Seat seat in airplane.Seats)
            {
                if (seat.SeatId == seat_id)
                {
                    return seat;
                }
            }
        }
        if (plane == "Boeing 787")
        {
            Boeing787 airplane = new Boeing787();
            airplane.PopulateSeats();
            foreach (Seat seat in airplane.Seats)
            {
                if (seat.SeatId == seat_id)
                {
                    return seat;
                }
            }
        }
        return null;
    }
}