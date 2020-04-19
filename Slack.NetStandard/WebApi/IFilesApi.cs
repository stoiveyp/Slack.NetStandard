using System.IO;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;

namespace Slack.NetStandard.WebApi
{
    public interface IFilesApi
    {
        Task<WebApiResponse> Delete(string file);
        Task<FileResponse> Info(string file);

        Task<FileListResponse> List(FileListRequest request);

        Task<FileResponse> RevokePublicUrl(string file);

        Task<FileResponse> SharedPublicUrl(string file);

        Task<FileResponse> Upload(FileUploadRequest request);
    }
}