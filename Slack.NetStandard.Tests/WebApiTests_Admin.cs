using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;
using Slack.NetStandard.WebApi.Apps;
using Xunit;
using JArray = Newtonsoft.Json.Linq.JArray;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Admin
    {
        [Fact]
        public async Task Admin_AnalyticsGetFile()
        {
            await Utility.CheckApi(
                c => c.Admin.Analytics.GetFile("ABC", new DateTime(2020, 03, 01, 0, 0, 0, DateTimeKind.Utc)),
                "admin.analytics.getFile", nvc =>
                {
                    Assert.Equal("ABC", nvc.Get("type"));
                    Assert.Equal("2020-03-01", nvc.Get("date"));
                }, new HttpResponseMessage(HttpStatusCode.OK));
        }

        [Fact]
        public async Task Admin_AnalyticsGetFileMetadata()
        {
            await Utility.CheckApi(
                c => c.Admin.Analytics.GetFile(true),
                "admin.analytics.getFile", nvc =>
                {
                    Assert.Equal("public_channel", nvc.Get("type"));
                    Assert.Equal("true", nvc.Get("metadata_only"));
                }, new HttpResponseMessage(HttpStatusCode.OK));
        }

        [Fact]
        public async Task Admin_ApproveApp()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ApproveApp("ABC", "DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_ApproveRequest()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ApproveRequest("ABC", "DEF"),
                "admin.apps.approve",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("request_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_ClearResolution()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ClearResolution("ABC", "DEF", "ZYX"),
                "admin.apps.clearResolution",
                jobject =>
                {
                    Assert.Equal(3, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                    Assert.Equal("ZYX", jobject.Value<string>("enterprise_id"));
                });
        }

        [Fact]
        public async Task Apps_ActivitiesList()
        {
            var response = await Utility.AssertWebApi(c => c.Admin.Apps.ListActivities(new ListAdminActivitiesRequest
            {
                Limit = 5,
                MinLogLevel = LogLevel.Warn,
                Source = "STUFF"
            }), "admin.apps.activities.list", "Web_AppsListActivitiesResponse.json", jo =>
            {
                Assert.Equal(5, jo.Value<int>("limit"));
                Assert.Equal("warn", jo.Value<string>("min_log_level"));
                Assert.Equal("STUFF", jo.Value<string>("source"));
            });

            Assert.IsType<Activity<FunctionExecutionStartedPayload>>(Assert.Single(response.Activities));
        }

        [Fact]
        public async Task Admin_AnomalyGetItem()
        {
            var response = await Utility.AssertEncodedWebApi(
                c => c.Admin.AuditAnomaly.Allow.GetItem(),
                "admin.audit.anomaly.allow.getItem", "Web_AdminAuditAnomalyGetItem.json", nvc => { });

            Assert.Equal("8.8.8.8/24", response.TrustedCidr[0]);
            Assert.Equal("8.8.4.4/22", response.TrustedCidr[1]);
            Assert.Equal(12345, response.TrustedAsn[0]);
            Assert.Equal(12344, response.TrustedAsn[1]);
        }

        [Fact]
        public async Task Admin_AnomalyUpdateItem()
        {
            await Utility.AssertWebApi(
                c => c.Admin.AuditAnomaly.Allow.UpdateItem(new AllowListRequest
                {
                    TrustedAsn = new() { 12345, 12344 },
                    TrustedCidr = new() { "8.8.8.8/24", "8.8.4.4/22" }
                }),
                "admin.audit.anomaly.allow.updateItem",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    var trustedAsn = ((JArray)jobject["trusted_asns"]).ToObject<List<int>>();
                    Assert.Equal(12345, trustedAsn[0]);
                    Assert.Equal(12344, trustedAsn[1]);
                    var trustedCidr = ((JArray)jobject["trusted_cidr"]).ToObject<List<string>>();
                    Assert.Equal("8.8.8.8/24", trustedCidr[0]);
                    Assert.Equal("8.8.4.4/22", trustedCidr[1]);
                });
        }

        [Fact]
        public async Task Admin_AuthPolicyGetEntities()
        {
            var response = await Utility.AssertWebApi(
                c => c.Admin.AuthPolicy.GetEntities(new GetEntitiesRequest
                {
                    EntityType = EntityType.User,
                    PolicyName = "email_password",
                    Cursor = "xxx",
                    Limit = 5
                }),
                "admin.auth.policy.getEntities",
                "Web_AdminAuthPolicyGetEntities.json",
                jobject =>
                {
                    Assert.Equal("USER", jobject.Value<string>("entity_type"));
                    Assert.Equal("email_password", jobject.Value<string>("policy_name"));
                    Assert.Equal("xxx", jobject.Value<string>("cursor"));
                    Assert.Equal(5, jobject.Value<int>("limit"));
                });

            Assert.True(response.OK);
            Assert.Equal(1, response.EntityTotalCount);
            var entity = Assert.Single(response.Entities);
            Assert.Equal(EntityType.User, entity.EntityType);
            Assert.Equal("U1234", entity.EntityId);
            Assert.Equal(1620836993, entity.DateAdded);
        }

        [Fact]
        public async Task Admin_AuthPolicyAssignEntities()
        {
            await Utility.AssertWebApi(
                c => c.Admin.AuthPolicy.AssignEntities("email_password",
                    new List<string> { "U12345" }, EntityType.User),
                "admin.auth.policy.assignEntities",
                jobject =>
                {
                    var entities = ((JArray)jobject["entity_ids"]).ToObject<List<string>>();
                    var entityId = Assert.Single(entities);
                    Assert.Equal("U12345", entityId);
                    Assert.Equal("USER", jobject.Value<string>("entity_type"));
                    Assert.Equal("email_password", jobject.Value<string>("policy_name"));
                });
        }

        [Fact]
        public async Task Admin_AuthPolicyRemoveEntities()
        {
            await Utility.AssertWebApi(
                c => c.Admin.AuthPolicy.RemoveEntities("email_password",
                    new List<string> { "U12345" }, EntityType.User),
                "admin.auth.policy.removeEntities",
                jobject =>
                {
                    var entities = ((JArray)jobject["entity_ids"]).ToObject<List<string>>();
                    var entityId = Assert.Single(entities);
                    Assert.Equal("U12345", entityId);
                    Assert.Equal("USER", jobject.Value<string>("entity_type"));
                    Assert.Equal("email_password", jobject.Value<string>("policy_name"));
                });
        }

        [Fact]
        public async Task Admin_BarriersCreate()
        {
            var response = await Utility.AssertWebApi(
                c => c.Admin.Barriers.Create(new CreateBarrierRequest
                {
                    BarrieredFromUserGroupIds = new List<string>{ "S03TNHGAUGZ" },
                    PrimaryUserGroupId = "S03TZK4A9H6",
                    RestrictedSubjects = Barrier.AllThreeRestrictedSubjects()
                }),
                "admin.barriers.create",
                "Web_AdminBarrierCreateResponse.json",
                jobject =>
                {
                    var subjects = ((JArray)jobject["restricted_subjects"]).ToObject<List<string>>();
                    Assert.Equal("im", subjects[0]);
                    Assert.Equal("mpim", subjects[1]);
                    Assert.Equal("call", subjects[2]);
                    Assert.Equal("S03TZK4A9H6", jobject.Value<string>("primary_usergroup_id"));

                    var barriered = ((JArray)jobject["barriered_from_usergroup_ids"]).ToObject<List<string>>();
                    Assert.Equal("S03TNHGAUGZ", barriered.First());
                });
            Assert.True(Utility.CompareJson(response, "Web_AdminBarrierCreateResponse.json"));
        }

        [Fact]
        public async Task Admin_BarriersUpdate()
        {
            var response = await Utility.AssertWebApi(
                c => c.Admin.Barriers.Update(new UpdateBarrierRequest
                {
                    BarrierId = "xxx",
                    BarrieredFromUserGroupIds = new List<string> { "S03TNHGAUGZ" },
                    PrimaryUserGroupId = "S03TZK4A9H6",
                    RestrictedSubjects = Barrier.AllThreeRestrictedSubjects()
                }),
                "admin.barriers.update",
                "Web_AdminBarrierCreateResponse.json",
                jobject =>
                {
                    var subjects = ((JArray)jobject["restricted_subjects"]).ToObject<List<string>>();
                    Assert.Equal("im", subjects[0]);
                    Assert.Equal("mpim", subjects[1]);
                    Assert.Equal("call", subjects[2]);
                    Assert.Equal("S03TZK4A9H6", jobject.Value<string>("primary_usergroup_id"));
                    Assert.Equal("xxx", jobject.Value<string>("barrier_id"));

                    var barriered = ((JArray)jobject["barriered_from_usergroup_ids"]).ToObject<List<string>>();
                    Assert.Equal("S03TNHGAUGZ", barriered.First());
                });
            Assert.True(Utility.CompareJson(response, "Web_AdminBarrierCreateResponse.json"));
        }

        [Fact]
        public async Task Admin_BarriersList()
        {
            var response = await Utility.AssertEncodedWebApi(
                c => c.Admin.Barriers.List("ABC",5),
                "admin.barriers.list",
                "Web_AdminBarrierListResponse.json",
                nvc =>
                {
                    Assert.Equal("ABC", nvc["cursor"]);
                    Assert.Equal(5.ToString(), nvc["limit"]);
                });
            Assert.True(Utility.CompareJson(response, "Web_AdminBarrierListResponse.json"));
        }

        [Fact]
        public async Task Admin_BarriersDelete()
        {
            await Utility.AssertSingleEncodedWebApi(c => c.Admin.Barriers.Delete("xxx"),
                "admin.barriers.delete", "barrier_id", "xxx");
        }

        [Fact]
        public async Task Admin_RestrictApp()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.RestrictApp("ABC", "DEF"),
                "admin.apps.restrict",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_RestrictRequest()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.RestrictRequest("ABC", "DEF"),
                "admin.apps.restrict",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("request_id"));
                    Assert.Equal("DEF", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_Uninstall()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.UninstallApp("ABC", new List<string> { "DEF" }),
                "admin.apps.uninstall",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal("ABC", jobject.Value<string>("app_id"));
                    Assert.Equal("DEF", Assert.Single(jobject.Value<JArray>("team_ids").Values<string>()));
                });
        }

        [Fact]
        public async Task Admin_ListAppRequests()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListAppRequests(new TeamRequestFilter
                {
                    Limit = 20
                }),
                "admin.apps.requests.list", "Web_AdminAppsRequestsList.json",
                jobject =>
                {
                    Assert.Single(jobject.Children());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                });
        }

        [Fact]
        public async Task Admin_AppsCancel()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.CancelRequest("ABC123", "T12345", "E12345"),
                "admin.apps.requests.cancel",
                jobject =>
                {
                    Assert.Equal("ABC123", jobject.Value<string>("request_id"));
                    Assert.Equal("E12345", jobject.Value<string>("enterprise_id"));
                    Assert.Equal("T12345", jobject.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_ListAppApproved()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListApprovedApps(new TeamFilter
                {
                    Limit = 20,
                    Enterprise = "ABCDEF"
                }),
                "admin.apps.approved.list", "Web_AdminAppsApprovedList.json",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                    Assert.Equal("ABCDEF", jobject.Value<string>("enterprise_id"));
                });
        }

        [Fact]
        public async Task Admin_ListAppRestricted()
        {
            await Utility.AssertWebApi(
                c => c.Admin.Apps.ListRestrictedApps(new TeamFilter
                {
                    Limit = 20,
                    Enterprise = "ABCDEF"
                }),
                "admin.apps.restricted.list", "Web_AdminAppsRestrictedList.json",
                jobject =>
                {
                    Assert.Equal(2, jobject.Children().Count());
                    Assert.Equal(20, jobject.Value<int>("limit"));
                    Assert.Equal("ABCDEF", jobject.Value<string>("enterprise_id"));
                });
        }

        [Fact]
        public async Task Admin_EmojiList()
        {
            await Utility.AssertEncodedWebApi(c => c.Admin.Emoji.List("ABCDEF"), "admin.emoji.list", "Web_AdminEmojiList.json",
                j => Assert.Equal("ABCDEF", j["cursor"]));
        }

        [Fact]
        public async Task Admin_EmojiAdd()
        {
            await Utility.AssertEncodedWebApi(c => c.Admin.Emoji.Add(":myemoji:", "urlGoesHere"), "admin.emoji.add",
                j =>
                {
                    Assert.Equal(":myemoji:", j["name"]);
                    Assert.Equal("urlGoesHere", j["url"]);
                });
        }

        [Fact]
        public async Task Admin_InviteRequestApprove()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.Approve("ABCDEF", "DEFGHI"), "admin.inviteRequests.approve",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("invite_request_id"));
                    Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_InviteRequestDeny()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.Deny("ABCDEF", "DEFGHI"), "admin.inviteRequests.deny",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("invite_request_id"));
                    Assert.Equal("DEFGHI", j.Value<string>("team_id"));
                });
        }

        [Fact]
        public async Task Admin_InviteRequestList()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.ListInviteRequests(new TeamFilter()), "admin.inviteRequests.list",
                j =>
                {
                });
        }

        [Fact]
        public async Task Admin_InviteRequestListApproved()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.ListApprovedInviteRequests(new TeamFilter { Cursor = "ABCDEF" }), "admin.inviteRequests.approved.list",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("cursor"));
                });
        }

        [Fact]
        public async Task Admin_InviteRequestListDenied()
        {
            await Utility.AssertWebApi(c => c.Admin.InviteRequests.ListDeniedInviteRequests(new TeamFilter { Cursor = "ABCDEF" }), "admin.inviteRequests.denied.list",
                j =>
                {
                    Assert.Equal("ABCDEF", j.Value<string>("cursor"));
                });
        }
    }
}
