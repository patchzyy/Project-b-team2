public class Boeing737 : Plane
{
    public Boeing737() : base("Boeing 737")
    {

    }

    protected override void PopulateSeats()
    {
        Seats.Add(new Seat("1-A", true, true) { IsReserved = true });
        Seats.Add(new Seat("1-B", false, true));
        Seats.Add(new Seat("1-C", false, true));

        Seats.Add(new Seat("2-A", true, false));
        Seats.Add(new Seat("2-B", false, false));
        Seats.Add(new Seat("2-C", false, false));

        Seats.Add(new Seat("2-D", false, true));
        Seats.Add(new Seat("2-E", false, true) { IsReserved = true });
        Seats.Add(new Seat("2-F", true, true));

        for (int rowNr = 3; rowNr <= 12; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false));
            Seats.Add(new Seat($"{rowNr}-F", true, false));
        }

        //skip row 13
        for (int rowNr = 14; rowNr <= 33; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false));
            Seats.Add(new Seat($"{rowNr}-F", true, false));
        }
    }
}