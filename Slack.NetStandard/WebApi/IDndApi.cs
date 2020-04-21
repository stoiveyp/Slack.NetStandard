using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Dnd;

namespace Slack.NetStandard.WebApi
{
    public interface IDndApi
    {
        Task<WebApiResponse> End();
        Task<DndStatus> EndSnooze();
        Task<DndStatus> Info(string user);
        Task<DndStatus> SetSnooze(int minutes);
        Task<DndTeamInfoResponse> TeamInfo(params string[] users);
    }
}
