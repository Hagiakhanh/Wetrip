using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TourGuide
{
    public int GuideId { get; set; }

    public decimal? Rating { get; set; }

    public string? Description { get; set; }

    public bool IsVerified { get; set; }

    public virtual User Guide { get; set; } = null!;

    public virtual ICollection<TourGuideBooking> TourGuideBookings { get; set; } = new List<TourGuideBooking>();
}
