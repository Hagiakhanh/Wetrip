using System;
using System.Collections.Generic;
using Wetrip.Data.DBContext;

namespace Wetrip.Data.Entities;

public partial class Post
{
    public int PostId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public bool IsDeleted { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<PostHashtag> PostHashtags { get; set; } = new List<PostHashtag>();

    public virtual ICollection<PostMedium> PostMedia { get; set; } = new List<PostMedium>();

    public virtual ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();

    public virtual ICollection<SharedPost> SharedPosts { get; set; } = new List<SharedPost>();

    public virtual ICollection<TaggedUser> TaggedUsers { get; set; } = new List<TaggedUser>();

    public virtual User User { get; set; } = null!;
}
