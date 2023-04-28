public class Boeing787 : Plane
{
    public Boeing787() : base("Boeing 787")
    {

    }

    protected override void PopulateSeats()
    {
        //row 1-6
        for (int rowNr = 1; rowNr <= 6; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, true, false, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, true, false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, true, false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false, false, false, true, false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, false, true, false, false));
            Seats.Add(new Seat($"{rowNr}-L", false, false, false, false, true, false, false));
        }

        //row 16
        Seats.Add(new Seat("16-A", false, false, false, false, false, true, false));
        Seats.Add(new Seat("16-B", false, false, false, false, false, true, false));
        Seats.Add(new Seat("16-C", false, false, false, false, false, true, false));
        Seats.Add(new Seat("16-J", false, false, false, false, false, true, false));
        Seats.Add(new Seat("16-K", false, false, false, false, false, true, false));
        Seats.Add(new Seat("16-L", false, false, false, false, false, true, false));

        //row 17
        Seats.Add(new Seat("17-A", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-B", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-C", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-D", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-E", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-F", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-J", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-K", false, false, false, false, false, true, false));
        Seats.Add(new Seat("17-L", false, false, false, false, false, true, false));

        //row 18-22
        for (int rowNr = 18; rowNr <= 22; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, false, false, true, false));
            Seats.Add(new Seat($"{rowNr}-L", false, false, false, false, false, true, false));
        }
        //row 23
        Seats.Add(new Seat("23-A", false, false, false, false, false, false, true));
        Seats.Add(new Seat("23-B", false, false, false, false, false, false, true));
        Seats.Add(new Seat("23-C", false, false, false, false, false, false, true));
        Seats.Add(new Seat("23-D", false, false, false, false, false, true, false));
        Seats.Add(new Seat("23-E", false, false, false, false, false, true, false));
        Seats.Add(new Seat("23-F", false, false, false, false, false, true, false));
        Seats.Add(new Seat("23-J", false, false, false, false, false, false, true));
        Seats.Add(new Seat("23-K", false, false, false, false, false, false, true));
        Seats.Add(new Seat("23-L", false, false, false, false, false, false, true));
        //row 24 & 25
        for (int rowNr = 24; rowNr <= 25; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-E", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-J", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-L", false, false, false, false, false, false, true));
        }

        //row 27
        Seats.Add(new Seat("27-A", false, false, false, false, false, false, true));
        Seats.Add(new Seat("27-B", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-C", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-D", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-E", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-F", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-J", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-K", false, false, false, false, false, true, false));
        Seats.Add(new Seat("27-L", false, false, false, false, false, false, true));

        for (int rowNr = 28; rowNr <= 36; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-E", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-J", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-L", false, false, false, false, false, false, true));
        }
        //row 37
        Seats.Add(new Seat("37-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("37-E", false, false, false, false, false, false, true));
        Seats.Add(new Seat("37-F", false, false, false, false, false, false, true));
        //row 38
        Seats.Add(new Seat("38-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("38-E", false, false, false, false, false, false, true));
        Seats.Add(new Seat("38-F", false, false, false, false, false, false, true));
    }
}