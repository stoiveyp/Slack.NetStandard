using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.Objects
{
    public class Channel:SlackId
    {
        [JsonProperty("is_channel",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsChannel { get; set; }

        [JsonProperty("is_group",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsGroup { get; set; }

        [JsonProperty("is_im",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIm { get; set; }

        [JsonProperty("created",NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }

        [JsonProperty("is_archived",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsArchived { get; set; }

        [JsonProperty("is_general",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsGeneral { get; set; }

        [JsonProperty("unlinked",NullValueHandling = NullValueHandling.Ignore)]
        public int? Unlinked { get; set; }

        [JsonProperty("name_normalized",NullValueHandling = NullValueHandling.Ignore)]
        public string NameNormalized { get; set; }

        [JsonProperty("is_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsShared { get; set; }

        [JsonProperty("is_ext_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsExternallyShared { get; set; }

        [JsonProperty("is_org_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOrgShared { get; set; }

        [JsonProperty("pending_shared",NullValueHandling = NullValueHandling.Ignore)]
        public string[] PendingShared { get; set; }

        [JsonProperty("is_pending_ext_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPendingExtShared { get; set; }

        [JsonProperty("is_member",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMember { get; set; }

        [JsonProperty("is_private",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }

        [JsonProperty("is_mpim",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNpim { get; set; }

        [JsonProperty("last_read",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp LastRead { get; set; }

        [JsonProperty("latest",NullValueHandling = NullValueHandling.Ignore)]
        public Message Latest { get; set; }

        [JsonProperty("unread_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? UnreadCount { get; set; }

        [JsonProperty("unread_count_display",NullValueHandling = NullValueHandling.Ignore)]
        public int? UnreadCountDisplay { get; set; }

        [JsonProperty("topic",NullValueHandling = NullValueHandling.Ignore)]
        public ChannelValue Topic { get; set; }

        [JsonProperty("purpose",NullValueHandling = NullValueHandling.Ignore)]
        public ChannelValue Purpose { get; set; }

        [JsonProperty("previous_names",NullValueHandling = NullValueHandling.Ignore)]
        public string[] PreviousNames { get; set; }

        [JsonProperty("priority",NullValueHandling = NullValueHandling.Ignore)]
        public double? Priority { get; set; }

        [JsonProperty("locale",NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        [JsonProperty("num_members",NullValueHandling = NullValueHandling.Ignore)]
        public int? NumMembers { get; set; }

        [JsonProperty("is_open",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOpen { get; set; }



    }
}
