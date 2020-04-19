using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;

namespace Slack.NetStandard.WebApi
{
    internal class FilesApi : IFilesApi
    {
        private readonly IWebApiClient _client;

        public FilesApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Delete(string file)
        {
            return _client.MakeUrlEncodedCall("files.delete", new Dictionary<string, string> {{"file", file}});
        }

        public Task<FileResponse> Info(string file)
        {
            return _client.MakeUrlEncodedCall<FileResponse>("files.info", new Dictionary<string, string> { { "file", file } });
        }
    }
}