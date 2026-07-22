using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Admin;
using Slack.NetStandard.WebApi.Apps;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_AdminApps
    {
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
        public async Task Admin_AppSetConfig()
        {
            await Utility.AssertWebApi(c => c.Admin.Apps.SetConfig(new AppConfig
            {
                AppId = "123ABC",
                DomainRestrictions = new DomainRestrictions
                {
                    Emails = new() { "test@test.com" },
                    Urls = new() { "test.com" }
                },
                WorkflowAuthStrategy = WorkflowAuthStrategy.EndUserOnly
            }),"admin.apps.config.set", jo =>
            {
                Assert.Equal("123ABC", jo.Value<string>("app_id"));
                Assert.Equal("end_user_only", jo.Value<string>("workflow_auth_strategy"));
                var domain = jo.Value<JObject>("domain_restrictions");
                Assert.NotNull(domain);
                domain.CompareJArray("emails","test@test.com");
                domain.CompareJArray("urls","test.com");
            });
        }

        [Fact]
        public async Task Admin_AppLookupConfig()
        {
            await Utility.AssertEncodedWebApi(
                c => c.Admin.Apps.LookupConfig(new []{"ABC","123"}),
                "admin.apps.config.lookup", "Web_AdminAppsConfigLookup.json",
                nvc =>
                {
                    Assert.Equal("ABC,123", nvc["app_ids"]);
                });
        }

    }
}
