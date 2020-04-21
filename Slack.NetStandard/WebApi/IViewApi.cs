using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.View;

namespace Slack.NetStandard.WebApi
{
    public interface IViewApi
    {
        Task<ViewResponse> Publish(string user, Objects.View view, string hash = null);
        Task<ViewResponse> Open(string trigger, Objects.View view);
        Task<ViewResponse> Push(string trigger, Objects.View view);
        Task<ViewResponse> UpdateByExternalId(string externalId, Objects.View view, string hash = null);
        Task<ViewResponse> UpdateByViewId(string viewId, Objects.View view, string hash = null);
    }
}
