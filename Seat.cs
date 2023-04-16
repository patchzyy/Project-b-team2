public class Seat
{
    public string SeatId { get; set; }
    public bool IsWindowSeat { get; set; }
    public bool IsFirstRowSeat { get; set; }
    public bool IsReserved { get; set; }
    public Seat(string seatId, bool isWindowSeat, bool isFirstRowSeat)
    {
        this.SeatId = seatId;
        this.IsWindowSeat = isWindowSeat;
        this.IsFirstRowSeat = isFirstRowSeat;
    }
}