using Wetrip.Data.GenericRepository;
using Wetrip.Data.IRepositories;
using Wetrip.Data.Repositories;
using Wetrip.Data.UnitOfWork;
using Wetrip.Service.IServices;
using Wetrip.Service.Services;

namespace Wetrip.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {
            //Add Scope for Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICompanionTripRepository, CompanionTripRepository>();
            services.AddScoped<IConfirmedGroupMemberRepository,ConfirmedGroupMemberRepository>();
            services.AddScoped<IConfirmedGroupMessageLocationRepository,ConfirmedGroupMessageLocationRepository>();
            services.AddScoped<IConfirmedGroupMessageMediumRepository,ConfirmedGroupMessageMediumRepository>();
            services.AddScoped<IConfirmedGroupMessageRepository,ConfirmedGroupMessageRepository>();
            services.AddScoped<IConfirmedGroupMessageTextRepository,ConfirmedGroupMessageTextRepository>();
            services.AddScoped<IConfirmedGroupRepository,ConfirmedGroupRepository>();
            services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IHashtagRepository, HashtagRepository>();
            services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IPostHashtagRepository, PostHashtagRepository>();
            services.AddScoped<IPostMediumRepository, PostMediumRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISavedPostRepository, SavedPostRepository>();
            services.AddScoped<ISharedPostRepository, SharedPostRepository>();
            services.AddScoped<ITaggedUserRepository, TaggedUserRepository>(); 
            services.AddScoped<ITemporaryGroupMemberRepository, TemporaryGroupMemberRepository>();
            services.AddScoped<ITemporaryGroupMessageLocationRepository, TemporaryGroupMessageLocationRepository>();
            services.AddScoped<ITemporaryGroupMessageMediumRepository, TemporaryGroupMessageMediumRepository>();
            services.AddScoped<ITemporaryGroupMessageRepository, TemporaryGroupMessageRepository>();
            services.AddScoped<ITemporaryGroupMessageTextRepository, TemporaryGroupMessageTextRepository>();
            services.AddScoped<ITemporaryGroupRepository, TemporaryGroupRepository>();
            services.AddScoped<ITourGuideBookingRepository, TourGuideBookingRepository>();
            services.AddScoped<ITourGuideRepository, TourGuideRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserFollowRepository, UserFollowRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();

            // Add Scope for service
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICompanionTripService, CompanionTripService>();
            services.AddScoped<IConfirmedGroupMemberService, ConfirmedGroupMemberService>();
            services.AddScoped<IConfirmedGroupMessageLocationService, ConfirmedGroupMessageLocationService>();
            services.AddScoped<IConfirmedGroupMessageMediumService, ConfirmedGroupMessageMediumService>();
            services.AddScoped<IConfirmedGroupMessageService, ConfirmedGroupMessageService>();
            services.AddScoped<IConfirmedGroupMessageTextService, ConfirmedGroupMessageTextService>();
            services.AddScoped<IConfirmedGroupService, ConfirmedGroupService>();
            services.AddScoped<IFlightBookingService, FlightBookingService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IHashtagService, HashtagService>();
            services.AddScoped<IHotelBookingService, HotelBookingService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IPostHashtagService, PostHashtagService>();
            services.AddScoped<IPostMediumService, PostMediumService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISavedPostService, SavedPostService>();
            services.AddScoped<ISharedPostService, SharedPostService>();
            services.AddScoped<ITaggedUserService, TaggedUserService>();
            services.AddScoped<ITemporaryGroupMemberService, TemporaryGroupMemberService>();
            services.AddScoped<ITemporaryGroupMessageLocationService, TemporaryGroupMessageLocationService>();
            services.AddScoped<ITemporaryGroupMessageMediumService, TemporaryGroupMessageMediumService>();
            services.AddScoped<ITemporaryGroupMessageService, TemporaryGroupMessageService>();
            services.AddScoped<ITemporaryGroupMessageTextService, TemporaryGroupMessageTextService>();
            services.AddScoped<ITemporaryGroupService, TemporaryGroupService>();
            services.AddScoped<ITourGuideBookingService, TourGuideBookingService>();
            services.AddScoped<ITourGuideService, TourGuideService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserFollowService, UserFollowService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();

            return services;
        }
    }
}
