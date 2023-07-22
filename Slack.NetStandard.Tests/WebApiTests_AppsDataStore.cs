using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Apps;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_AppsDataStore
    {
        [Fact]
        public async Task AppsDataStore_Get()
        {
            var response = await Utility.AssertWebApi(sc => sc.Apps.Datastore.Get("good_tunes", "4"), "apps.datastore.get", "Web_AppsDatastoreItem.json",
                jo =>
                {
                    Assert.Equal("good_tunes", jo.Value<string>("datastore"));
                    Assert.Equal("4", jo.Value<string>("id"));
                });

            Assert.Equal("good_tunes", response.Datastore);
        }

        [Fact]
        public async Task AppsDataStore_Put()
        {
            var response = await Utility.AssertWebApi(sc => sc.Apps.Datastore.Put("good_tunes",new Dictionary<string, object>
                {
                    {"song","I Will Always Love You"}
                }, "A123"), "apps.datastore.put", "Web_AppsDatastoreItem.json",
                jo =>
                {
                    Assert.Equal("good_tunes", jo.Value<string>("datastore"));
                    Assert.Equal("A123", jo.Value<string>("app_id"));
                    Assert.Equal("I Will Always Love You", jo.Value<JObject>("item").Value<string>("song"));
                });

            Assert.Equal("good_tunes", response.Datastore);
        }

        [Fact]
        public async Task AppsDataStore_Query()
        {
            var query = new DatastoreQueryRequest("ds123")
            {
                ExpressionAttributes = new Dictionary<string, object> { { "#song", "song" } }
            };
            var response = await Utility.AssertWebApi(sc => sc.Apps.Datastore.Query(query), "apps.datastore.query", "Web_AppsDatastoreQuery.json",
                jo =>
                {
                    Assert.Equal("ds123", jo.Value<string>("datastore"));
                    Assert.Equal("song", jo.Value<JObject>("expression_attributes").Value<string>("#song"));
                });

            Assert.Equal("good_tunes", response.Datastore);
            Assert.Equal(2, response.Items.Length);
        }

        [Fact]
        public async Task AppsDataStore_Update()
        {
            var response = await Utility.AssertWebApi(sc => sc.Apps.Datastore.Update("good_tunes", new Dictionary<string, object>
                {
                    {"song","I Will Always Love You"}
                }, "A123"), "apps.datastore.update", "Web_AppsDatastoreItem.json",
                jo =>
                {
                    Assert.Equal("good_tunes", jo.Value<string>("datastore"));
                    Assert.Equal("A123", jo.Value<string>("app_id"));
                    Assert.Equal("I Will Always Love You", jo.Value<JObject>("item").Value<string>("song"));
                });

            Assert.Equal("good_tunes", response.Datastore);
        }
    }
}
