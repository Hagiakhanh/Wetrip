using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TaggedUser
{
    public int TaggedId { get; set; }

    public int PostId { get; set; }

    public int UserTagged { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User UserTaggedNavigation { get; set; } = null!;
}
