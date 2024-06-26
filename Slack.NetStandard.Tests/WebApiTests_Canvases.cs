using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Canvases;
using Slack.NetStandard.WebApi.Canvases.Operations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Canvases
    {
        public const string MARKDOWN_TEXT = "> channel canvas!";

        [Fact]
        public async Task Canvases_Create()
        {
            await Utility.AssertWebApi(
                c => c.Canvases.Create("test title", new MarkdownContent(MARKDOWN_TEXT)),
                "canvases.create", jo =>
                {
                    Assert.Equal("test title", jo.Value<string>("title"));
                    var content = jo.Value<JObject>("document_content");
                    Assert.Equal("markdown", content.Value<string>("type"));
                    Assert.Equal(MARKDOWN_TEXT, content.Value<string>("markdown"));
                });
        }

        [Fact]
        public async Task Canvases_Delete()
        {
            await Utility.AssertSingleEncodedWebApi(
                c => c.Canvases.Delete("C132"),
                "canvases.delete", "canvas_id", "C132");
        }

        [Fact]
        public async Task Canvases_Set_Access()
        {
            await Utility.AssertWebApi(
                c => c.Canvases.SetAccess(new CanvasSetAccessRequest("C132", CanvasAccessLevel.Write)
                {
                    ChannelIds = new List<string> { "Cxxx" },
                    UserIds = new List<string> { "Uxxx" },
                }),
                "canvases.access.set", jo =>
                {
                    Assert.Equal("C132", jo.Value<string>("canvas_id"));
                    Assert.Equal("write", jo.Value<string>("access_level"));
                    jo.CompareJArray("channel_ids", "Cxxx");
                    jo.CompareJArray("user_ids", "Uxxx");
                });
        }

        [Fact]
        public async Task Canvases_Delete_Access()
        {
            await Utility.AssertWebApi(
                c => c.Canvases.DeleteAccess(new CanvasDeleteAccessRequest("C132")
                {
                    ChannelIds = new List<string> { "Cxxx" },
                    UserIds = new List<string> { "Uxxx" },
                }),
                "canvases.access.delete", jo =>
                {
                    Assert.Equal("C132", jo.Value<string>("canvas_id"));
                    jo.CompareJArray("channel_ids", "Cxxx");
                    jo.CompareJArray("user_ids", "Uxxx");
                });
        }

        [Fact]
        public async Task Canvases_Section_Lookup()
        {
            await Utility.AssertWebApi(
                c => c.Canvases.SectionLookup("C132", new LookupCriteria
                {
                    SectionTypes = new[] { "H2" }.ToList(),
                    ContainsText = "Grocery List"
                }),
                "canvases.sections.lookup", jo =>
                {
                    Assert.Equal("C132", jo.Value<string>("canvas_id"));
                    var crit = jo.Value<JObject>("criteria");
                    crit.CompareJArray("section_types", "H2");
                    Assert.Equal("Grocery List", crit.Value<string>("contains_text"));
                });
        }

        [Fact]
        public async Task Canvases_Edit()
        {
            await Utility.AssertWebApi(
                c => c.Canvases.Edit("F0166DCSTS7", new InsertAfter { 
                    SectionId = "temp:C:VXX8e648e6984e441c6aa8c61173",
                    DocumentContent = new MarkdownContent("- [ ] asparagus\n- [ ] coffee\n")
                }),
                "canvases.edit",jo => {
                    Assert.True(Utility.CompareJson(jo, "Web_CanvasesEdit.json"));
                });
        }
    }
}
