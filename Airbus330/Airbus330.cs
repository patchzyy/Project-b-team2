public class Airbus330 : Plane
{
    public Airbus330() : base("Airbus 330")
    {

    }

    protected override void PopulateSeats()
    {
        for (int rowNr = 1; rowNr <= 2; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, true, false, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-C", true, true, false, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-D", true, true, false, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-G", true, true, false, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-H", true, true, false, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-K", true, true, false, false, false, false, false));
        }

        //skip row 3 

        //row 4
        Seats.Add(new Seat("4-A", true, false, false, false, false, false, false));
        Seats.Add(new Seat("4-B", true, false, false, false, false, false, false));
        Seats.Add(new Seat("4-C", true, false, false, false, false, false, false));
        Seats.Add(new Seat("4-H", true, false, false, false, false, false, false));
        Seats.Add(new Seat("4-J", true, false, false, false, false, false, false));
        Seats.Add(new Seat("4-K", true, false, false, false, false, false, false));

        //row 5
        Seats.Add(new Seat("5-A", false, false, false, true, false, false, false));
        Seats.Add(new Seat("5-B", false, false, false, true, false, false, false));
        Seats.Add(new Seat("5-C", false, false, false, true, false, false, false));
        Seats.Add(new Seat("5-D", true, false, false, true, false, false, false));
        Seats.Add(new Seat("5-F", true, false, false, true, false, false, false));
        Seats.Add(new Seat("5-G", true, false, false, true, false, false, false));
        Seats.Add(new Seat("5-H", false, false, false, true, false, false, false));
        Seats.Add(new Seat("5-J", false, false, false, true, false, false, false));
        Seats.Add(new Seat("5-K", false, false, false, true, false, false, false));
        //row 6 & 7
        for (int rowNr = 6; rowNr <= 7; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-H", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, true, false, false, false));
        }

        //row 8 - 9
        for (int rowNr = 8; rowNr <= 9; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, true, false, false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false, false, true, false, false, false));
        }

        //row 10
        Seats.Add(new Seat("10-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("10-F", false, false, false, false, false, false, true));
        Seats.Add(new Seat("10-G", false, false, false, false, false, false, true));

        //skip row 11 tot en met 13

        //row 14
        Seats.Add(new Seat("14-A", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-B", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-C", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-D", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-F", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-G", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-H", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-J", true, false, false, false, false, false, false));
        Seats.Add(new Seat("14-K", true, false, false, false, false, false, false));

        //row 15 tot 32
        for (int rowNr = 15; rowNr <= 32; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-G", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-H", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-J", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, false, false, false, true));
        }

        //row 33
        Seats.Add(new Seat("33-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("33-F", false, false, false, false, false, false, true));
        Seats.Add(new Seat("33-G", false, false, false, false, false, false, true));

        //row 36
        Seats.Add(new Seat("36-A", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-B", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-C", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-D", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-F", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-G", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-H", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-J", true, false, false, false, false, false, false));
        Seats.Add(new Seat("36-K", true, false, false, false, false, false, false));

        //row 37 tot 43
        for (int rowNr = 37; rowNr <= 43; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-B", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-C", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-G", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-H", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-J", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-K", false, false, false, false, false, false, true));
        }

        //row 44 tot 49
        for (int rowNr = 44; rowNr <= 49; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", false, false, true, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false, true, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-F", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-G", false, false, false, false, false, false, true));
            Seats.Add(new Seat($"{rowNr}-H", false, false, true, false, false, false, false));
            Seats.Add(new Seat($"{rowNr}-K", false, false, true, false, false, false, false));
        }

        //row 50
        Seats.Add(new Seat("50-D", false, false, false, false, false, false, true));
        Seats.Add(new Seat("50-F", false, false, false, false, false, false, true));
        Seats.Add(new Seat("50-G", false, false, false, false, false, false, true));


    }
}