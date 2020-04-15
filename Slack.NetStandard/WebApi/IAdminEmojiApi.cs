using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminEmojiApi
    {
        Task<WebApiResponse> Add(string name, string url);
        Task<WebApiResponse> AddAlias(string name, string aliasFor);
        Task<EmojiListResponse> List(string cursor = null);
        Task<EmojiListResponse> List(int limit);
        Task<EmojiListResponse> List(string cursor, int? limit);

        Task<WebApiResponse> Remove(string name);
        Task<WebApiResponse> Rename(string name, string newName);
    }
}