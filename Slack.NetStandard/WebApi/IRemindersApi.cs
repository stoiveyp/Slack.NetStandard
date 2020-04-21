using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reminder;

namespace Slack.NetStandard.WebApi
{
    public interface IRemindersApi
    {
        Task<ReminderResponse> Add(string text, string time, string user = null);

        Task<WebApiResponse> Complete(string reminder);
        Task<WebApiResponse> Delete(string reminder);
        Task<ReminderResponse> Info(string reminder);
        Task<ReminderListResponse> List();
    }
}