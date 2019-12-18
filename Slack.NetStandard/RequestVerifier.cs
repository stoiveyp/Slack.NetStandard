using System;
using System.Security.Cryptography;
using System.Text;

namespace Slack.NetStandard
{
    public class RequestVerifier
    {
        private readonly string _secret;
        private readonly TimeSpan _tolerance;

        public RequestVerifier(string signingSecret, TimeSpan? timestampTolerance = null)
        {
            _secret = signingSecret ?? throw new ArgumentNullException(nameof(signingSecret));
            _tolerance = timestampTolerance ?? TimeSpan.FromMinutes(3);
        }

        public bool Verify(string expectedSig,long timestamp, string body)
        {
            return Verify(expectedSig,_secret, timestamp, body, _tolerance);
        }

        private static bool Verify(string expectedSig, string signingSecret, long timestamp, string body, TimeSpan tolerance)
        {
            if (string.IsNullOrWhiteSpace(expectedSig))
            {
                throw new ArgumentNullException(nameof(expectedSig));
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentNullException(nameof(body));
            }

            if (!Epoch.Within(timestamp,tolerance))
            {
                return false;
            }

            return expectedSig == GenerateSignature(signingSecret, timestamp, body);
        }

        public static string GenerateSignature(string signingSecret, long timestamp, string body)
        {
            var sig = $"v0:{timestamp}:{body}";
            var hasher = new HMACSHA256(Encoding.UTF8.GetBytes(signingSecret));
            var output = hasher.ComputeHash(Encoding.UTF8.GetBytes(sig));
            var osb = new StringBuilder("v0=");
            foreach (var b in output)
            {
                osb.Append(b.ToString("x2"));
            }
            return osb.ToString();
        }
    }
}
