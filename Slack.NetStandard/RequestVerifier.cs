using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Slack.NetStandard
{
    public class RequestVerifier
    {
        private string _secret;
        public RequestVerifier(string signingSecret)
        {
            _secret = signingSecret;
        }

        public bool Verify(string expectedSig,long timestamp, string body)
        {
            return Verify(expectedSig,_secret, timestamp, body);
        }

        public static bool Verify(string expectedSig, string signingSecret, long timestamp, string body)
        {
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
