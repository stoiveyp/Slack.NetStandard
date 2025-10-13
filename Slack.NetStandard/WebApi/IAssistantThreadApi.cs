using Slack.NetStandard.WebApi.Assistant;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IAssistantThreadApi
    {
        Task<WebApiResponse> SetStatus(string status, params string[] loadingMessages);
        Task<WebApiResponse> SetTitle(string title);
        Task<WebApiResponse> SetSuggestedPrompts(params Prompt[] prompts);
        Task<WebApiResponse> SetSuggestedPrompts(string title, params Prompt[] prompts);
    }
}