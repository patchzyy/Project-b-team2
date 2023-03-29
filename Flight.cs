public class Flight
{
    public readonly string? Time, Origin, Destination, Aircraft, State, Gate;
    public Flight(string time, string origin, string destination, string aircraft, string state, string gate)
    {
        Time = time;
        Origin = origin;
        Destination = destination;
        Aircraft = aircraft;
        State = state;
        Gate = gate;
    }
}