using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class GridMigrationFinished:CallbackEvent
    {
        public const string EventType = "grid_migration_finished";

        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }
    }
}
