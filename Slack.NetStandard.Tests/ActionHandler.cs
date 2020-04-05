using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.Tests
{
    public class ActionHandler : HttpMessageHandler
    {
        public Func<HttpRequestMessage, Task<HttpResponseMessage>> Run { get; }

        public ActionHandler(Action<HttpRequestMessage> run, object response, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = req =>
            {
                run(req);
                return Task.FromResult(new HttpResponseMessage(code) { Content = new StringContent(JObject.FromObject(response).ToString()) });
            };
        }

        public ActionHandler(Action<HttpRequestMessage> run, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = req =>
            {
                run(req);
                return Task.FromResult(new HttpResponseMessage(code));
            };
        }

        public ActionHandler(Func<HttpRequestMessage, Task> run, object response, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = async req =>
            {
                await run(req);
                return new HttpResponseMessage(code) { Content = new StringContent(response is string ? response.ToString() : JObject.FromObject(response).ToString()) };
            };
        }

        public ActionHandler(Func<HttpRequestMessage, Task> run, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = async req =>
            {
                await run(req);
                return new HttpResponseMessage(code);
            };
        }

        public ActionHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> run)
        {
            Run = run;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Run(request);
        }
    }
}
