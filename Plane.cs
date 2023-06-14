public abstract class Plane
{
    public string PlaneModel { get; set; }
    public List<Seat> Seats { get; } = new();

    public Plane(string planeModel)
    {
        this.PlaneModel = planeModel;
        PopulateSeats();
    }

    public abstract void PopulateSeats();
}