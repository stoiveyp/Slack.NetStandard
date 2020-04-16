using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminUsersApi
    {
        Task<WebApiResponse> Assign(AssignUserRequest request);
        Task Invite();
        Task List();
        Task Remove();
        Task SetAdmin();
        Task SetExpiration();
        Task SetOwner();
        Task SetRegular();

        Task ResetSession();
    }
}
