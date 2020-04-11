using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public static class Utility
    {
        private const string ExamplesPath = "Examples";
        public static bool CompareJson(object actual, string expectedFile)
        {
            var expected = ExampleFileContent(expectedFile);
            var actualJObject = JObject.FromObject(actual);
            var expectedJObject = JObject.Parse(expected);
            return JToken.DeepEquals(expectedJObject, actualJObject);
        }
        public static T ExampleFileContent<T>(string expectedFile)
        {
            using (var reader = new JsonTextReader(new StringReader(ExampleFileContent(expectedFile))))
            {
                return new JsonSerializer().Deserialize<T>(reader);
            }
        }
        public static string ExampleFileContent(string expectedFile)
        {
            return File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
        }

        public static Task<TResponse> CheckApi<TResponse>(
            Func<SlackWebApiClient, Task<TResponse>> requestCall,
            string url,
            Action<JObject> requestCheck,
            TResponse responseToSend)
        {
            var http = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("https://slack.com/api/" + url, req.RequestUri.ToString());
                Assert.Equal("application/json", req.Content.Headers.ContentType.MediaType);
                var jobject = JObject.Parse(await req.Content.ReadAsStringAsync());
                requestCheck(jobject);
            }, responseToSend));
            var client = new SlackWebApiClient(http);
            return requestCall(client);
        }

        public static void AssertType<T>(string file)
        {
            var deserialised = Utility.ExampleFileContent<T>(file);
            Assert.True(Utility.CompareJson(deserialised,file));
        }

        public static void AssertSubType<T,TResult>(string file)
        {
            var deserialised = Utility.ExampleFileContent<T>(file);
            Assert.IsType<TResult>(deserialised);
            Assert.True(Utility.CompareJson(deserialised, file));
        }
    }
}
