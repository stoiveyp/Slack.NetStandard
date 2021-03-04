using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public static class Utility
    {
        private const string ExamplesPath = "Examples";
        public static bool CompareJson(object actual, string expectedFile, params string[] exclude)
        {
            var actualJObject = JObject.FromObject(actual);
            var expected = File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
            var expectedJObject = JObject.Parse(expected);

            foreach (var item in exclude)
            {
                RemoveFrom(actualJObject, item);
                RemoveFrom(expectedJObject, item);
            }

            var result = JToken.DeepEquals(expectedJObject, actualJObject);

            if (!result)
            {
                (expectedJObject,actualJObject) = OutputTrimEqual(expectedJObject, actualJObject);
                throw new InvalidOperationException("Actual object remnants: \n" + actualJObject + "\n\nExpected object remnants:\n" + expectedJObject);
            }

            return result;
        }

        private static (JObject Expected,JObject Actual) OutputTrimEqual(JObject expectedJObject, JObject actualJObject, bool output = true)
        {
            if (expectedJObject == null || actualJObject == null)
            {
                return (expectedJObject,actualJObject);
            }

            foreach (var prop in actualJObject.Properties().ToArray())
            {
                if (JToken.DeepEquals(actualJObject[prop.Name], expectedJObject[prop.Name]))
                {
                    actualJObject.Remove(prop.Name);
                    expectedJObject.Remove(prop.Name);
                    continue;
                }

                if (actualJObject[prop.Name] is JArray && expectedJObject[prop.Name] is JArray)
                {
                    var result =
                        ((JArray) actualJObject[prop.Name]).Zip(((JArray) expectedJObject[prop.Name]),
                            (a, e) => (a, e)).ToArray();
                        foreach(var (a, e) in result)
                    {
                        if(JToken.DeepEquals(a, e))
                        {
                            ((JArray) actualJObject[prop.Name]).Remove(a);
                            ((JArray) expectedJObject[prop.Name]).Remove(e);
                            continue;
                        }
                        OutputTrimEqual(actualJObject[prop.Name] as JObject, expectedJObject[prop.Name] as JObject, false);
                    }
                }

                if (actualJObject[prop.Name] is JObject && expectedJObject[prop.Name] is JObject)
                {
                    (actualJObject,expectedJObject) = OutputTrimEqual(actualJObject[prop.Name] as JObject, expectedJObject[prop.Name] as JObject, false);
                }

            }

            if (output)
            {
                Console.WriteLine(expectedJObject.ToString());
                Console.WriteLine(actualJObject.ToString());
            }

            return (expectedJObject,actualJObject);
        }

        private static void RemoveFrom(JObject exclude, string item)
        {
            if (exclude.ContainsKey(item))
            {
                exclude.Remove(item);
            }

            foreach (var prop in exclude.Properties().Where(p => p.Value is JObject).Select(p => p.Value)
                .Cast<JObject>())
            {
                RemoveFrom(prop, item);
            }

            foreach (var prop in exclude.Properties().Where(p => p.Value is JArray).Select(p => p.Value).Cast<JArray>().SelectMany(a => a.Children())
                .Where(c => c.Type == JTokenType.Object).Cast<JObject>())
            {
                RemoveFrom(prop, item);
            }
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

        public static Task<TResponse> CheckApi<TResponse>(
            Func<ISlackApiClient, Task<TResponse>> requestCall,
            string url,
            Action<NameValueCollection> requestCheck,
            TResponse responseToSend)
        {
            var http = new HttpClient(new ActionHandler(async req =>
            {
                Assert.Equal("https://slack.com/api/" + url, req.RequestUri.ToString());
                Assert.Equal("application/x-www-form-urlencoded", req.Content.Headers.ContentType.MediaType);
                var dict = HttpUtility.ParseQueryString(await req.Content.ReadAsStringAsync());
                requestCheck(dict);
            }, responseToSend));
            var client = new SlackWebApiClient(http);
            return requestCall(client);
        }

        public static T AssertType<T>(string file)
        {
            var deserialised = ExampleFileContent<T>(file);
            Assert.True(CompareJson(deserialised, file));
            return deserialised;
        }

        public static TResult AssertSubType<T, TResult>(string file, params string[] exclude) where TResult : T
        {
            var deserialised = ExampleFileContent<T>(file);
            Assert.IsType<TResult>(deserialised);
            Assert.True(CompareJson(deserialised, file, exclude));

            return (TResult)deserialised;
        }

        public static Task<TResponse> AssertWebApi<TResponse>(Func<ISlackApiClient, Task<TResponse>> func, string methodName, Action<JObject> requestAssertion,TResponse responseToSend = default) where TResponse:class,new()
        {
            return CheckApi(func, methodName, requestAssertion,responseToSend ?? new TResponse());
        }

        public static async Task<TResponse> AssertWebApi<TResponse>(Func<ISlackApiClient, Task<TResponse>> func, string methodName, string responseFile, Action<JObject> requestAssertion) where TResponse: WebApiResponseBase
        {
            var response = await CheckApi(func,
                methodName,
                requestAssertion, ExampleFileContent<TResponse>(responseFile));
            
            Assert.True(CompareJson(response,responseFile));
            return response;
        }

        public static async Task<WebApiResponse> AssertWebApi(Func<ISlackApiClient, Task<WebApiResponse>> func, string methodName, Action<JObject> requestAssertion)
        {
            var response = await CheckApi(func,
                methodName,
                requestAssertion, WebApiResponse.Success());

            Assert.True(response.OK);
            return response;
        }

        public static async Task<TResponse> AssertEncodedWebApi<TResponse>(Func<ISlackApiClient, Task<TResponse>> func, string methodName, string responseFile, Action<NameValueCollection> requestAssertion) where TResponse : WebApiResponseBase
        {
            var response = await CheckApi(func,
                methodName,
                requestAssertion, ExampleFileContent<TResponse>(responseFile));

            Assert.True(CompareJson(response, responseFile));
            return response;
        }

        public static async Task<WebApiResponse> AssertEncodedWebApi(Func<ISlackApiClient, Task<WebApiResponse>> func, string methodName, Action<NameValueCollection> requestAssertion)
        {
            var response = await CheckApi(func,
                methodName,
                requestAssertion, WebApiResponse.Success());

            Assert.True(response.OK);
            return response;
        }
    }
}
