using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Reminder;

namespace Slack.NetStandard.WebApi
{
    internal class RemindersApi : IRemindersApi
    {
        private readonly IWebApiClient _client;

        public RemindersApi(IWebApiClient client)
        {
            _client = client;
        }


        public Task<ReminderResponse> Add(string text, string time, string user = null)
        {
            return _client.MakeJsonCall<AddReminderRequest,ReminderResponse>("reminders.add",new AddReminderRequest
            {
                Text = text,
                Time = time,
                User = user
            });
        }

        public Task<WebApiResponse> Complete(string reminder)
        {
            return _client.MakeUrlEncodedCall("reminders.complete",
                new Dictionary<string, string> {{"reminder", reminder}});
        }

        public Task<WebApiResponse> Delete(string reminder)
        {
            return _client.MakeUrlEncodedCall("reminders.delete",
                new Dictionary<string, string> { { "reminder", reminder } });
        }

        public Task<ReminderResponse> Info(string reminder)
        {
            return _client.MakeUrlEncodedCall<ReminderResponse>("reminders.info",
                new Dictionary<string, string> { { "reminder", reminder } });
        }

        public Task<ReminderListResponse> List()
        {
            return _client.MakeUrlEncodedCall<ReminderListResponse>("reminders.list", new Dictionary<string, string>( ));
        }
    }
}