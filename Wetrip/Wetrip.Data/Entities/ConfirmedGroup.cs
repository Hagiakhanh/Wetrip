using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class ConfirmedGroup
{
    public int ConfirmedGroupId { get; set; }

    public int CompanionTripId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual CompanionTrip CompanionTrip { get; set; } = null!;

    public virtual ConfirmedGroupMember? ConfirmedGroupMember { get; set; }

    public virtual ConfirmedGroupMessage? ConfirmedGroupMessage { get; set; }

    public virtual ICollection<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();

    public virtual ICollection<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();
}
