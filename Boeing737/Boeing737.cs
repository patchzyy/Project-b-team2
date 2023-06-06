public class Boeing737 : Plane
{
    public Boeing737() : base("Boeing 737")
    {

    }

    protected override void PopulateSeats()
    {
        Seats.Add(new Seat("1-A", false, false, false, false, false, false, true));
        Seats.Add(new Seat("1-B", false, false, false, false, false, false, true));
        Seats.Add(new Seat("1-C", false, false, false, false, false, false, true));

        Seats.Add(new Seat("2-A", false, false, false, false, false, false, true));
        Seats.Add(new Seat("2-B", false, false, false, false, false, false, true));
        Seats.Add(new Seat("2-C", false, false, false, false, false, false, true));

        Seats.Add(new Seat("2-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("2-E", false, false, false, false, false, false, true));
        Seats.Add(new Seat("2-F", false, false, false, false, false, false, true));

        for (int rowNr = 3; rowNr <= 12; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-E", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
        }
        //skip row 13
        //row 14
        Seats.Add(new Seat("14-A", false, false, false, false, false, false, true));
        Seats.Add(new Seat("14-B", false, false, false, false, false, false, true));
        Seats.Add(new Seat("14-C", false, false, false, false, false, false, true));
        Seats.Add(new Seat("14-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("14-E", false, false, false, false, false, false, true));
        Seats.Add(new Seat("14-F", false, false, false, false, false, false, true));
        //row 15
        Seats.Add(new Seat("15-A", false, false, false, false, false, false, true));
        Seats.Add(new Seat("15-B", false, false, false, false, false, false, true));
        Seats.Add(new Seat("15-C", false, false, false, false, false, false, true));
        Seats.Add(new Seat("15-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("15-E", false, false, false, false, false, false, true));
        Seats.Add(new Seat("15-F", false, false, false, false, false, false, true));
        //row 16
        Seats.Add(new Seat("16-A", true, false, false, false, false, false, false));
        Seats.Add(new Seat("16-B", true, false, false, false, false, false, false));
        Seats.Add(new Seat("16-C", true, false, false, false, false, false, false));
        Seats.Add(new Seat("16-D", true, false, false, false, false, false, false));
        Seats.Add(new Seat("16-E", true, false, false, false, false, false, false));
        Seats.Add(new Seat("16-F", true, false, false, false, false, false, false));
        //row 17
        Seats.Add(new Seat("17-A", true, false, false, false, false, false, false));
        Seats.Add(new Seat("17-B", true, false, false, false, false, false, false));
        Seats.Add(new Seat("17-C", true, false, false, false, false, false, false));
        Seats.Add(new Seat("17-D", true, false, false, false, false, false, false));
        Seats.Add(new Seat("17-E", true, false, false, false, false, false, false));
        Seats.Add(new Seat("17-F", true, false, false, false, false, false, false));


        //row 18-33
        for (int rowNr = 18; rowNr <= 33; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-E", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
        }
    }
}