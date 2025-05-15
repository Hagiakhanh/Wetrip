using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class Flight
{
    public int FlightId { get; set; }

    public string Airline { get; set; } = null!;

    public string FromLocation { get; set; } = null!;

    public string ToLocation { get; set; } = null!;

    public DateTime DepartureTime { get; set; }

    public string? TicketClass { get; set; }

    public decimal Price { get; set; }

    public int RemainingQuantity { get; set; }

    public virtual ICollection<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();
}
