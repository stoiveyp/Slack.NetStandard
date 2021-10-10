using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Apps;
using Slack.NetStandard.WebApi.Apps.Manifest;

namespace Slack.NetStandard.WebApi;

internal class AppsManifestApi : IAppsManifestApi
{
    private readonly IWebApiClient _client;

    private static readonly JsonSerializer Serializer = JsonSerializer.CreateDefault();

    public AppsManifestApi(IWebApiClient client)
    {
        _client = client;
    }

    private static string SerializeManifest(ManifestDefinition definition)
    {
        StringBuilder sb = new StringBuilder(256);
        StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture);
        using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
        {
            jsonWriter.Formatting = Serializer.Formatting;

            Serializer.Serialize(jsonWriter, definition);
        }

        return sw.ToString();
    }

    public Task<CreateManifestResponse> Create(ManifestDefinition manifestDefinition)
    {
        return Create(SerializeManifest(manifestDefinition));
    }

    public Task<CreateManifestResponse> Create(string manifest)
    {
        var jobject = new JObject { { "manifest", manifest } };
        return _client.MakeJsonCall<JObject,CreateManifestResponse>("apps.manifest.create", jobject);
    }

    public Task<UpdateManifestResponse> Update(string appId, ManifestDefinition manifestDefinition)
    {
        return Update(appId, SerializeManifest(manifestDefinition));
    }

    public Task<UpdateManifestResponse> Update(string appId, string manifest)
    {
        var jobject = new JObject { {"app_id",appId},{ "manifest", manifest } };
        return _client.MakeJsonCall<JObject, UpdateManifestResponse>("apps.manifest.update", jobject);
    }

    public Task<WebApiResponse> Delete(string appId)
    {
        var jobject = new JObject { { "app_id", appId } };
        return _client.MakeJsonCall("apps.manifest.delete", jobject);
    }

    public Task<ExportManifestResponse> Export(string appId)
    {
        var jobject = new JObject { { "app_id", appId } };
        return _client.MakeJsonCall<JObject,ExportManifestResponse>("apps.manifest.export", jobject);
    }

    public Task<WebApiResponse> Validate(ManifestDefinition manifestDefinition)
    {
        return Validate(SerializeManifest(manifestDefinition));
    }

    public Task<WebApiResponse> Validate(string manifest)
    {
        var jobject = new JObject { { "manifest", manifest } };
        return _client.MakeJsonCall("apps.manifest.validate", jobject);
    }
}