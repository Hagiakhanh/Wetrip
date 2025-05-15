using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class HotelBooking
{
    public int HotelBookingId { get; set; }

    public int UserId { get; set; }

    public int HotelId { get; set; }

    public int? ConfirmedGroupId { get; set; }

    public bool IsGroupBooking { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime BookedDate { get; set; }

    public virtual ConfirmedGroup? ConfirmedGroup { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
