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
        Task<UserListResponse> List(UserListRequest request);

        Task<UserResponse> LookupByEmail(string email);

        Task<WebApiResponse> SetPresence(string presence);

        Task<WebApiResponse> SetPhoto(MultipartFile image, int? squareSize = null);
        Task<WebApiResponse> SetPhoto(MultipartFile image, int cropX, int cropY);

        IUsersProfileApi Profile{ get; }
    }
}