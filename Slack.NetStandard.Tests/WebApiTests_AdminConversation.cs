using System.Collections.Generic;
using Slack.NetStandard.WebApi.Admin;
using System.Linq;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi;
using Xunit;

namespace Slack.NetStandard.Tests;

public class WebApiTests_AdminConversation
{
    [Fact]
    public async Task Admin_ConversationsArchive()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.Archive("xxx"),
            "admin.conversations.archive", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsBulkArchive()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkArchive(new[] { "xxx", "yyy" }),
            "admin.conversations.bulkArchive",
            "Web_AdminConversationBulkActionResponse.json",
            jobject => { jobject.CompareJArray("channel_ids", "xxx", "yyy"); });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsBulkDelete()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkDelete(new[] { "xxx", "yyy" }),
            "admin.conversations.bulkDelete",
            "Web_AdminConversationBulkActionResponse.json",
            jobject => { jobject.CompareJArray("channel_ids", "xxx", "yyy"); });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsBulkMove()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.BulkMove("T123456789", new[] { "xxx", "yyy" }),
            "admin.conversations.bulkMove",
            "Web_AdminConversationBulkActionResponse.json",
            jobject =>
            {
                Assert.Equal("T123456789", jobject.Value<string>("target_team_id"));
                jobject.CompareJArray("channel_ids", "xxx", "yyy");
            });

        Assert.Equal("Ab123456", response.BulkActionId);
        var notAdded = Assert.Single(response.NotAdded);
        Assert.Equal("C12346", notAdded.ChannelId);
        Assert.Equal("invalid_channel", notAdded.Error);
    }

    [Fact]
    public async Task Admin_ConversationsSetTeams()
    {
        await Utility.AssertWebApi(
            c => c.Admin.Conversations.SetTeams(new SetTeamsRequest("ABCDEF")
            {
                OrgChannel = true
            }),
            "admin.conversations.setTeams",
            jobject =>
            {
                Assert.Equal(2, jobject.Children().Count());
                Assert.True(jobject.Value<bool>("org_channel"));
                Assert.Equal("ABCDEF", jobject.Value<string>("channel_id"));
            });
    }

    [Fact]
    public async Task Admin_ConversationsConvertToPrivate()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.ConvertToPrivate("xxx"),
            "admin.conversations.convertToPrivate", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsConvertToPublic()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.ConvertToPublic("xxx"),
            "admin.conversations.convertToPublic", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsCreate()
    {
        var response = await Utility.AssertWebApi(
            c => c.Admin.Conversations.Create(new CreateConversationRequest
            {
                IsPrivate = true,
                Name = "mychannel",
                Description = "description",
                OrgWide = true,
                TeamId = "T12345"
            }),
            "admin.conversations.create",
            jobject =>
            {
                Assert.True(jobject.Value<bool>("is_private"));
                Assert.True(jobject.Value<bool>("org_wide"));
                Assert.Equal("description", jobject.Value<string>("description"));
                Assert.Equal("mychannel", jobject.Value<string>("name"));
                Assert.Equal("T12345", jobject.Value<string>("team_id"));
            }, new CreateConversationResponse { ChannelId = "C12345", OK = true });

        Assert.True(response.OK);
        Assert.Equal("C12345", response.ChannelId);
    }

    [Fact]
    public async Task Admin_ConversationsDelete()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.Delete("xxx"),
            "admin.conversations.delete", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationsDisconnectShared()
    {
        await Utility.AssertWebApi(
        c => c.Admin.Conversations.DisconnectShared("C1235", new[] { "xxx", "yyy" }),
    "admin.conversations.disconnectShared",
        jobject =>
        {
            Assert.Equal("C1235", jobject.Value<string>("channel_id"));
            jobject.CompareJArray("leaving_team_ids", "xxx", "yyy");
        });
    }

    [Fact]
    public async Task Admin_ConversationsPrefs()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.GetConversationPrefs("xxx"), "admin.conversations.getConversationPrefs", "channel_id", "xxx", new ConversationPrefsResponse { OK = true });
    }

    [Fact]
    public async Task Admin_ConversationsGetCustomRetention()
    {
        var response = await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.GetCustomRetention("xxx"), "admin.conversations.getCustomRetention", "channel_id", "xxx", new CustomRetentionResponse { OK = true, IsPolicyEnabled = true, DurationDays = 70 });
        Assert.True(response.IsPolicyEnabled);
        Assert.Equal(70, response.DurationDays);
    }

    [Fact]
    public async Task Admin_ConversationGetTeams()
    {
        var response = await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.GetTeams("xxx", "C1234", 5),
            "admin.conversations.getTeams", "Web_ConversationGetTeams.json", nvc =>
            {
                Assert.Equal("xxx", nvc["channel_id"]);
                Assert.Equal("C1234", nvc["cursor"]);
                Assert.Equal(5.ToString(), nvc["limit"]);
            });

        Assert.Equal(2, response.TeamIds.Length);
        Assert.Equal("T1234", response.TeamIds[0]);
        Assert.Equal("T5679", response.TeamIds[1]);
    }

    [Fact]
    public async Task Admin_ConversationInvite()
    {
        await Utility.AssertWebApi(c => c.Admin.Conversations.Invite("C1234", new[] { "U1234", "U5678" }), "admin.conversations.invite",
            jo =>
            {
                Assert.Equal("C1234", jo.Value<string>("channel_id"));
                jo.CompareJArray("user_ids", "U1234", "U5678");
            });
    }

    [Fact]
    public async Task Admin_ConversationLookup()
    {
        var request = new LookupRequest
        {
            LastMessageActivityBefore = 12345,
            TeamIds = new List<string>(new[] { "T1234", "T3456" }),
            Cursor = "C1234",
            Limit = 10,
            MaxMemberCount = 20
        };
        var response = await Utility.AssertWebApi(c => c.Admin.Conversations.Lookup(request), "admin.conversations.lookup", "Web_ConversationLookup.json",
            jo =>
            {
                Assert.Equal(12345, jo.Value<long>("last_message_activity_before"));
                Assert.Equal("C1234", jo.Value<string>("cursor"));
                Assert.Equal(10, jo.Value<long>("limit"));
                Assert.Equal(20, jo.Value<long>("max_member_count"));
                jo.CompareJArray("team_ids", "T1234", "T3456");
            });
        Assert.Equal(2, response.Channels.Length);
        Assert.Equal("encoded_id_1", response.Channels[0]);
        Assert.Equal("encoded_id_2", response.Channels[1]);
    }

    [Fact]
    public async Task Admin_ConversationRemoveCustomRetention()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.RemoveCustomRetention("xxx"),
            "admin.conversations.removeCustomRetention", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationRename()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.Rename("C234", "newName"),
            "admin.conversations.rename", nvc =>
            {
                Assert.Equal("C234", nvc["channel_id"]);
                Assert.Equal("newName", nvc["name"]);
            });
    }

    [Fact]
    public async Task Admin_ConversationsSearch()
    {
        var request = new SearchConversationRequest
        {
            ConnectedTeamIds = new List<string> { "T1234" },
            Cursor = "C123",
            Limit = 5,
            Query = "TEST",
            SearchChannelTypes = new List<ConversationSearchChannelType>
 {
     ConversationSearchChannelType.ExcludeArchived
 },
            Sort = ConversationSortMethod.MemberCount,
            SortDirection = SortDirection.Ascending,
            TeamIds = new List<string> { "T4567" }
        };
        var response = await Utility.AssertWebApi(c => c.Admin.Conversations.Search(request),
    "admin.conversations.search", "Web_ConversationSearch.json", jo =>
    {
        Assert.Equal("TEST", jo.Value<string>("query"));
        Assert.Equal("C123", jo.Value<string>("cursor"));
        Assert.Equal(5, jo.Value<int>("limit"));
        Assert.Equal("member_count", jo.Value<string>("sort"));
        Assert.Equal("asc", jo.Value<string>("sort_dir"));
        jo.CompareJArray("search_channel_types", "exclude_archived");
        jo.CompareJArray("connected_team_ids", "T1234");
        jo.CompareJArray("team_ids", "T4567");
    });
        Assert.Equal(2, response.Conversations.Length);
    }

    [Fact]
    public async Task Admin_ConversationsSetConversationPrefs()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.SetConversationPrefs("C234", new SetConversationPrefsRequest
        {
            CanHuddle = true,
            WhoCanPost = "user",
            CanThread = "test2"
        }),
            "admin.conversations.setConversationPrefs", nvc =>
            {
                Assert.Equal("C234", nvc["channel_id"]);
                Assert.Equal("{'who_can_post':'user','can_thread':'test2','can_huddle':true}", nvc["prefs"]);
            });
    }

    [Fact]
    public async Task Admin_ConversationsSetCustomRetention()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.SetCustomRetention("C234", 50),
            "admin.conversations.setCustomRetention", nvc =>
            {
                Assert.Equal("C234", nvc["channel_id"]);
                Assert.Equal(50.ToString(), nvc["duration_days"]);
            });
    }

    [Fact]
    public async Task Admin_ConversationsUnarchive()
    {
        await Utility.AssertSingleEncodedWebApi(c => c.Admin.Conversations.Unarchive("xxx"),
            "admin.conversations.unarchive", "channel_id", "xxx");
    }

    [Fact]
    public async Task Admin_ConversationEkmListOriginalConnectedChannelInfo()
    {
        var request = new EkmOriginalConnectedRequest
        {
            ChannelIds = "C1234,C3456",
            TeamIds = "T1234,T3456",
            Cursor = "C1234",
            Limit = 10,
        };
        var response = await Utility.AssertWebApi(c => c.Admin.Conversations.EkmListOriginalConnectedChannelInfo(request), "admin.conversations.ekm.listOriginalConnectedChannelInfo", "Web_ConversationsEkm.json",
            jo =>
            {
                Assert.Equal(10, jo.Value<long>("limit"));
                Assert.Equal("C1234", jo.Value<string>("cursor"));
                Assert.Equal("C1234,C3456", jo.Value<string>("channel_ids"));
                Assert.Equal("T1234,T3456", jo.Value<string>("team_ids"));
            });
        var channelInfo = Assert.Single(response.Channels);
        Assert.Equal("id", channelInfo.Id);
        Assert.Equal("host_id", channelInfo.OriginalConnectedHostId);
        Assert.Equal("channel_id", channelInfo.OriginalConnectedChannelId);
    }

    [Fact]
    public async Task Admin_ConversationRestrictedAccessAdd()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.RestrictAccessAddGroup("C1234", "G1234", "T1234"),
            "admin.conversations.restrictAccess.addGroup",  nvc =>
            {
                Assert.Equal("C1234", nvc["channel_id"]);
                Assert.Equal("G1234", nvc["group_id"]);
                Assert.Equal("T1234", nvc["team_id"]);
            });
    }

    [Fact]
    public async Task Admin_ConversationRestrictedAccessRemove()
    {
        await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.RestrictAccessRemoveGroup("C1234", "G1234", "T1234"),
            "admin.conversations.restrictAccess.removeGroup", nvc =>
            {
                Assert.Equal("C1234", nvc["channel_id"]);
                Assert.Equal("G1234", nvc["group_id"]);
                Assert.Equal("T1234", nvc["team_id"]);
            });
    }

    [Fact]
    public async Task Admin_ConversationRestrictedAccessList()
    {
        var response = await Utility.AssertEncodedWebApi(c => c.Admin.Conversations.RestrictAccessListGroups("C1234", "T1234"),
            "admin.conversations.restrictAccess.listGroups", "Web_ConversationsRestrictAccessListResponse.json", nvc =>
            {
                Assert.Equal("C1234", nvc["channel_id"]);
                Assert.Equal("T1234", nvc["team_id"]);
            });
        Assert.Equal("YOUR_GROUP_ID",Assert.Single(response.GroupIds));
    }
}