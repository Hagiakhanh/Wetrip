﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class CompanionTrip
{
    public int CompanionTripId { get; set; }

    public int OwnerId { get; set; }

    public string Title { get; set; }

    public DateTime TravelTime { get; set; }

    public string TravelHoppy { get; set; }

    public decimal? TravelCost { get; set; }

    public int MaxMember { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ConfirmedGroup ConfirmedGroup { get; set; }

    public virtual User Owner { get; set; }

    public virtual TemporaryGroup TemporaryGroup { get; set; }
}