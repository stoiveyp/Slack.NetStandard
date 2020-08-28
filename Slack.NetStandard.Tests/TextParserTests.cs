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
            var result = TextParser.FindEntities("<Link>").First();
            var entity = Assert.IsType<Link>(result);
            Assert.Equal(0,result.TextIndex);
            Assert.Equal(6,result.TextLength);
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

        [Fact]
        public void Channel()
        {
            var result = TextParser.FindEntities("test <#C123456>").First();
            var entity = Assert.IsType<ChannelMention>(result);
            Assert.Equal(5, result.TextIndex);
            Assert.Equal(10, result.TextLength);
            Assert.Equal("C123456", entity.ChannelId);
            Assert.Null(result.Label);
        }

        [Fact]
        public void SpecialMention()
        {
            var result = TextParser.FindEntities("test <!here|reallyhere>").First();
            var entity = Assert.IsType<SpecialMention>(result);
            Assert.Equal(5, result.TextIndex);
            Assert.Equal(18, result.TextLength);
            Assert.Equal("here", entity.Mention);
            Assert.Equal("reallyhere",entity.Label);
        }

        [Fact]
        public void Subteam()
        {
            var result = TextParser.FindEntities("test <!subteam^SAZ94GDB8>").First();
            var entity = Assert.IsType<Subteam>(result);
            Assert.Equal(5, result.TextIndex);
            Assert.Equal(20, result.TextLength);
            Assert.Equal("SAZ94GDB8", entity.SubteamId);
            Assert.Null(entity.Label);
        }

        [Fact]
        public void Date()
        {
            var result = TextParser.FindEntities("<!date^1392734382^{date_short}^https://example.com/|Feb 18, 2014 PST>").First();
            var entity = Assert.IsType<DateMention>(result);
            Assert.Equal(0, result.TextIndex);
            Assert.Equal(69, result.TextLength);
            Assert.Equal(1392734382, entity.Timestamp);
            Assert.Equal("{date_short}",entity.Token);
            Assert.Equal("https://example.com/",entity.OptionalLink);
            Assert.Equal("Feb 18, 2014 PST",entity.Label);
        }

        [Fact]
        public void SmallDate()
        {
            var result = TextParser.FindEntities("<!date^1392734382>").First();
            var entity = Assert.IsType<DateMention>(result);
            Assert.Equal(0, result.TextIndex);
            Assert.Equal(18, result.TextLength);
            Assert.Equal(1392734382, entity.Timestamp);
            Assert.Null(entity.Token);
            Assert.Null(entity.OptionalLink);
            Assert.Null(entity.Label);
        }

        [Fact]
        public void MultipleEntities()
        {
            var result =
                TextParser.FindEntities(
                    "<http://example.com|example link> <http://example.com> <#C0838UC2D|general> <!here> :star-struck: :smile:");
            Assert.Equal(4, result.Length);
            var firstLink = Assert.IsType<Link>(result[0]);
            var secondLink = Assert.IsType<Link>(result[1]);
            var channel = Assert.IsType<ChannelMention>(result[2]);
            var specialMention = Assert.IsType<SpecialMention>(result[3]);

        }

    }
}
