using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowsApi
    {
        IWorkflowsTriggersApi Triggers { get; }
        IWorkflowsFeaturedApi Featured { get; }
    }
}
