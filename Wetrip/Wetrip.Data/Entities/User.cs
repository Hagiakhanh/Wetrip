using System;
using System.Collections.Generic;
using Wetrip.Data.DBContext;

namespace Wetrip.Data.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public string? Phone { get; set; }

    public string? EmailAddress { get; set; }

    public string? Address { get; set; }

    public int? Coin { get; set; }

    public string? Avatar { get; set; }

    public string? BackgroundImage { get; set; }

    public string? MembershipTier { get; set; }

    public string? Personality { get; set; }

    public int RoleId { get; set; }

    public string? ConfirmToken { get; set; }

    public bool IsAccountConfirm { get; set; }

    public Guid? RequestId { get; set; }

    public virtual IEnumerable<Comment>? Comments { get; set; } = new List<Comment>();

    public virtual ICollection<CompanionTrip> CompanionTrips { get; set; } = new List<CompanionTrip>();

    public virtual ICollection<ConfirmedGroupMember> ConfirmedGroupMembers { get; set; } = new List<ConfirmedGroupMember>();

    public virtual ICollection<ConfirmedGroupMessage> ConfirmedGroupMessages { get; set; } = new List<ConfirmedGroupMessage>();

    public virtual ICollection<FlightBooking> FlightBookings { get; set; } = new List<FlightBooking>();

    public virtual ICollection<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();

    public virtual ICollection<SharedPost> SharedPosts { get; set; } = new List<SharedPost>();

    public virtual ICollection<TaggedUser> TaggedUsers { get; set; } = new List<TaggedUser>();

    public virtual ICollection<TemporaryGroupMember> TemporaryGroupMembers { get; set; } = new List<TemporaryGroupMember>();

    public virtual ICollection<TemporaryGroupMessage> TemporaryGroupMessages { get; set; } = new List<TemporaryGroupMessage>();

    public virtual TourGuide? TourGuide { get; set; }

    public virtual ICollection<TourGuideBooking> TourGuideBookings { get; set; } = new List<TourGuideBooking>();

    public virtual ICollection<UserFollow> UserFollowFollowers { get; set; } = new List<UserFollow>();

    public virtual ICollection<UserFollow> UserFollowFollowings { get; set; } = new List<UserFollow>();

    public virtual Wallet? Wallet { get; set; }
}
