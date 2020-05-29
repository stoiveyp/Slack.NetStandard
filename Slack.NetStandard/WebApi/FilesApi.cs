using System.Collections.Generic;
using System.IO;
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
            Remote = new FilesRemoteApi(client);
        }

        public Task<WebApiResponse> Delete(string file)
        {
            return _client.MakeUrlEncodedCall("files.delete", new Dictionary<string, string> {{"file", file}});
        }

        public Task<FileResponse> Info(string file)
        {
            return _client.MakeUrlEncodedCall<FileResponse>("files.info", new Dictionary<string, string> { { "file", file } });
        }

        public Task<FileListResponse> List(FileListRequest request)
        {
            return _client.MakeUrlEncodedCall<FileListResponse>("files.list",request);
        }

        public Task<FileResponse> RevokePublicUrl(string file)
        {
            return _client.MakeUrlEncodedCall<FileResponse>("files.revokePublicUrl", new Dictionary<string, string> { { "file", file } });
        }

        public Task<FileResponse> SharedPublicUrl(string file)
        {
            return _client.MakeUrlEncodedCall<FileResponse>("files.sharedPublicUrl", new Dictionary<string, string> { { "file", file } });
        }

        public Task<FileResponse> Upload(FileUploadRequest request)
        {
            if (request.File != null)
            {
                return _client.MakeMultiPartCall<FileResponse>("files.upload", request, new Dictionary<string, MultipartFile>{{"file",request.File}});
            }

            return _client.MakeUrlEncodedCall<FileResponse>("files.upload", request);
        }

        public IFilesRemoteApi Remote { get; }
    }
}