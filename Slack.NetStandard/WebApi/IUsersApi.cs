using System.IO;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Users;

namespace Slack.NetStandard.WebApi
{
    public interface IUsersApi
    {
        Task<ChannelListResponse> Conversations(UserConversationRequest request = null);
        Task<WebApiResponse> DeletePhoto();

        Task<PresenceResponse> GetPresence(string user);

        Task<UserIdentityResponse> Identity();

        Task<UserResponse> Info(string user, bool? includeLocale = null);
        Task<UserListResponse> List(string cursor, bool? includeLocale = null);
        Task<UserListResponse> List(int limit, bool? includeLocale = null);
        Task<UserListResponse> List(string cursor = null, int? limit = null, bool? includeLocale = null);

        Task<UserResponse> LookupByEmail(string email);

        Task<WebApiResponse> SetPresence(string presence);

        Task<WebApiResponse> SetPhoto(Stream image, int? squareSize = null);
        Task<WebApiResponse> SetPhoto(Stream image, int cropX, int cropY);

        IUsersProfileApi Profile{ get; }
    }

    public interface IUsersProfileApi
    {
        Task<UserProfileResponse> Get(string user = null, string includeLabels = null);
        Task<UserProfileResponse> Set(UserProfileSetRequest request);
    }
}