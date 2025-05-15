using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class FlightBooking
{
    public int FlightBookingId { get; set; }

    public int UserId { get; set; }

    public int FlightId { get; set; }

    public int? ConfirmedGroupId { get; set; }

    public bool IsGroupBooking { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime BookedDate { get; set; }

    public virtual ConfirmedGroup? ConfirmedGroup { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
