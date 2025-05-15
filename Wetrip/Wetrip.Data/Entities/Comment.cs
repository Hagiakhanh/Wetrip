using System;
using System.Collections.Generic;
using Wetrip.Data.Entities;

namespace Wetrip.Data.DBContext;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public int? ParentCommentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public int PostId { get; set; }

    public int UserCommentedId { get; set; }

    public virtual ICollection<Comment> InverseParentComment { get; set; } = new List<Comment>();

    public virtual Comment? ParentComment { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User UserCommented { get; set; } = null!;
}
