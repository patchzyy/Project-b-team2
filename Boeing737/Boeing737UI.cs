public class DrawBoeing737UI
{
    private static bool _reversedSeatFirst = true;
    public static void DrawBoeing737(Boeing737 plane, Seat currentSeat, Flight flight)
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
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Huidige stoel\n");
        Console.Write("|                                         |");
        Console.Write("                 Gebruik de pijltjestoetsen om door het vliegtuig te navigeren.\n");
        Console.Write("|                                         |");
        Console.Write("                 Druk op ENTER om een stoel te (de)selecteren.\n");

        int rowNr = 1;
        bool rowHasSeats = true;
        // blijf in deze loop zolang er stoelen zijn met het huidige rowNr
        List<Seat> reservedSeats = flight.GetReservedSeats();
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
                Console.WriteLine("|                                         |                 Prijs: " + currentSeat.GetTotalPrice(flight));
            }

            rowHasSeats = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|  ");
            int rowSeatCount = 0;

            foreach (var seat in plane.Seats)
            {
                foreach (var reservedSeat in reservedSeats)
                {
                    if (seat.SeatId == reservedSeat.SeatId)
                    {
                        seat.IsReserved = true;
                        break;
                    }
                    else
                    {
                        seat.IsReserved = false;
                    }
                }

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

                    if (!DrawBoeing737UI._reversedSeatFirst)
                    {
                        if (seat.IsReserved)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        if (seat == currentSeat)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                    }
                    if (DrawBoeing737UI._reversedSeatFirst)
                    {
                        if (seat == currentSeat)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        if (seat.IsReserved)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                    }

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
                Console.WriteLine("|" + $"  {rowNr}" + "             " + (currentSeat.ExtraBeenRuimte ? "Extra Beenruimte" : ""));
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

    public static List<Seat>? SelectBoeing737(Boeing737 plane, int amountToSelect, Flight flight)
    {
        int seatIndex = 0;
        List<string> SeatsChosen = new();
        List<Seat> returnSeats = new();
        while (true)
        {
            Console.Clear();
            DrawBoeing737(plane, plane.Seats[seatIndex], flight);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return returnSeats;
            }
            if (key.Key == ConsoleKey.Enter)
            {
                _reversedSeatFirst = true;
                Console.Clear();
                DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                if (plane.Seats[seatIndex].IsReserved)
                {
                    SeatsChosen.Remove(plane.Seats[seatIndex].SeatId);
                    returnSeats.Remove(plane.Seats[seatIndex]);
                    plane.Seats[seatIndex].IsReserved = false;
                    _reversedSeatFirst = true;
                    Console.Clear();
                    DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                    continue;
                }

                if (SeatsChosen.Count == amountToSelect)
                {
                    _reversedSeatFirst = true;
                    Console.Clear();
                    DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                    Console.WriteLine($"Je hebt al {amountToSelect} stoelen gekozen.");
                    Console.WriteLine("\nWil je doorgaan met het boeken?");
                    if (ChooseTheSeats())
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (!plane.Seats[seatIndex].IsReserved)
                {
                    SeatsChosen.Add(plane.Seats[seatIndex].SeatId);
                    returnSeats.Add(plane.Seats[seatIndex]);
                    plane.Seats[seatIndex].IsReserved = true;
                    Console.Clear();
                    DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                }
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return null;
            }
            if ((key.Key == ConsoleKey.LeftArrow) && (seatIndex > 0))
            {
                _reversedSeatFirst = false;
                seatIndex--;
                continue;
            }
            if ((key.Key == ConsoleKey.RightArrow) && (seatIndex < (plane.Seats.Count - 1)))
            {
                _reversedSeatFirst = false;
                seatIndex++;
                continue;
            }
            if ((key.Key == ConsoleKey.UpArrow) && (seatIndex > 2))
            {
                _reversedSeatFirst = false;
                Console.Clear();
                DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                seatIndex -= 3;
                if (seatIndex > 2)
                    seatIndex -= 3;
            }
            if ((key.Key == ConsoleKey.DownArrow) && (seatIndex < (plane.Seats.Count - 6)))
            {
                _reversedSeatFirst = false;
                Console.Clear();
                DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                if (seatIndex < 3)
                    seatIndex += 3;
                else
                    seatIndex += 6;
            }

            if (SeatsChosen.Count == amountToSelect)
            {
                Console.Clear();
                DrawBoeing737(plane, plane.Seats[seatIndex], flight);
                Console.Write("\nJe gekozen stoelen zijn: ");
                foreach (string seat in SeatsChosen)
                {
                    bool isLastSeat = seat.Equals(SeatsChosen.Last());
                    Console.Write($"{seat}");

                    if (!isLastSeat)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(".");
                Console.WriteLine("\nWil je doorgaan met het boeken?");
                if (ChooseTheSeats())
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            else if (SeatsChosen.Count > amountToSelect)
            {
                MovingOn(amountToSelect);
                continue;
            }
        }

        foreach (Seat seat in returnSeats)
        {
            Seat addSeat = new Seat(seat.SeatId, seat.ExtraBeenRuimte, seat.IsClubClass, seat.IsDoubleSeat, seat.IsFrontSeat, seat.IsBusinessClass, seat.IsEconomyPlus, seat.IsEconomy);
            returnSeats.Append(addSeat);
        }
        return returnSeats;
    }

    private static void MovingOn(int amountToSelect)
    {
        Console.WriteLine($"Selecteer a.u.b. alleen {amountToSelect} stoelen.");
        Console.WriteLine("Druk op enter om door te gaan met stoelen selecteren.");
        var keyForMenu = Console.ReadKey(true);
        while (true)
        {
            if (keyForMenu.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    private static bool ChooseTheSeats()
    {
        List<string> choices = new() { "Ja", "Nee" };
        int selectedOption = 0;
        while (true)
        {
            // Console.WriteLine();
            var cursor = Console.GetCursorPosition();
            Console.SetCursorPosition(0, cursor.Top);
            if (selectedOption == 0)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("Ja");
                Console.ResetColor();
                Console.Write("   ");
                Console.Write("Nee");
            }
            else if (selectedOption == 1)
            {
                Console.Write("Ja");
                Console.Write("   ");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("Nee");
                Console.ResetColor();
            }
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (selectedOption > 0)
                    {
                        selectedOption--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (selectedOption < choices.Count - 1)
                    {
                        selectedOption++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (selectedOption == 0)
                    {
                        Console.WriteLine("\n\n");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

        }
    }
}