using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;

namespace Slack.NetStandard.WebApi
{
    public interface IFilesRemoteApi
    {
        Task<FileResponse> Add(AddFileRemoteRequest request);
        Task<FileResponse> InfoByExternalId(string externalId);
        Task<FileResponse> InfoByFileId(string fileId);
    }
}