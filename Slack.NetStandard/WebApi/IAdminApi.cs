﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminApi
    {
        IAdminAppsApi Apps { get; }
    }
}
