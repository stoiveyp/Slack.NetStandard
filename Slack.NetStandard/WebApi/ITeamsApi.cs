﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    public interface ITeamsApi
    {
        Task<TeamAccessLogResponse> AccessLogs(long before);
        Task<TeamAccessLogResponse> AccessLogs(int count, int page);
        Task<TeamAccessLogResponse> AccessLogs(long? before, int? count, int? page);
    }
}
