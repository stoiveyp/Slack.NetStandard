using System;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class VerificationTests
    {
        private const string SigningSecret = "8f742231b10e8888abcd99yyyzzz85a5";
        private const long Timestamp = 1531420618;
        private const string Body = "token=xyzz0WbapA4vBCDEFasx0q6G&team_id=T1DC2JH3J&team_domain=testteamnow&channel_id=G8PSS9T3V&channel_name=foobar&user_id=U2CERLKJA&user_name=roadrunner&command=%2Fwebhook-collect&text=&response_url=https%3A%2F%2Fhooks.slack.com%2Fcommands%2FT1DC2JH3J%2F397700885554%2F96rGlfmibIGlgcZRskXaIFfN&trigger_id=398738663015.47445629121.803a0bc887a14d10d2c447fce8b6703c";
        private const string ExpectedSig = "v0=a2114d57b48eac39b9ad189dd8316235a7b4a8d21a10bd27519666489c69b503";

        [Fact]
        public void VerifierGeneratesCorrectSig()
        {
            var sig = RequestVerifier.GenerateSignature(SigningSecret, Timestamp, Body);
            Assert.Equal(ExpectedSig, sig);
        }

        [Fact]
        public void VerifierValidatesExpectedSig()
        {
            Assert.True(RequestVerifier.Verify(ExpectedSig, SigningSecret, Timestamp, Body));
        }

        [Fact]
        public void VerifierFailsAlteredSig()
        {
            Assert.False(RequestVerifier.Verify(ExpectedSig, SigningSecret, Timestamp + 1, Body));
        }
    }
}
