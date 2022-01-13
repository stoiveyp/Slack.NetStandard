using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Slack.NetStandard.Auth
{
    public class OAuthV2Builder
    {
        public OAuthV2Builder(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException("Client id cannot be blank", nameof(clientId));
            }

            ClientId = clientId;
        }

        public string ClientId { get; }
        public string BotScope { get; set; }
        public string UserScope { get; set; }
        public string State { get; set; }
        public string RedirectUri { get; set; }


        public Uri BuildUri()
        {
            var sb = new StringBuilder("?client_id=");
            sb.Append(System.Net.WebUtility.UrlEncode(ClientId));


            foreach (var set in new (string key, string value)[]
            {
                ("scope", BotScope),
                ("user_scope", UserScope),
                ("redirect_uri", RedirectUri),
                ("state", State)
            })
            {
                if (string.IsNullOrWhiteSpace(set.key)) continue;

                sb.Append("&");
                sb.Append(set.key);
                sb.Append("=");
                sb.Append(System.Net.WebUtility.UrlEncode(set.value));
            }

            return new UriBuilder("https", "slack.com", 443, "/oauth/v2/authorize")
            {
                Query = sb.ToString()
                    
            }.Uri;
        }

        public static string ParseRedirect(Uri uri, string state)
        {
            var nvc = HttpUtility.ParseQueryString(uri.Query);
            if(!string.IsNullOrWhiteSpace(state) && (nvc.Keys.Cast<string>().All(k => k != "state") || nvc["state"] != state))
            {
                throw new InvalidOperationException("state mismatch");
            }

            if (nvc.Keys.Cast<string>().Any(k => k == "error"))
            {
                throw new InvalidOperationException($"error occurred: {nvc["error"]}");
            }

            return nvc["code"];
        }

        public static Task<AccessTokenInformation> Exchange(string code, string clientId, string clientSecret, string redirectUri = null)
        {
            return Exchange(new HttpClient(), code, clientId, clientSecret, redirectUri);
        }

        public static Task<AccessTokenInformation> ExchangeRefreshToken(HttpClient client, string refreshToken, string clientId, string clientSecret,
            string redirectUri = null)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{HttpUtility.UrlEncode(clientId)}:{HttpUtility.UrlEncode(clientSecret)}")));
            return ExchangeRefreshToken(client, refreshToken, redirectUri);
        }

        public static async Task<AccessTokenInformation> ExchangeRefreshToken(HttpClient client, string refreshToken,
            string redirectUri = null)
        {
            var dict = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token"},
                {"refresh_token", refreshToken}
            };
            if (!string.IsNullOrWhiteSpace(redirectUri))
            {
                dict.Add("redirect_uri", redirectUri);
            }

            var response = await client.PostAsync("https://slack.com/api/oauth.v2.access", new FormUrlEncodedContent(dict)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AccessTokenInformation>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return null;
        }

        public static Task<AccessTokenInformation> Exchange(HttpClient client, string code, string clientId, string clientSecret,
            string redirectUri = null)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{HttpUtility.UrlEncode(clientId)}:{HttpUtility.UrlEncode(clientSecret)}")));
            return Exchange(client, code, redirectUri);
        }

        public static async Task<AccessTokenInformation> Exchange(HttpClient client, string code, string redirectUri = null)
        {
            var dict = new Dictionary<string, string>
            {
                {"code", code}
            };
            if (!string.IsNullOrWhiteSpace(redirectUri))
            {
                dict.Add("redirect_uri", redirectUri);
            }

            var response = await client.PostAsync("https://slack.com/api/oauth.v2.access", new FormUrlEncodedContent(dict)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AccessTokenInformation>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return null;
        }
    }
}
