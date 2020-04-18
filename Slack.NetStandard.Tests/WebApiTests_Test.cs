﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Sdk;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Test
    {
        [Fact]
        public async Task Test()
        {
            var data = new JObject {{"error", "this is an error"}, {"random", "this is random"}};
            await Utility.AssertWebApi(c => c.Test(data), "api.test", j => Assert.True(JToken.DeepEquals(j, data)));
        }
    }
}
