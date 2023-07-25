using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class OAuthCredentials
{
    [JsonProperty("client_id")]
    public string ClientId { get; set; }

    [JsonProperty("client_secret")]
    public string ClientSecret { get; set; }

    [JsonProperty("verification_token")]
    public string VerificationToken { get; set; }

    [JsonProperty("signing_secret")]
    public string SigningSecret { get; set; }
}