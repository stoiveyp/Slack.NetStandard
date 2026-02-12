using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.Objects.WorkObjects;
using Slack.NetStandard.WebApi.Entity;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Entity
    {
        [Fact]
        public async Task PresentDetails()
        {
            await Utility.AssertWebApi(c => c.Entity.PresentDetails(new PresentDetailsRequest
            {
                TriggerId = "1234567890123.1234567890123.abcdef01234567890abcdef012345689",
                Error = new EntityError
                {
                    Status = EntityErrorStatus.CustomPartialView,
                    CustomTitle = "Ruh roh",
                    CustomMessage = ":hand: This item is *restricted* per our [company policy](https://example.com). Don't worry though, you can request access using the button below.",
                    MessageFormat = "markdown",
                    Actions = new List<EntityPayloadAction> {
                        new EntityPayloadAction {
                            Text = "Request access",
                            ActionId = "request_access",
                            Value = "some_val",
                            ProcessingState = new ProcessingState{ Enabled = true }
                        }
                    }
                }
            }), "entity.presentDetails", jo => {
                Assert.True(Utility.CompareJson(jo, "Web_EntityPresentDetails.json"));
            });
        }
    }
}