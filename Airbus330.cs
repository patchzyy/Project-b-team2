public class Airbus330 : Plane
{
    public Airbus330() : base("Airbus 330")
    {

    }

    protected override void PopulateSeats()
    {
        //row 1
        Seats.Add(new Seat("1-A", true, true));
        Seats.Add(new Seat("1-C", false, true));
        Seats.Add(new Seat("1-D", false, true));
        Seats.Add(new Seat("1-G", false, true));
        Seats.Add(new Seat("1-H", false, true));
        Seats.Add(new Seat("1-K", true, true));

        //row 2
        Seats.Add(new Seat("2-A", true, false));
        Seats.Add(new Seat("2-C", false, false));
        Seats.Add(new Seat("2-D", false, false));
        Seats.Add(new Seat("2-G", false, false));
        Seats.Add(new Seat("2-H", false, false));
        Seats.Add(new Seat("2-K", true, false));

        //skip row 3 

        //row 4
        Seats.Add(new Seat("4-A", true, true));
        Seats.Add(new Seat("4-B", false, true));
        Seats.Add(new Seat("4-C", false, true));
        Seats.Add(new Seat("4-H", false, true));
        Seats.Add(new Seat("4-J", false, true));
        Seats.Add(new Seat("4-K", true, true));

        //row 5
        Seats.Add(new Seat("5-A", true, false));
        Seats.Add(new Seat("5-B", false, false));
        Seats.Add(new Seat("5-C", false, false));
        Seats.Add(new Seat("5-D", false, true));
        Seats.Add(new Seat("5-F", false, true));
        Seats.Add(new Seat("5-G", false, true));
        Seats.Add(new Seat("5-H", false, false));
        Seats.Add(new Seat("5-J", false, false));
        Seats.Add(new Seat("5-K", true, false));

        //row 6 & 7
        for (int rowNr = 6; rowNr <= 7; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false));
            Seats.Add(new Seat($"{rowNr}-H", false, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false));
            Seats.Add(new Seat($"{rowNr}-K", true, false));
        }

        //row 8 - 10
        for (int rowNr = 8; rowNr <= 10; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false));
        }

        //skip row 11 tot en met 13

        //row 14
        Seats.Add(new Seat("14-A", true, true));
        Seats.Add(new Seat("14-B", false, true));
        Seats.Add(new Seat("14-C", false, true));
        Seats.Add(new Seat("14-D", false, true));
        Seats.Add(new Seat("14-F", false, true));
        Seats.Add(new Seat("14-G", false, true));
        Seats.Add(new Seat("14-H", false, true));
        Seats.Add(new Seat("14-J", false, true));
        Seats.Add(new Seat("14-K", true, true));

        //row 15 tot 32
        for (int rowNr = 15; rowNr <= 32; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false));
            Seats.Add(new Seat($"{rowNr}-H", false, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false));
            Seats.Add(new Seat($"{rowNr}-K", true, false));
        }

        //row 33
        Seats.Add(new Seat("33-D", false, false));
        Seats.Add(new Seat("33-F", false, false));
        Seats.Add(new Seat("33-G", false, false));

        //row 36
        Seats.Add(new Seat("36-A", true, true));
        Seats.Add(new Seat("36-B", false, true));
        Seats.Add(new Seat("36-C", false, true));
        Seats.Add(new Seat("36-D", false, true));
        Seats.Add(new Seat("36-F", false, true));
        Seats.Add(new Seat("36-G", false, true));
        Seats.Add(new Seat("36-H", false, true));
        Seats.Add(new Seat("36-J", false, true));
        Seats.Add(new Seat("36-K", true, true));

        //row 37 tot 43
        for (int rowNr = 37; rowNr <= 43; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-B", false, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false));
            Seats.Add(new Seat($"{rowNr}-H", false, false));
            Seats.Add(new Seat($"{rowNr}-J", false, false));
            Seats.Add(new Seat($"{rowNr}-K", true, false));
        }

        //row 44 tot 49
        for (int rowNr = 44; rowNr <= 49; rowNr++)
        {
            Seats.Add(new Seat($"{rowNr}-A", true, false));
            Seats.Add(new Seat($"{rowNr}-C", false, false));
            Seats.Add(new Seat($"{rowNr}-D", false, false));
            Seats.Add(new Seat($"{rowNr}-F", false, false));
            Seats.Add(new Seat($"{rowNr}-G", false, false));
            Seats.Add(new Seat($"{rowNr}-H", false, false));
            Seats.Add(new Seat($"{rowNr}-K", true, false));
        }

        //row 50
        Seats.Add(new Seat("50-D", false, false));
        Seats.Add(new Seat("50-F", false, false));
        Seats.Add(new Seat("50-G", false, false));


    }
}