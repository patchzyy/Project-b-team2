public class Boeing787 : Plane
{
    public Boeing787() : base("Boeing 787")
    {

    }

    protected override void PopulateSeats()
    {
        //row 1
        Seats.Add(new Seat("1-A", true, true));
        Seats.Add(new Seat("1-B", false, true));
        Seats.Add(new Seat("1-D", false, true));
        Seats.Add(new Seat("1-E", false, true));
        Seats.Add(new Seat("1-K", false, true));
        Seats.Add(new Seat("1-L", true, true));
        //row 2 & 3
        for (int rowNr = 2; rowNr <= 3; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false));
            Seats.Add(new Seat($"{rowNr}-L", true, false));
        }
        //row 4
        Seats.Add(new Seat("4-A", true, true));
        Seats.Add(new Seat("4-B", false, true));
        Seats.Add(new Seat("4-D", false, true));
        Seats.Add(new Seat("4-E", false, true));
        Seats.Add(new Seat("4-K", false, true));
        Seats.Add(new Seat("4-L", true, true));
        //row 5 & 6
        for (int rowNr = 5; rowNr <= 6; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false));
            Seats.Add(new Seat($"{rowNr}-L", true, false));
        }

        //row 16
        Seats.Add(new Seat("16-A", true, false));
        Seats.Add(new Seat("16-B", false, false));
        Seats.Add(new Seat("16-C", false, false));
        Seats.Add(new Seat("16-J", false, false));
        Seats.Add(new Seat("16-K", false, false));
        Seats.Add(new Seat("16-L", true, false));

        //row 17
        Seats.Add(new Seat("17-A", true, false));
        Seats.Add(new Seat("17-B", false, false));
        Seats.Add(new Seat("17-C", false, false));
        Seats.Add(new Seat("17-D", false, true));
        Seats.Add(new Seat("17-E", false, true));
        Seats.Add(new Seat("17-F", false, true));
        Seats.Add(new Seat("17-J", false, false));
        Seats.Add(new Seat("17-K", false, false));
        Seats.Add(new Seat("17-L", true, false));

        //row 18-25
        for (int rowNr = 18; rowNr <= 25; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false));
            Seats.Add(new Seat($"{rowNr}-L", true, false));
        }

        //row 27
        Seats.Add(new Seat("27-A", true, true));
        Seats.Add(new Seat("27-B", false, true));
        Seats.Add(new Seat("27-C", false, true));
        Seats.Add(new Seat("27-D", false, true));
        Seats.Add(new Seat("27-E", false, true));
        Seats.Add(new Seat("27-F", false, true));
        Seats.Add(new Seat("27-J", false, true));
        Seats.Add(new Seat("27-K", false, true));
        Seats.Add(new Seat("27-L", true, true));

        for (int rowNr = 28; rowNr <= 36; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-E", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false));
            Seats.Add(new Seat($"{rowNr}-L", true, false));
        }
        //row 37
        Seats.Add(new Seat("37-D", false, false));
        Seats.Add(new Seat("37-E", false, false));
        Seats.Add(new Seat("37-F", false, false));
        //row 38
        Seats.Add(new Seat("38-D", false, false));
        Seats.Add(new Seat("38-E", false, false));
        Seats.Add(new Seat("38-F", false, false));
    }
}