using System;
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
        public void EventsBasics()
        {
            Utility.AssertSubType<Event, EventCallback>("Events_Basics.json");
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
        public void ChannelIDChanged()
        {
            Utility.AssertSubType<CallbackEvent, ChannelIdChanged>("Events_ChannelIDChanged.json");
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


        [Fact]
        public void FileChange()
        {
            Utility.AssertSubType<CallbackEvent, FileChange>("Events_FileChange.json");
        }


        [Fact]
        public void FileCreated()
        {
            Utility.AssertSubType<CallbackEvent, FileCreated>("Events_FileCreated.json");
        }

        [Fact]
        public void FileDeleted()
        {
            Utility.AssertSubType<CallbackEvent, FileDeleted>("Events_FileDeleted.json");
        }

        [Fact]
        public void FilePublic()
        {
            Utility.AssertSubType<CallbackEvent, FilePublic>("Events_FilePublic.json");
        }

        [Fact]
        public void FileShared()
        {
            Utility.AssertSubType<CallbackEvent, FileShared>("Events_FileShared.json");
        }

        [Fact]
        public void FileUnshared()
        {
            Utility.AssertSubType<CallbackEvent, FileUnshared>("Events_FileUnshared.json");
        }

        [Fact]
        public void GridMigrationFinished()
        {
            Utility.AssertSubType<CallbackEvent, GridMigrationFinished>("Events_GridMigrationFinished.json");
        }

        [Fact]
        public void GridMigrationStarted()
        {
            Utility.AssertSubType<CallbackEvent, GridMigrationStarted>("Events_GridMigrationStarted.json");
        }

        [Fact]
        public void GroupArchive()
        {
            Utility.AssertSubType<CallbackEvent, GroupArchive>("Events_GroupArchive.json");
        }

        [Fact]
        public void GroupClose()
        {
            Utility.AssertSubType<CallbackEvent, GroupClose>("Events_GroupClose.json");
        }

        [Fact]
        public void GroupDeleted()
        {
            Utility.AssertSubType<CallbackEvent, GroupDeleted>("Events_GroupDeleted.json");
        }

        [Fact]
        public void GroupHistoryChanged()
        {
            Utility.AssertSubType<CallbackEvent, GroupHistoryChanged>("Events_GroupHistoryChanged.json");
        }

        [Fact]
        public void GroupLeft()
        {
            Utility.AssertSubType<CallbackEvent, GroupLeft>("Events_GroupLeft.json");
        }

        [Fact]
        public void GroupOpen()
        {
            Utility.AssertSubType<CallbackEvent, GroupOpen>("Events_GroupOpen.json");
        }

        [Fact]
        public void GroupRename()
        {
            Utility.AssertSubType<CallbackEvent, GroupRename>("Events_GroupRename.json");
        }

        [Fact]
        public void GroupUnarchive()
        {
            Utility.AssertSubType<CallbackEvent, GroupUnarchive>("Events_GroupUnarchive.json");
        }

        [Fact]
        public void ImClose()
        {
            Utility.AssertSubType<CallbackEvent, ImClose>("Events_ImClose.json");
        }

        [Fact]
        public void ImOpen()
        {
            Utility.AssertSubType<CallbackEvent, ImOpen>("Events_ImOpen.json");
        }

        [Fact]
        public void ImCreated()
        {
            Utility.AssertSubType<CallbackEvent, ImCreated>("Events_ImCreated.json");
        }

        [Fact]
        public void ImHistoryChanged()
        {
            Utility.AssertSubType<CallbackEvent, ImHistoryChanged>("Events_ImHistoryChanged.json");
        }

        [Fact]
        public void InviteRequested()
        {
            Utility.AssertSubType<CallbackEvent, InviteRequested>("Events_InviteRequested.json");
        }

        [Fact]
        public void LinkShared()
        {
            Utility.AssertSubType<CallbackEvent, LinkShared>("Events_LinkShared.json");
        }

        [Fact]
        public void MemberJoinedChannel()
        {
            Utility.AssertSubType<CallbackEvent, MemberJoinedChannel>("Events_MemberJoinedChannel.json");
        }

        [Fact]
        public void MemberLeftChannel()
        {
            Utility.AssertSubType<CallbackEvent, MemberLeftChannel>("Events_MemberLeftChannel.json");
        }

        [Fact]
        public void Message()
        {
            Utility.AssertSubType<ICallbackEvent, MessageCallbackEvent>("Events_Message.json","channel");
            Utility.AssertSubType<ICallbackEvent, BotMessage>("Events_Message_Bot.json", "channel");
            Utility.AssertSubType<ICallbackEvent, EkmAccessDenied>("Events_Message_EkmAccessDenied.json", "channel");
            Utility.AssertSubType<ICallbackEvent, MeMessage>("Events_Message_Me.json", "channel");
            Utility.AssertSubType<ICallbackEvent, MessageChanged>("Events_Message_MessageChanged.json", "channel");
            Utility.AssertSubType<ICallbackEvent, MessageDeleted>("Events_Message_MessageDeleted.json", "channel");
            Utility.AssertSubType<ICallbackEvent, MessageReplied>("Events_Message_MessageReplied.json", "channel");
            Utility.AssertSubType<ICallbackEvent, ThreadBroadcast>("Events_Message_ThreadBroadcast.json", "channel");
        }

        [Fact]
        public void PinAdded()
        {
            Utility.AssertSubType<CallbackEvent, PinAdded>("Events_PinAdded.json");
        }

        [Fact]
        public void PinRemoved()
        {
            Utility.AssertSubType<CallbackEvent, PinRemoved>("Events_PinRemoved.json");
        }

        [Fact]
        public void ReactionAdded()
        {
            Utility.AssertSubType<CallbackEvent, ReactionAdded>("Events_ReactionAdded.json");
        }

        [Fact]
        public void ReactionRemoved()
        {
            Utility.AssertSubType<CallbackEvent, ReactionRemoved>("Events_ReactionRemoved.json");
        }

        [Fact]
        public void StarAdded()
        {
            Utility.AssertSubType<CallbackEvent, StarAdded>("Events_StarAdded.json");
        }

        [Fact]
        public void StarRemoved()
        {
            Utility.AssertSubType<CallbackEvent, StarRemoved>("Events_StarRemoved.json");
        }

        [Fact]
        public void SubteamCreated()
        {
            Utility.AssertSubType<CallbackEvent, SubteamCreated>("Events_SubteamCreated.json");
        }
        
        [Fact]
        public void SubteamMembersChanged()
        {
            Utility.AssertSubType<CallbackEvent, SubteamMembersChanged>("Events_SubteamMembersChanged.json");
        }

        [Fact]
        public void SubteamSelfAdded()
        {
            Utility.AssertSubType<CallbackEvent, SubteamSelfAdded>("Events_SubteamSelfAdded.json");
        }

        [Fact]
        public void SubteamSelfRemoved()
        {
            Utility.AssertSubType<CallbackEvent, SubteamSelfRemoved>("Events_SubteamSelfRemoved.json");
        }

        [Fact]
        public void SubteamUpdated()
        {
            Utility.AssertSubType<CallbackEvent, SubteamUpdated>("Events_SubteamUpdated.json");
        }

        [Fact]
        public void TeamDomainChange()
        {
            Utility.AssertSubType<CallbackEvent, TeamDomainChange>("Events_TeamDomainChange.json");
        }

        [Fact]
        public void TeamJoin()
        {
            Utility.AssertSubType<CallbackEvent, TeamJoin>("Events_TeamJoin.json");
        }

        [Fact]
        public void TeamRename()
        {
            Utility.AssertSubType<CallbackEvent, TeamRename>("Events_TeamRename.json");
        }

        [Fact]
        public void TokensRevoked()
        {
            Utility.AssertSubType<CallbackEvent, TokensRevoked>("Events_TokensRevoked.json");
        }

        [Fact]
        public void UserChange()
        {
            Utility.AssertSubType<CallbackEvent, UserChange>("Events_UserChange.json");
        }

        [Fact]
        public void WorkflowStepExecute()
        {
            Utility.AssertSubType<CallbackEvent, WorkflowStepExecute>("Events_Workflow.json");
        }

        [Fact]
        public void WorkflowPublished()
        {
            Utility.AssertSubType<CallbackEvent, WorkflowPublished>("Events_WorkflowPublished.json");
        }

        [Fact]
        public void WorkflowUnpublished()
        {
            Utility.AssertSubType<CallbackEvent, WorkflowUnpublished>("Events_WorkflowUnpublished.json");
        }

        [Fact]
        public void WorkflowDeleted()
        {
            Utility.AssertSubType<CallbackEvent, WorkflowDeleted>("Events_WorkflowDeleted.json");
        }

        [Fact]
        public void WorkflowStepDeleted()
        {
            Utility.AssertSubType<CallbackEvent, WorkflowStepDeleted>("Events_WorkflowStepDeleted.json");
        }

        [Fact]
        public void SharedChannelInviteReceived()
        {
            Utility.AssertSubType<CallbackEvent, SharedChannelInviteReceived>("Events_SharedChannelInviteReceived.json");
        }
    }
}
