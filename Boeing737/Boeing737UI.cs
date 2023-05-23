public class DrawBoeing737UI
{
    public static void DrawBoeing737(Boeing737 plane, Seat currentSeat)
    {
        string[] NederlandsBool = new string[2] { "Nee", "Ja" };
        Console.WriteLine("         _/                     \\_");
        Console.WriteLine("        /                         \\");
        Console.WriteLine("      _/                           \\_");
        Console.Write("     /                               \\                      LEGENDA\n");
        Console.Write("   _/                                 \\_                    ");
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Extra Beenruimte\n");
        Console.Write("  /                                     \\                   ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Gereserveerde stoel\n");
        Console.Write(" /                                       \\                  ");
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Huidige stoel\n");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|                                         |");

        int rowNr = 1;
        bool rowHasSeats = true;
        // blijf in deze loop zolang er stoelen zijn met het huidige rowNr
        while (rowHasSeats)
        {
            if (rowNr == 13)
            {
                rowNr++;
            }
            if (rowNr == 16)
            {
                Console.WriteLine("|                                         |");
            }
            if (rowNr == 17)
            {
                Console.WriteLine("|                                         |" + "                 Extra beenruimte: " + NederlandsBool[Convert.ToInt32(currentSeat.ExtraBeenRuimte)]);
            }

            rowHasSeats = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|  ");
            int rowSeatCount = 0;

            foreach (var seat in plane.Seats)
            {
                if (seat.SeatId.StartsWith(rowNr.ToString() + "-"))
                {
                    // Als het seatId op rij < 10 is, dan extra spatie voor het stoelnummer
                    if (seat.SeatId.Length == 3)
                        Console.Write(" ");
                    if (seat.SeatId.EndsWith("D"))
                    {
                        Console.Write("   ");
                    }
                    if (seat.ExtraBeenRuimte)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    if (seat.IsReserved)
                        Console.BackgroundColor = ConsoleColor.Red;

                    if (seat == currentSeat)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.Write(seat.SeatId);
                    Console.ResetColor();
                    Console.Write("  ");

                    rowHasSeats = true;
                    rowSeatCount++;
                }
            }

            // Als de rij geen 6 stoelen heeft: teken spaties voor de lege plekken
            if (rowSeatCount < 6)
            {
                for (int i = rowSeatCount; i < 6; i++)
                    Console.Write("       ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            if (rowNr == 16)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "             Huidige stoel: " + currentSeat.SeatId);
            }
            if (rowNr == 17)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "             Prijs: " + currentSeat.SeatPrice());
            }
            else if (rowNr != 16 && rowNr != 17)
            {
                Console.WriteLine("|" + $"  {rowNr}");
            }
            rowNr++;
            if (rowNr == 34)
            {
                Console.WriteLine("|                                         |");
                Console.WriteLine("|                                         |");
                Console.WriteLine(" \\                                       /");
                Console.WriteLine("  \\                                     /");
                Console.WriteLine("   \\_                                 _/");
                Console.WriteLine("     \\_______________________________/");
                return;
            }
        }

    }

    public static string? SelectBoeing737(Boeing737 plane)
    {
        var hasSelection = false;
        var seatIndex = 0;
        while (!hasSelection)
        {
            Console.Clear();
            DrawBoeing737(plane, plane.Seats[seatIndex]);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                if (!plane.Seats[seatIndex].IsReserved)
                    hasSelection = true;
            }
            if (key.Key == ConsoleKey.Escape)
                return null;
            if ((key.Key == ConsoleKey.LeftArrow) && (seatIndex > 0))
                seatIndex--;
            if ((key.Key == ConsoleKey.RightArrow) && (seatIndex < (plane.Seats.Count - 1)))
                seatIndex++;
            if ((key.Key == ConsoleKey.UpArrow) && (seatIndex > 2))
            {
                seatIndex -= 3;
                if (seatIndex > 2)
                    seatIndex -= 3;
            }
            if ((key.Key == ConsoleKey.DownArrow) && (seatIndex < (plane.Seats.Count - 6)))
            {
                if (seatIndex < 3)
                    seatIndex += 3;
                else
                    seatIndex += 6;
            }
        }
        if (hasSelection)
        {
            Console.WriteLine("Selected seat: " + plane.Seats[seatIndex].SeatId);
            return plane.Seats[seatIndex].SeatId;
        }
        else
            return null;
    }
}