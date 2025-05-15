using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public decimal? Rating { get; set; }

    public virtual ICollection<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();
}
