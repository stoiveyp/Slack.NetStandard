using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.View;

namespace Slack.NetStandard.WebApi
{
    public interface IViewApi
    {
        Task<ViewResponse> Publish(string userId, Objects.View view, string hash = null);
    }
}
