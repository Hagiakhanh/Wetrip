using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class ConfirmedGroupMember
{
    public int ConfirmedGroupId { get; set; }

    public int UserId { get; set; }

    public bool IsOwner { get; set; }

    public DateTime JoinAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ConfirmedGroup ConfirmedGroup { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
