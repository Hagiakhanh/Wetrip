using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class Hashtag
{
    public int HashtagId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<PostHashtag> PostHashtags { get; set; } = new List<PostHashtag>();
}
