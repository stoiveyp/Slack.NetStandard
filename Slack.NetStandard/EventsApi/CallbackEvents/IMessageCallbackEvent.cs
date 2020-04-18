namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public interface IMessageCallbackEvent : ICallbackEvent
    {
        string Subtype { get; set; }
    }
}