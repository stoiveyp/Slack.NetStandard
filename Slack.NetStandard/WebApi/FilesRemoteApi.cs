using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;

namespace Slack.NetStandard.WebApi
{
    internal class FilesRemoteApi : IFilesRemoteApi
    {
        private readonly IWebApiClient _client;

        public FilesRemoteApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<FileResponse> Add(AddFileRemoteRequest request)
        {
            if (request.IndexableFileContents == null && request.PreviewImage == null)
            {
                return _client.MakeUrlEncodedCall<FileResponse>("files.remote.add", request);
            }

            var dict = new Dictionary<string, Stream>();
            if (request.IndexableFileContents != null)
            {
                dict.Add("indexable_file_contents", request.IndexableFileContents);
            }

            if (request.PreviewImage != null)
            {
                dict.Add("preview_image", request.PreviewImage);
            }

            return _client.MakeMultiPartCall<FileResponse>("files.remote.add", request, dict);

        }

        public Task<FileResponse> InfoByExternalId(string externalId)
        {
            return _client.MakeUrlEncodedCall<FileResponse>("files.remote.info", new Dictionary<string, string>{{"external_id",externalId}});
        }

        public Task<FileResponse> InfoByFileId(string file)
        {
            return _client.MakeUrlEncodedCall<FileResponse>("files.remote.info", new Dictionary<string, string> { { "file", file } });
        }

        public Task<FileListResponse> List(FileRemoteListRequest request)
        {
            return _client.MakeUrlEncodedCall<FileListResponse>("files.remote.list", request);
        }

        public Task<WebApiResponse> ShareByExternalId(string externalId, string[] channels)
        {
            return _client.MakeUrlEncodedCall("files.remote.share", new Dictionary<string, string> { { "external_id", externalId }, { "channels", string.Join(",", channels) } });
        }

        public Task<WebApiResponse> ShareByFile(string file, string[] channels)
        {
            return _client.MakeUrlEncodedCall("files.remote.share", new Dictionary<string, string> { { "file", file },{"channels",string.Join(",",channels)} });
        }

        public Task<WebApiResponse> RemoveExternalId(string externalId)
        {
            return _client.MakeUrlEncodedCall("files.remote.remove", new Dictionary<string, string> { { "external_id", externalId } });
        }

        public Task<WebApiResponse> RemoveFile(string file)
        {
            return _client.MakeUrlEncodedCall("files.remote.remove", new Dictionary<string, string> { { "file", file } });
        }

        public Task<FileResponse> Update(UpdateFileRemoteRequest request)
        {
            if (request.IndexableFileContents == null && request.PreviewImage == null)
            {
                return _client.MakeUrlEncodedCall<FileResponse>("files.remote.update", request);
            }

            var dict = new Dictionary<string, Stream>();
            if (request.IndexableFileContents != null)
            {
                dict.Add("indexable_file_contents", request.IndexableFileContents);
            }

            if (request.PreviewImage != null)
            {
                dict.Add("preview_image", request.PreviewImage);
            }

            return _client.MakeMultiPartCall<FileResponse>("files.remote.update", request, dict);
        }
    }
}