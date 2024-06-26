using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi
{
    internal static class CanvasOperationType
    {
        public const string Delete = "delete";
        public const string Replace = "replace";
        public const string InsertAtEnd = "insert_at_end";
        public const string InsertAtStart = "insert_at_start";
        public const string InsertAfter = "insert_after";
        public const string InsertBefore = "insert_before";
    }
}
