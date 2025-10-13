using Slack.NetStandard.WebApi.Assistant;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Assistant
    {
        [Fact]
        public async Task SearchContext()
        {
            await Utility.AssertWebApi(
                c => c.Assistant.SearchContext(new SearchContextRequest
                {
                    Query = "What is project gizmo?",
                    ActionToken = "actionToken",
                    ChannelTypes = new List<string> { "private_channel" },
                    ContentTypes = new List<string> { "messages" },
                    ContextChannelId = "X123",
                    Cursor = "C123",
                    Limit = 555,
                    IncludeBots = true
                }),
                "assistant.search.context", "Web_AssistantSearchContext.json", jo =>
                {
                    Assert.Equal("What is project gizmo?", jo.Value<string>("query"));
                    Assert.Equal("actionToken", jo.Value<string>("action_token"));
                    jo.CompareJArray("channel_types", "private_channel");
                    jo.CompareJArray("content_types", "messages");
                    Assert.Equal("X123", jo.Value<string>("context_channel_id"));
                    Assert.Equal("C123", jo.Value<string>("cursor"));
                    Assert.Equal(555, jo.Value<int>("limit"));
                    Assert.True(jo.Value<bool>("include_bots"));
                });
        }

        [Fact]
        public async Task SetSuggestedPrompts()
        {
            await Utility.AssertWebApi(
                c => c.Assistant.ForThread("D2345SFDG", "1724264405.531769").SetSuggestedPrompts(
                    "Welcome. What can I do for you?",
                    new Prompt { 
                        Title = "Generate ideas", 
                        Message = "Pretend you are a marketing associate and you need new ideas for an enterprise productivity feature. Generate 10 ideas for a new feature launch."
                    },
                    new Prompt { 
                        Title = "Explain what SLACK stands for", 
                        Message = "What does SLACK stand for?"
                    },
                    new Prompt { 
                        Title = "Describe how AI works", 
                        Message = "How does artificial intelligence work?"
                    }
                ),
                "assistant.threads.setSuggestedPrompts", jo =>
                {
                    Assert.True(Utility.CompareJson(jo, "Web_AssistantSetSuggestedPrompts.json"));
                });
        }

        [Fact]
        public async Task SetTitle()
        {
            await Utility.AssertWebApi(
                c => c.Assistant.ForThread("C123", "123.45").SetTitle("testTitle"),
                "assistant.threads.setTitle", jo =>
                {
                    Assert.Equal("C123", jo.Value<string>("channel_id"));
                    Assert.Equal("123.45", jo.Value<string>("thread_ts"));
                    Assert.Equal("testTitle", jo.Value<string>("title"));
                });
        }

        [Fact]
        public async Task SetStatus()
        {
            await Utility.AssertWebApi(
                c => c.Assistant.ForThread("C123", "123.45").SetStatus("testStatus", "Load1", "Load2"),
                "assistant.threads.setStatus", jo =>
                {
                    Assert.Equal("C123", jo.Value<string>("channel_id"));
                    Assert.Equal("123.45", jo.Value<string>("thread_ts"));
                    Assert.Equal("testStatus", jo.Value<string>("status"));
                    jo.CompareJArray("loading_messages", "Load1", "Load2");
                });
        }
    }
}
