using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;

namespace Slack.NetStandard.WebApi
{
    public interface IFilesRemoteApi
    {
        Task<FileResponse> Add(AddFileRemoteRequest request);
        Task<FileResponse> InfoByExternalId(string externalId);
        Task<FileResponse> InfoByFileId(string fileId);

        Task<FileListResponse> List(FileRemoteListRequest request);

        Task<WebApiResponse> ShareByExternalId(string externalId, params string[] channels);
        Task<WebApiResponse> ShareByFile(string file, params string[] channels);

        Task<WebApiResponse> RemoveExternalId(string externalId);

        Task<WebApiResponse> RemoveFile(string file);

        Task<FileResponse> Update(UpdateFileRemoteRequest request);
    }
}