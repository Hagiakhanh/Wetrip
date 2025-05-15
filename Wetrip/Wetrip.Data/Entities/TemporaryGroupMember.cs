using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroupMember
{
    public int TemporaryGroupId { get; set; }

    public int UserId { get; set; }

    public bool IsOwner { get; set; }

    public DateTime JoinAt { get; set; }

    public bool IsActive { get; set; }

    public virtual TemporaryGroup TemporaryGroup { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
