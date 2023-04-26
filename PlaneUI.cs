public static class PlaneUI
{

    /*
    README

    Vliegtuig menu van selecteren enz is niet meer met PlaneUI.DrawBoeing737(new boeing727())
    Vervang DrawBoeing met SelectBoeing
    dus: PlaneUI.SelectBoeing737(new boeing727())

    Seats moet ik nog fixen (eigenschappen van stoelen voor het berekenen van prijs enz.)
    en vervolgens nog aangeven met de juiste kleuren in de vliegtuigen.

    -Henk

    Tot nu toe zijn de volgende dingen af:
    Boeing737 select systeem (stoelen moeten nog gecorrigeeerd worden)
    */
    static string[] NederlandsBool = new string[2] { "Nee", "Ja" };

    public static void DrawBoeing737(Boeing737 plane, Seat currentSeat)
    {
        Console.WriteLine("             _________________");
        Console.WriteLine("            /                 \\                  Huidige stoel: " + currentSeat.SeatId);
        Console.WriteLine("           /                   \\                 Extra beenruimte: " + NederlandsBool[Convert.ToInt32(currentSeat.ExtraBeenRuimte)]);
        Console.WriteLine("         _/                     \\_               Prijs: " + currentSeat.SeatPrice());
        Console.WriteLine("        /                         \\");
        Console.WriteLine("      _/                           \\_");
        Console.Write("     /                               \\");
        Console.Write("           Stoelen met extra beenruimte staan");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" geel ");
        Console.ResetColor();
        Console.Write("aangegeven. \n");
        Console.WriteLine("   _/                                 \\_");
        Console.Write("  /                                     \\");
        Console.Write("        Stoelen die gereserveerd zijn staan ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("rood");
        Console.ResetColor();
        Console.Write(" aangegeven. \n");
        Console.WriteLine(" /                                       \\");
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
            if (rowNr == 16 || rowNr == 17)
            {
                Console.WriteLine("|                                         |");
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
            Console.WriteLine("|" + $"  {rowNr}");

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

    // returned seatID van geselecteerde stoel
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

    public static void DrawBoeing787(Boeing787 plane)
    {
        Console.WriteLine("|                                                            |");
        Console.WriteLine("|                                                            |");
        int rowNr = 1;
        bool rowHasSeats = true;
        while (rowHasSeats)
        {
            if (rowNr == 4)
            {
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 7)
            {
                rowNr = 16;
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 26)
            {
                rowNr = 27;
                Console.WriteLine("|                                                            |");
            }
            rowHasSeats = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|  ");
            int rowSeatCount = 0;
            if (rowNr > 36)
            {
                Console.Write("                    ");
            }
            foreach (var seat in plane.Seats)
            {
                if (seat.SeatId.StartsWith(rowNr.ToString() + "-"))
                {
                    if (seat.SeatId.Length == 3)
                        Console.Write(" ");
                    if (rowNr > 16 && rowNr < 37)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("J"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr == 16)
                    {
                        if (seat.SeatId.EndsWith("J"))
                        {
                            Console.Write("                      ");
                        }
                    }

                    if (rowNr < 7)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("     ");
                        }
                        if (seat.SeatId.EndsWith("K"))
                        {
                            Console.Write("     ");
                        }
                    }
                    if (seat.IsReserved)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(seat.SeatId + "  ");
                    if (rowNr < 7)
                    {
                        Console.Write("  ");
                    }
                    rowHasSeats = true;
                    rowSeatCount++;
                }
            }
            if (rowNr > 36)
            {
                Console.Write("                    ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|" + $"  {rowNr}");

            rowNr++;
            if (rowNr == 39)
            {
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                return;
            }
        }
    }

    public static void DrawAirbus330(Airbus330 plane)
    {
        Console.WriteLine("|                                                            |");
        Console.WriteLine("|                                                            |");
        int rowNr = 1;
        bool rowHasSeats = true;
        while (rowHasSeats)
        {
            if (rowNr == 3)
            {
                rowNr = 4;
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 11)
            {
                rowNr = 14;
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 34)
            {
                rowNr = 36;
                Console.WriteLine("|                                                            |");
            }

            rowHasSeats = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|  ");
            if (rowNr > 43 && rowNr < 50)
            {
                Console.Write("    ");
            }
            if (rowNr > 0 && rowNr < 3)
            {
                Console.Write("     ");
            }
            if (rowNr > 7 && rowNr < 11)
            {
                Console.Write("                    ");
            }
            if (rowNr == 33)
            {
                Console.Write("                    ");
            }
            if (rowNr == 50)
            {
                Console.Write("                    ");
            }

            int rowSeatCount = 0;

            foreach (var seat in plane.Seats)
            {
                if (seat.SeatId.StartsWith(rowNr.ToString() + "-"))
                {
                    if (seat.SeatId.Length == 3)
                        Console.Write(" ");
                    if (rowNr < 3)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("      ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("      ");
                        }
                    }
                    if (rowNr == 4)
                    {
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("                      ");
                        }
                    }
                    if (rowNr > 4 && rowNr < 8)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr > 13 && rowNr < 33)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr > 35 && rowNr < 44)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr > 43 && rowNr < 50)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("    ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("    ");
                        }
                    }
                    if (seat.IsReserved)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(seat.SeatId + "  ");
                    rowHasSeats = true;
                    rowSeatCount++;
                }
            }
            if (rowNr > 7 && rowNr < 11)
            {
                Console.Write("                    ");
            }
            if (rowNr == 33)
            {
                Console.Write("                    ");
            }
            if (rowNr == 50)
            {
                Console.Write("                    ");
            }
            if (rowNr > 43 && rowNr < 50)
            {
                Console.Write("    ");
            }
            if (rowNr > 0 && rowNr < 3)
            {
                Console.Write("     ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|" + $"  {rowNr}");

            rowNr++;
            if (rowNr == 51)
            {
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                return;
            }
        }
    }
}