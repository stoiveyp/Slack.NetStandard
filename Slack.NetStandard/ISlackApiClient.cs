﻿using System.Threading.Tasks;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard
{
    public interface ISlackApiClient
    {
        IConversationsApi Conversations { get; }
        IChatApi Chat { get; }

        IAdminApi Admin { get; }

        IViewApi View { get; }

        Task<WebApiResponse> Test(object data);
    }
}