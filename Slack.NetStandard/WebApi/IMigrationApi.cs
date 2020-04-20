using System;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Migration;

namespace Slack.NetStandard.WebApi
{
    public interface IMigrationApi
    {
        Task<ExchangeResponse> Exchange(string[] users, bool? toOld = null);
    }
}
