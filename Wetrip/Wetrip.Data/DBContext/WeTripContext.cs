using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wetrip.Data.DBContext;
using Wetrip.Data.Entities;

namespace Wetrip.Data.DBContext;

public partial class WeTripContext : DbContext
{
    public WeTripContext()
    {
    }

    public WeTripContext(DbContextOptions<WeTripContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CompanionTrip> CompanionTrips { get; set; }

    public virtual DbSet<ConfirmedGroup> ConfirmedGroups { get; set; }

    public virtual DbSet<ConfirmedGroupMember> ConfirmedGroupMembers { get; set; }

    public virtual DbSet<ConfirmedGroupMessage> ConfirmedGroupMessages { get; set; }

    public virtual DbSet<ConfirmedGroupMessageLocation> ConfirmedGroupMessageLocations { get; set; }

    public virtual DbSet<ConfirmedGroupMessageMedium> ConfirmedGroupMessageMedia { get; set; }

    public virtual DbSet<ConfirmedGroupMessageText> ConfirmedGroupMessageTexts { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightBooking> FlightBookings { get; set; }

    public virtual DbSet<Hashtag> Hashtags { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelBooking> HotelBookings { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostHashtag> PostHashtags { get; set; }

    public virtual DbSet<PostMedium> PostMedia { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SavedPost> SavedPosts { get; set; }

    public virtual DbSet<SharedPost> SharedPosts { get; set; }

    public virtual DbSet<TaggedUser> TaggedUsers { get; set; }

    public virtual DbSet<TemporaryGroup> TemporaryGroups { get; set; }

    public virtual DbSet<TemporaryGroupMember> TemporaryGroupMembers { get; set; }

    public virtual DbSet<TemporaryGroupMessage> TemporaryGroupMessages { get; set; }

    public virtual DbSet<TemporaryGroupMessageLocation> TemporaryGroupMessageLocations { get; set; }

    public virtual DbSet<TemporaryGroupMessageMedium> TemporaryGroupMessageMedia { get; set; }

    public virtual DbSet<TemporaryGroupMessageText> TemporaryGroupMessageTexts { get; set; }

    public virtual DbSet<TourGuide> TourGuides { get; set; }

    public virtual DbSet<TourGuideBooking> TourGuideBookings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFollow> UserFollows { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=WeTrip;User ID=sa;Password=12345;Encrypt=False");*/
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string ConnectionStr = config.GetConnectionString("DefaultConnectionStringDB");

            optionsBuilder.UseSqlServer(ConnectionStr);
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAAB9CD434A");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ParentCommentId).HasColumnName("ParentCommentID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserCommentedId).HasColumnName("UserCommentedID");

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment)
                .HasForeignKey(d => d.ParentCommentId)
                .HasConstraintName("FK__Comments__Parent__534D60F1");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__PostID__5535A963");

            entity.HasOne(d => d.UserCommented).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserCommentedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__UserCo__5629CD9C");
        });

        modelBuilder.Entity<CompanionTrip>(entity =>
        {
            entity.HasKey(e => e.CompanionTripId).HasName("PK__Companio__002F56A97EBA089C");

            entity.ToTable("CompanionTrip");

            entity.Property(e => e.CompanionTripId).HasColumnName("CompanionTripID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.TravelCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TravelHoppy).HasMaxLength(255);
            entity.Property(e => e.TravelTime).HasColumnType("datetime");

            entity.HasOne(d => d.Owner).WithMany(p => p.CompanionTrips)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Companion__Owner__70DDC3D8");
        });

        modelBuilder.Entity<ConfirmedGroup>(entity =>
        {
            entity.HasKey(e => e.ConfirmedGroupId).HasName("PK__Confirme__DEED2078CB357A9E");

            entity.ToTable("ConfirmedGroup");

            entity.HasIndex(e => e.CompanionTripId, "UQ__Confirme__002F56A866E3D1EF").IsUnique();

            entity.Property(e => e.ConfirmedGroupId).HasColumnName("ConfirmedGroupID");
            entity.Property(e => e.CompanionTripId).HasColumnName("CompanionTripID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CompanionTrip).WithOne(p => p.ConfirmedGroup)
                .HasForeignKey<ConfirmedGroup>(d => d.CompanionTripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Compa__0E6E26BF");
        });

        modelBuilder.Entity<ConfirmedGroupMember>(entity =>
        {
            entity.HasKey(e => new { e.ConfirmedGroupId, e.UserId }).HasName("PK__Confirme__0F95ACB201A9EDF7");

            entity.ToTable("ConfirmedGroupMember");

            entity.HasIndex(e => e.ConfirmedGroupId, "UQ__Confirme__DEED2079EA1A38E2").IsUnique();

            entity.Property(e => e.ConfirmedGroupId).HasColumnName("ConfirmedGroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoinAt).HasColumnType("datetime");

            entity.HasOne(d => d.ConfirmedGroup).WithOne(p => p.ConfirmedGroupMember)
                .HasForeignKey<ConfirmedGroupMember>(d => d.ConfirmedGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Confi__1332DBDC");

            entity.HasOne(d => d.User).WithMany(p => p.ConfirmedGroupMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__UserI__14270015");
        });

        modelBuilder.Entity<ConfirmedGroupMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Confirme__C87C037CEC8C4629");

            entity.ToTable("ConfirmedGroupMessage");

            entity.HasIndex(e => e.GroupId, "UQ__Confirme__149AF30BF16BB3EE").IsUnique();

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.MessageType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SentAt).HasColumnType("datetime");

            entity.HasOne(d => d.Group).WithOne(p => p.ConfirmedGroupMessage)
                .HasForeignKey<ConfirmedGroupMessage>(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Group__19DFD96B");

            entity.HasOne(d => d.Sender).WithMany(p => p.ConfirmedGroupMessages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Sende__1AD3FDA4");
        });

        modelBuilder.Entity<ConfirmedGroupMessageLocation>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Confirme__C87C037C47090D71");

            entity.ToTable("ConfirmedGroupMessageLocation");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");

            entity.HasOne(d => d.Message).WithOne(p => p.ConfirmedGroupMessageLocation)
                .HasForeignKey<ConfirmedGroupMessageLocation>(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Messa__236943A5");
        });

        modelBuilder.Entity<ConfirmedGroupMessageMedium>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Confirme__C87C037C743E89F8");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");
            entity.Property(e => e.MediaUrl).HasMaxLength(500);

            entity.HasOne(d => d.Message).WithOne(p => p.ConfirmedGroupMessageMedium)
                .HasForeignKey<ConfirmedGroupMessageMedium>(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Messa__208CD6FA");
        });

        modelBuilder.Entity<ConfirmedGroupMessageText>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Confirme__C87C037C7CE66664");

            entity.ToTable("ConfirmedGroupMessageText");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");

            entity.HasOne(d => d.Message).WithOne(p => p.ConfirmedGroupMessageText)
                .HasForeignKey<ConfirmedGroupMessageText>(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmed__Messa__1DB06A4F");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__8A9E148EF52D69F3");

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Airline).HasMaxLength(100);
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.FromLocation).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TicketClass).HasMaxLength(50);
            entity.Property(e => e.ToLocation).HasMaxLength(100);
        });

        modelBuilder.Entity<FlightBooking>(entity =>
        {
            entity.HasKey(e => e.FlightBookingId).HasName("PK__FlightBo__67A5D41B9E63A2C0");

            entity.Property(e => e.FlightBookingId).HasColumnName("FlightBookingID");
            entity.Property(e => e.BookedDate).HasColumnType("datetime");
            entity.Property(e => e.ConfirmedGroupId).HasColumnName("ConfirmedGroupID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ConfirmedGroup).WithMany(p => p.FlightBookings)
                .HasForeignKey(d => d.ConfirmedGroupId)
                .HasConstraintName("FK__FlightBoo__Confi__2A164134");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightBookings)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FlightBoo__Fligh__29221CFB");

            entity.HasOne(d => d.User).WithMany(p => p.FlightBookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FlightBoo__UserI__282DF8C2");
        });

        modelBuilder.Entity<Hashtag>(entity =>
        {
            entity.HasKey(e => e.HashtagId).HasName("PK__Hashtags__BEFA90CA693A472D");

            entity.Property(e => e.HashtagId).HasColumnName("HashtagID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__46023BBF5F06229B");

            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.HotelName).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<HotelBooking>(entity =>
        {
            entity.HasKey(e => e.HotelBookingId).HasName("PK__HotelBoo__36538172C9B1B704");

            entity.Property(e => e.HotelBookingId).HasColumnName("HotelBookingID");
            entity.Property(e => e.BookedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ConfirmedGroupId).HasColumnName("ConfirmedGroupID");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ConfirmedGroup).WithMany(p => p.HotelBookings)
                .HasForeignKey(d => d.ConfirmedGroupId)
                .HasConstraintName("FK__HotelBook__Confi__31B762FC");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelBookings)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HotelBook__Hotel__30C33EC3");

            entity.HasOne(d => d.User).WithMany(p => p.HotelBookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HotelBook__UserI__2FCF1A8A");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("PK__Likes__A2922CF4F9AD795E");

            entity.Property(e => e.LikeId).HasColumnName("LikeID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserLikedId).HasColumnName("UserLikedID");

            entity.HasOne(d => d.Post).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__PostID__5DCAEF64");

            entity.HasOne(d => d.UserLiked).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserLikedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__UserLiked__5EBF139D");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32BDAD10EE");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__45F365D3");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA126038B0CB0B0F");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__UserID__49C3F6B7");
        });

        modelBuilder.Entity<PostHashtag>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.HashtagId }).HasName("PK__PostHash__11FDC93499092584");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.HashtagId).HasColumnName("HashtagID");
            entity.Property(e => e.RawText).HasMaxLength(100);

            entity.HasOne(d => d.Hashtag).WithMany(p => p.PostHashtags)
                .HasForeignKey(d => d.HashtagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostHasht__Hasht__693CA210");

            entity.HasOne(d => d.Post).WithMany(p => p.PostHashtags)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostHasht__PostI__68487DD7");
        });

        modelBuilder.Entity<PostMedium>(entity =>
        {
            entity.HasKey(e => e.PostMediaId).HasName("PK__PostMedi__75C2311477F2A616");

            entity.Property(e => e.PostMediaId).HasColumnName("PostMediaID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Url).HasMaxLength(500);

            entity.HasOne(d => d.Post).WithMany(p => p.PostMedia)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostMedia__PostI__4CA06362");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A563C00D8");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SavedPost>(entity =>
        {
            entity.HasKey(e => e.SavedPostId).HasName("PK__SavedPos__7B99A02BF8720DBB");

            entity.Property(e => e.SavedPostId).HasColumnName("SavedPostID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserSavedPostId).HasColumnName("UserSavedPostID");

            entity.HasOne(d => d.Post).WithMany(p => p.SavedPosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SavedPost__PostI__628FA481");

            entity.HasOne(d => d.UserSavedPost).WithMany(p => p.SavedPosts)
                .HasForeignKey(d => d.UserSavedPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SavedPost__UserS__6383C8BA");
        });

        modelBuilder.Entity<SharedPost>(entity =>
        {
            entity.HasKey(e => e.SharedPostId).HasName("PK__SharedPo__C5B906C40AD1A5B0");

            entity.Property(e => e.SharedPostId).HasColumnName("SharedPostID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserSharedId).HasColumnName("UserSharedID");

            entity.HasOne(d => d.Post).WithMany(p => p.SharedPosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedPos__PostI__4F7CD00D");

            entity.HasOne(d => d.UserShared).WithMany(p => p.SharedPosts)
                .HasForeignKey(d => d.UserSharedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SharedPos__UserS__5070F446");
        });

        modelBuilder.Entity<TaggedUser>(entity =>
        {
            entity.HasKey(e => e.TaggedId).HasName("PK__TaggedUs__5B9F77415D2FCE5A");

            entity.Property(e => e.TaggedId).HasColumnName("TaggedID");
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Post).WithMany(p => p.TaggedUsers)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaggedUse__PostI__59063A47");

            entity.HasOne(d => d.UserTaggedNavigation).WithMany(p => p.TaggedUsers)
                .HasForeignKey(d => d.UserTagged)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaggedUse__UserT__59FA5E80");
        });

        modelBuilder.Entity<TemporaryGroup>(entity =>
        {
            entity.HasKey(e => e.TemporaryGroupId).HasName("PK__Temporar__98C5852F7E9E9E5F");

            entity.ToTable("TemporaryGroup");

            entity.HasIndex(e => e.CompanionTripId, "UQ__Temporar__002F56A88B394C93").IsUnique();

            entity.Property(e => e.TemporaryGroupId).HasColumnName("TemporaryGroupID");
            entity.Property(e => e.CompanionTripId).HasColumnName("CompanionTripID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CompanionTrip).WithOne(p => p.TemporaryGroup)
                .HasForeignKey<TemporaryGroup>(d => d.CompanionTripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Compa__75A278F5");
        });

        modelBuilder.Entity<TemporaryGroupMember>(entity =>
        {
            entity.HasKey(e => new { e.TemporaryGroupId, e.UserId }).HasName("PK__Temporar__49BD09E56C83F32E");

            entity.ToTable("TemporaryGroupMember");

            entity.HasIndex(e => e.TemporaryGroupId, "UQ__Temporar__98C5852EB88F3B8D").IsUnique();

            entity.Property(e => e.TemporaryGroupId).HasColumnName("TemporaryGroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoinAt).HasColumnType("datetime");

            entity.HasOne(d => d.TemporaryGroup).WithOne(p => p.TemporaryGroupMember)
                .HasForeignKey<TemporaryGroupMember>(d => d.TemporaryGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Tempo__7A672E12");

            entity.HasOne(d => d.User).WithMany(p => p.TemporaryGroupMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__UserI__7B5B524B");
        });

        modelBuilder.Entity<TemporaryGroupMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Temporar__C87C037C966C1906");

            entity.ToTable("TemporaryGroupMessage");

            entity.HasIndex(e => e.GroupId, "UQ__Temporar__149AF30B6A6F435A").IsUnique();

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.MessageType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SentAt).HasColumnType("datetime");

            entity.HasOne(d => d.Group).WithOne(p => p.TemporaryGroupMessage)
                .HasForeignKey<TemporaryGroupMessage>(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Group__01142BA1");

            entity.HasOne(d => d.Sender).WithMany(p => p.TemporaryGroupMessages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Sende__02084FDA");
        });

        modelBuilder.Entity<TemporaryGroupMessageLocation>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Temporar__C87C037C7890B8A3");

            entity.ToTable("TemporaryGroupMessageLocation");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");

            entity.HasOne(d => d.Message).WithOne(p => p.TemporaryGroupMessageLocation)
                .HasForeignKey<TemporaryGroupMessageLocation>(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Messa__0A9D95DB");
        });

        modelBuilder.Entity<TemporaryGroupMessageMedium>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Temporar__C87C037C2754AAD2");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");
            entity.Property(e => e.MediaUrl).HasMaxLength(500);

            entity.HasOne(d => d.Message).WithOne(p => p.TemporaryGroupMessageMedium)
                .HasForeignKey<TemporaryGroupMessageMedium>(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Messa__07C12930");
        });

        modelBuilder.Entity<TemporaryGroupMessageText>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Temporar__C87C037C89C4F3D9");

            entity.ToTable("TemporaryGroupMessageText");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");

            entity.HasOne(d => d.Message).WithOne(p => p.TemporaryGroupMessageText)
                .HasForeignKey<TemporaryGroupMessageText>(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Temporary__Messa__04E4BC85");
        });

        modelBuilder.Entity<TourGuide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("PK__TourGuid__E77EE03EB5B3AD87");

            entity.Property(e => e.GuideId)
                .ValueGeneratedNever()
                .HasColumnName("GuideID");
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Guide).WithOne(p => p.TourGuide)
                .HasForeignKey<TourGuide>(d => d.GuideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TourGuide__Guide__367C1819");
        });

        modelBuilder.Entity<TourGuideBooking>(entity =>
        {
            entity.HasKey(e => e.TourGuideBookingId).HasName("PK__TourGuid__DBA2C5AC3AC35D8B");

            entity.Property(e => e.TourGuideBookingId).HasColumnName("TourGuideBookingID");
            entity.Property(e => e.BookedDate).HasColumnType("datetime");
            entity.Property(e => e.GuideId).HasColumnName("GuideID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Guide).WithMany(p => p.TourGuideBookings)
                .HasForeignKey(d => d.GuideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TourGuide__Guide__3B40CD36");

            entity.HasOne(d => d.User).WithMany(p => p.TourGuideBookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TourGuide__UserI__3A4CA8FD");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4BC40855FD");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Money).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WalletId).HasColumnName("WalletID");

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Walle__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC57AB0BD0");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Avatar).HasMaxLength(500);
            entity.Property(e => e.BackgroundImage).HasMaxLength(500);
            entity.Property(e => e.Coin).HasDefaultValue(0);
            entity.Property(e => e.ConfirmToken)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MembershipTier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Personality).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__3A81B327");
        });

        modelBuilder.Entity<UserFollow>(entity =>
        {
            entity.HasKey(e => new { e.FollowerId, e.FollowingId }).HasName("PK__UserFoll__79CB03DBD9C11CEA");

            entity.Property(e => e.FollowerId).HasColumnName("FollowerID");
            entity.Property(e => e.FollowingId).HasColumnName("FollowingID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Follower).WithMany(p => p.UserFollowFollowers)
                .HasForeignKey(d => d.FollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserFollo__Follo__6C190EBB");

            entity.HasOne(d => d.Following).WithMany(p => p.UserFollowFollowings)
                .HasForeignKey(d => d.FollowingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserFollo__Follo__6D0D32F4");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__84D4F92EC0C90B49");

            entity.ToTable("Wallet");

            entity.HasIndex(e => e.UserId, "UQ__Wallet__1788CCADDFA0B3B5").IsUnique();

            entity.Property(e => e.WalletId).HasColumnName("WalletID");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Wallet)
                .HasForeignKey<Wallet>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wallet__UserID__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
