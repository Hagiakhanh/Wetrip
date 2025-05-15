using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroupMessageLocation
{
    public int MessageId { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public virtual TemporaryGroupMessage Message { get; set; } = null!;
}
