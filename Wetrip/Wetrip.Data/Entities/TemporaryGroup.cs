﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroup
{
    public int TemporaryGroupId { get; set; }

    public int CompanionTripId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual CompanionTrip CompanionTrip { get; set; }

    public virtual TemporaryGroupMember TemporaryGroupMember { get; set; }

    public virtual TemporaryGroupMessage TemporaryGroupMessage { get; set; }
}