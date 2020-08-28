using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.TextEntities;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class TextParserTests
    {
        [Fact]
        public void NoResult()
        {
            var result = TextParser.FindEntities("random text");
            Assert.Empty(result);
        }

        [Fact]
        public void Link()
        {
            var result = TextParser.FindEntities("<!Link>").First();
            var entity = Assert.IsType<Link>(result);
            Assert.Equal(0,result.TextIndex);
            Assert.Equal(7,result.TextLength);
            Assert.Equal("Link",entity.Url);
            Assert.Null(result.Label);
        }

        [Fact]
        public void UserNoLabel()
        {
            var result = TextParser.FindEntities("test <@W123456>").First();
            var entity = Assert.IsType<UserMention>(result);
            Assert.Equal(5, result.TextIndex);
            Assert.Equal(10, result.TextLength);
            Assert.Equal("W123456", entity.UserId);
            Assert.Null(result.Label);
        }

        [Fact]
        public void UserWithLabel()
        {
            var result = TextParser.FindEntities("<@W123456|Steven>").First();
            var entity = Assert.IsType<UserMention>(result);
            Assert.Equal(0, result.TextIndex);
            Assert.Equal(17, result.TextLength);
            Assert.Equal("W123456", entity.UserId);
            Assert.Equal("Steven",result.Label);
        }

    }
}
