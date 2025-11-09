using Slack.NetStandard.WebApi.Workflows;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_WorkflowsTriggersPermissions
    {
        [Fact]
        public async Task Permission_Add()
        {
            var triggerId = "Ft0000000001";
            var user1 = "U014KLZE350";
            var user2 = "U01565LTEBD";
            var channel1 = "C014LMDP71R";

            var response = await Utility.AssertWebApi(
                c => c.Workflows.Triggers.Permissions.Add(
                    new WorkflowTriggerPermissionManipulationRequest(triggerId)
                    {
                        UserIds = new() { user1, user2 },
                        ChannelIds = new() { channel1 }
                    }),
                "workflows.triggers.permissions.add",
                "Web_WorkflowsTriggerPermissionResponse.json",
                jobject =>
                {
                    Assert.Equal(triggerId, jobject.Value<string>("trigger_id"));
                    jobject.CompareJArray("user_ids", user1, user2);
                    jobject.CompareJArray("channel_ids", channel1);
                });
        }

        [Fact]
        public async Task Permission_Remove()
        {
            var triggerId = "Ft0000000001";
            var user1 = "U014KLZE350";
            var user2 = "U01565LTEBD";
            var channel1 = "C014LMDP71R";

            var response = await Utility.AssertWebApi(
                c => c.Workflows.Triggers.Permissions.Remove(
                    new WorkflowTriggerPermissionManipulationRequest(triggerId)
                    {
                        UserIds = new() { user1, user2 },
                        ChannelIds = new() { channel1 }
                    }),
                "workflows.triggers.permissions.remove",
                "Web_WorkflowsTriggerPermissionResponse.json",
                jobject =>
                {
                    Assert.Equal(triggerId, jobject.Value<string>("trigger_id"));
                    jobject.CompareJArray("user_ids", user1, user2);
                    jobject.CompareJArray("channel_ids", channel1);
                });
        }

        [Fact]
        public async Task Permission_Set()
        {
            var triggerId = "Ft0000000001";
            var permissionType = "named_entities";
            var user1 = "U014KLZE350";
            var user2 = "U01565LTEBD";
            var channel1 = "C014LMDP71R";

            var response = await Utility.AssertWebApi(
                c => c.Workflows.Triggers.Permissions.Set(
                    new WorkflowTriggerPermissionRequest(triggerId,permissionType)
                    {
                        UserIds = new() { user1, user2 },
                        ChannelIds = new() { channel1 }
                    }),
                "workflows.triggers.permissions.set",
                "Web_WorkflowsTriggerPermissionResponse.json",
                jobject =>
                {
                    Assert.Equal(triggerId, jobject.Value<string>("trigger_id"));
                    Assert.Equal(permissionType, jobject.Value<string>("permission_type"));
                    jobject.CompareJArray("user_ids", user1, user2);
                    jobject.CompareJArray("channel_ids", channel1);
                });
        }

        [Fact]
        public async Task Permission_List()
        {
            var triggerId = "Ft0000000001";

            var response = await Utility.AssertWebApi(
                c => c.Workflows.Triggers.Permissions.List(triggerId),
                "workflows.triggers.permissions.list",
                "Web_WorkflowsTriggerPermissionResponse.json",
                jobject =>
                {
                    Assert.Equal(triggerId, jobject.Value<string>("trigger_id"));
                });
        }
    }
}
