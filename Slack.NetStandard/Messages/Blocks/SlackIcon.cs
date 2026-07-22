using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Blocks
{
    public class SlackIcon
    {
        public const string SlackIconType = "slack_icon";

        [JsonProperty("type")]
        public string Type => SlackIconType;

        [JsonProperty("icon_name")]
        public SlackIconName IconName { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlackIconName
    {
        [EnumMember(Value = "archive")] Archive,
        [EnumMember(Value = "book")] Book,
        [EnumMember(Value = "bookmark")] Bookmark,
        [EnumMember(Value = "bot")] Bot,
        [EnumMember(Value = "bug")] Bug,
        [EnumMember(Value = "calendar")] Calendar,
        [EnumMember(Value = "call")] Call,
        [EnumMember(Value = "caret-left")] CaretLeft,
        [EnumMember(Value = "caret-right")] CaretRight,
        [EnumMember(Value = "check")] Check,
        [EnumMember(Value = "clipboard")] Clipboard,
        [EnumMember(Value = "code")] Code,
        [EnumMember(Value = "comment")] Comment,
        [EnumMember(Value = "compass")] Compass,
        [EnumMember(Value = "copy")] Copy,
        [EnumMember(Value = "cube")] Cube,
        [EnumMember(Value = "download")] Download,
        [EnumMember(Value = "edit")] Edit,
        [EnumMember(Value = "email")] Email,
        [EnumMember(Value = "eye-closed")] EyeClosed,
        [EnumMember(Value = "eye-open")] EyeOpen,
        [EnumMember(Value = "file")] File,
        [EnumMember(Value = "flag")] Flag,
        [EnumMember(Value = "folder")] Folder,
        [EnumMember(Value = "gear")] Gear,
        [EnumMember(Value = "globe")] Globe,
        [EnumMember(Value = "heart")] Heart,
        [EnumMember(Value = "help")] Help,
        [EnumMember(Value = "image")] Image,
        [EnumMember(Value = "info")] Info,
        [EnumMember(Value = "key")] Key,
        [EnumMember(Value = "lightbulb")] Lightbulb,
        [EnumMember(Value = "link")] Link,
        [EnumMember(Value = "map")] Map,
        [EnumMember(Value = "mobile")] Mobile,
        [EnumMember(Value = "new-window")] NewWindow,
        [EnumMember(Value = "pin")] Pin,
        [EnumMember(Value = "plus")] Plus,
        [EnumMember(Value = "refine")] Refine,
        [EnumMember(Value = "refresh")] Refresh,
        [EnumMember(Value = "rocket")] Rocket,
        [EnumMember(Value = "save")] Save,
        [EnumMember(Value = "screen")] Screen,
        [EnumMember(Value = "share")] Share,
        [EnumMember(Value = "sparkle")] Sparkle,
        [EnumMember(Value = "star")] Star,
        [EnumMember(Value = "star-filled")] StarFilled,
        [EnumMember(Value = "tag")] Tag,
        [EnumMember(Value = "thumbs-down")] ThumbsDown,
        [EnumMember(Value = "thumbs-up")] ThumbsUp,
        [EnumMember(Value = "trash")] Trash,
        [EnumMember(Value = "upload")] Upload,
        [EnumMember(Value = "user")] User,
        [EnumMember(Value = "warning")] Warning
    }
}
