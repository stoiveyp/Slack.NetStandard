using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;

namespace Slack.NetStandard.WebApi
{
    public interface IFilesApi
    {
        Task<WebApiResponse> Delete(string file);
        Task<FileResponse> Info(string file);
    }
}