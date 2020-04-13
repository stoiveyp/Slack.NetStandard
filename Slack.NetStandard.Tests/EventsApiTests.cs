using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.EventsApi;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class EventsApiTests
    {
        [Fact]
        public void UrlVerification()
        {
            Utility.AssertSubType<Event,UrlVerification>("Events_UrlVerification.json");
        }

        [Fact]
        public void UnknownEvent()
        {
            var et = Utility.ExampleFileContent<EventType>("Events_Unknown.json");
            Assert.Equal("name_of_event",et.Type);
            Assert.Single(et.OtherFields);
            Assert.True(et.OtherFields.ContainsKey("user"));
            Assert.Equal(1234567890,et.Timestamp.EpochSeconds);
            Assert.Equal(123456, et.Timestamp.Identifier);
        }

        [Fact]
        public void SubclassOptimized()
        {
            var et = Utility.ExampleFileContent<AppHomeOpened>("Events_Unknown.json");
            Assert.IsType<AppHomeOpened>(et);
        }

        [Fact]
        public void CheckConverterShortcuts()
        {
            var test = "{\"event\":{}}";
            var et = JsonConvert.DeserializeObject<EventCallback<AppHomeOpened>>(test);
            Assert.IsType<EventCallback<AppHomeOpened>>(et);
        }

        [Fact]
        public void AppHomeOpened()
        {
            Utility.AssertSubType<EventType,AppHomeOpened>("Events_AppHomeOpened.json");
        }

        [Fact]
        public void AppMention()
        {
            Utility.AssertSubType<EventType,AppMention>("Events_AppMention.json");
        }
    }
}
