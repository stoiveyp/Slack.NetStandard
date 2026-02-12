using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Entity
{
    public enum EntityErrorStatus
    {
        [EnumMember(Value = "restricted")] Restricted,
        [EnumMember(Value = "internal_error")] InternalError, 
        [EnumMember(Value = "not_found")] NotFound, 
        [EnumMember(Value = "custom")] Custom, 
        [EnumMember(Value = "custom_partial_view")] CustomPartialView, 
        [EnumMember(Value = "timeout")] Timeout, 
        [EnumMember(Value = "edit_error")] EditError
    }
}