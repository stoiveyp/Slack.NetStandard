﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Users;

namespace Slack.NetStandard.WebApi
{
    internal class UsersApi : IUsersApi
    {
        private readonly IWebApiClient _client;
        public IUsersProfileApi Profile { get; }

        public UsersApi(IWebApiClient client)
        {
            _client = client;
            Profile = new UsersProfileApi(client);
        }
        
        public Task<ChannelListResponse> Conversations(UserConversationRequest request = null)
        {
            if (request == null)
            {
                return _client.MakeUrlEncodedCall<ChannelListResponse>("users.conversations", new Dictionary<string, string>());
            }

            return _client.MakeUrlEncodedCall<ChannelListResponse>("users.conversations", request);
        }

        public Task<WebApiResponse> DeletePhoto()
        {
            return _client.MakeUrlEncodedCall("users.deletePhoto");
        }

        public Task<PresenceResponse> GetPresence(string user)
        {
            return _client.MakeUrlEncodedCall<PresenceResponse>("users.getPresence",new Dictionary<string, string>{{nameof(user),user}});
        }

        public Task<UserIdentityResponse> Identity()
        {
            return _client.MakeUrlEncodedCall<UserIdentityResponse>("users.identity");
        }

        public Task<UserResponse> Info(string user, bool? includeLocale = null)
        {
            var dict = new Dictionary<string, string> {{nameof(user), user}}
                .AddIfValue("include_locale",includeLocale);

            return _client.MakeUrlEncodedCall<UserResponse>("users.info", dict);
        }
        
        public Task<UserListResponse> List(UserListRequest request)
        {
            return _client.MakeUrlEncodedCall<UserListResponse>("users.list", request);
        }

        public Task<UserResponse> LookupByEmail(string email)
        {
            return _client.MakeUrlEncodedCall<UserResponse>("users.lookupByEmail", new Dictionary<string, string> { { nameof(email), email } });
        }

        public Task<WebApiResponse> SetPresence(string presence)
        {
            return _client.MakeUrlEncodedCall("users.setPresence", new Dictionary<string, string> { { nameof(presence), presence } });
        }

        public Task<WebApiResponse> SetPhoto(MultipartFile image, int? squareSize = null)
        {
            return _client.MakeMultiPartCall<WebApiResponse>("users.setPhoto", new Dictionary<string, string>().AddIfValue("crop_w", squareSize),
                new Dictionary<string, MultipartFile> {{"image", image}});
        }

        public Task<WebApiResponse> SetPhoto(MultipartFile image, int cropX, int cropY)
        {
            var dict = new Dictionary<string, string>
            {
                {"crop_x", cropX.ToString()},
                {"crop_y", cropY.ToString()}
            };

            return _client.MakeMultiPartCall<WebApiResponse>("users.setPhoto", dict,
                new Dictionary<string, MultipartFile> { { "image", image } });
        }
    }
}