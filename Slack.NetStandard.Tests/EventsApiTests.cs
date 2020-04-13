﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.EventsApi.CallbackEvents;
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
            var et = Utility.ExampleFileContent<CallbackEvent>("Events_Unknown.json");
            Assert.Equal("name_of_event",et.Type);
            Assert.Single(et.OtherFields);
            Assert.True(et.OtherFields.ContainsKey("user"));
            Assert.Equal(1234567890,et.EventTimestamp.EpochSeconds);
            Assert.Equal("123456", et.EventTimestamp.Identifier);
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
            Utility.AssertSubType<CallbackEvent,AppHomeOpened>("Events_AppHomeOpened.json");
        }

        [Fact]
        public void AppMention()
        {
            Utility.AssertSubType<CallbackEvent,AppMention>("Events_AppMention.json");
        }

        [Fact]
        public void AppRateLimited()
        {
            Utility.AssertSubType<Event,AppRateLimited>("Events_AppRateLimited.json");
        }

        [Fact]
        public void AppRequested()
        {
            Utility.AssertSubType<CallbackEvent, AppRequested>("Events_AppRequested.json");
        }

        [Fact]
        public void AppUninstalled()
        {
            Utility.AssertSubType<CallbackEvent, AppUninstalled>("Events_AppUninstalled.json");
        }

        [Fact]
        public void CallRejected()
        {
            Utility.AssertSubType<CallbackEvent, CallRejected>("Events_CallRejected.json");
        }

        [Fact]
        public void ChannelArchive()
        {
            Utility.AssertSubType<CallbackEvent, ChannelArchive>("Events_ChannelArchive.json");
        }

        [Fact]
        public void ChannelCreated()
        {
            Utility.AssertSubType<CallbackEvent, ChannelCreated>("Events_ChannelCreated.json");
        }

        [Fact]
        public void ChannelDeleted()
        {
            Utility.AssertSubType<CallbackEvent, ChannelDeleted>("Events_ChannelDeleted.json");
        }

        [Fact]
        public void ChannelHistoryChanged()
        {
            Utility.AssertSubType<CallbackEvent, ChannelHistoryChanged>("Events_ChannelHistoryChanged.json");
        }

        [Fact]
        public void ChannelLeft()
        {
            Utility.AssertSubType<CallbackEvent, ChannelLeft>("Events_ChannelLeft.json");
        }

        [Fact]
        public void ChannelRename()
        {
            Utility.AssertSubType<CallbackEvent, ChannelRename>("Events_ChannelRename.json");
        }

        [Fact]
        public void ChannelShared()
        {
            Utility.AssertSubType<CallbackEvent, ChannelShared>("Events_ChannelShared.json");
        }

        [Fact]
        public void ChannelUnarchive()
        {
            Utility.AssertSubType<CallbackEvent, ChannelUnarchive>("Events_ChannelUnarchive.json");
        }

        [Fact]
        public void ChannelUnshared()
        {
            Utility.AssertSubType<CallbackEvent, ChannelUnshared>("Events_ChannelUnshared.json");
        }

        [Fact]
        public void DndUpdated()
        {
            Utility.AssertSubType<CallbackEvent, DndUpdated>("Events_DndUpdated.json");
        }

        [Fact]
        public void DndUpdatedUser()
        {
            Utility.AssertSubType<CallbackEvent, DndUpdatedUser>("Events_DndUpdatedUser.json");
        }

        [Fact]
        public void EmailDomainChanged()
        {
            Utility.AssertSubType<CallbackEvent, EmailDomainChanged>("Events_EmailDomainChanged.json");
        }

        [Fact]
        public void EmojiChanged()
        {
            Utility.AssertSubType<CallbackEvent, EmojiChanged>("Events_EmojiChangedAdd.json");
            Utility.AssertSubType<CallbackEvent, EmojiChanged>("Events_EmojiChangedRemove.json");
        }
    }
}
