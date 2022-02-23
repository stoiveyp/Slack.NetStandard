using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Slack.NetStandard.WebApi.Bookmarks
{
    public enum BookmarkType
    {
        [EnumMember(Value="link")]
        Link,
        [EnumMember(Value="message")]
        Message,
        [EnumMember(Value="file")]
        File,
        [EnumMember(Value="local_folder")]
        LocalFolder,
        [EnumMember(Value="pinned_message")]
        PinnedMessage
    }
}
