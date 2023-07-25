using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Files;
using Xunit;

namespace Slack.NetStandard.Tests
{
    public class WebApiTests_Files
    {
        [Fact]
        public async Task Files_Delete()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Delete("F1234567890"), "files.delete",
                nvc => Assert.Equal("F1234567890", nvc["file"]));
        }

        [Fact]
        public async Task Files_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Info("F1234567890"), "files.info", "Web_FilesInfo.json",
                nvc => Assert.Equal("F1234567890", nvc["file"]));
        }

        [Fact]
        public async Task Files_List()
        {
            var request = new FileListRequest
            {
                Cursor = "BBB",
                ShowFilesHidenByLimit = true,
                User = "W123"
            };
            await Utility.AssertEncodedWebApi(c => c.Files.List(request), "files.list", "Web_FilesList.json", nvc =>
            {
                Assert.Equal("BBB", nvc["cursor"]);
                Assert.Equal("W123", nvc["user"]);
                Assert.Equal("true", nvc["show_files_hidden_by_limit"]);

            });
        }

        [Fact]
        public async Task Files_RevokePublicUrl()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.RevokePublicUrl("F1234567890"), "files.revokePublicURL",
                "Web_FilesInfo.json", nvc => Assert.Equal("F1234567890", nvc["file"]));
        }

        [Fact]
        public async Task Files_SharedPublicUrl()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.SharedPublicUrl("F1234567890"), "files.sharedPublicURL",
                "Web_FilesInfo.json", nvc => Assert.Equal("F1234567890", nvc["file"]));
        }

        [Fact]
        public async Task Files_Upload()
        {
            var request = new FileUploadRequest
            {
                Channels = "C1234",
                Title = "hello",
                Content = "test content",
                Filetype = "txt"

            };
            await Utility.AssertEncodedWebApi(c => c.Files.Upload(request), "files.upload", "Web_FilesInfo.json", nvc =>
            {
                Assert.Equal("C1234", nvc["channels"]);
                Assert.Equal("hello", nvc["title"]);
                Assert.Equal("test content", nvc["content"]);
                Assert.Equal("txt", nvc["filetype"]);
            });
        }


        [Fact]
        public async Task FilesRemote_Add()
        {
            var request = new AddFileRemoteRequest
            {
                ExternalId = "1234",
                Title = "hello",
                Filetype = "txt"

            };
            await Utility.AssertEncodedWebApi(c => c.Files.Remote.Add(request), "files.remote.add",
                "Web_FilesInfo.json", nvc =>
                {
                    Assert.Equal("1234", nvc["external_id"]);
                    Assert.Equal("hello", nvc["title"]);
                    Assert.Equal("txt", nvc["filetype"]);
                });
        }

        [Fact]
        public async Task FilesRemote_Info()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Remote.InfoByExternalId("ABCD"), "files.remote.info",
                "Web_FilesInfo.json", nvc => { Assert.Equal("ABCD", nvc["external_id"]); });

            await Utility.AssertEncodedWebApi(c => c.Files.Remote.InfoByFileId("F1234567890"), "files.remote.info",
                "Web_FilesInfo.json", nvc => { Assert.Equal("F1234567890", nvc["file"]); });
        }

        [Fact]
        public async Task FilesRemote_Update()
        {
            var request = new UpdateFileRemoteRequest
            {
                ExternalId = "1234",
                Title = "hello",
                Filetype = "txt",
                File = "ABCD"

            };
            await Utility.AssertEncodedWebApi(c => c.Files.Remote.Update(request), "files.remote.update",
                "Web_FilesInfo.json", nvc =>
                {
                    Assert.Equal("1234", nvc["external_id"]);
                    Assert.Equal("hello", nvc["title"]);
                    Assert.Equal("txt", nvc["filetype"]);
                    Assert.Equal("ABCD", nvc["file"]);
                });
        }

        [Fact]
        public async Task FilesRemote_Remove()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Remote.RemoveExternalId("ABCD"), "files.remote.remove",
                "Web_FilesInfo.json", nvc => { Assert.Equal("ABCD", nvc["external_id"]); });

            await Utility.AssertEncodedWebApi(c => c.Files.Remote.RemoveFile("F1234567890"), "files.remote.remove",
                "Web_FilesInfo.json", nvc => { Assert.Equal("F1234567890", nvc["file"]); });
        }

        [Fact]
        public async Task FilesRemote_Share()
        {
            await Utility.AssertEncodedWebApi(c => c.Files.Remote.ShareByExternalId("ABCD","C123","C456"), "files.remote.share",
                "Web_FilesInfo.json", nvc =>
                {
                    Assert.Equal("ABCD", nvc["external_id"]);
                    Assert.Equal("C123,C456", nvc["channels"]);
                });

            await Utility.AssertEncodedWebApi(c => c.Files.Remote.ShareByFile("F1234567890", "C123", "C456"), "files.remote.share",
                "Web_FilesInfo.json", nvc =>
                {
                    Assert.Equal("F1234567890", nvc["file"]);
                    Assert.Equal("C123,C456", nvc["channels"]);
                });
        }

        [Fact]
        public async Task FilesRemote_GetExternal()
        {
            await Utility.AssertWebApi(c => c.Files.GetExternalUploadUrl(new GetExternalUploadUrlRequest("test.jpg",123)
                {
                    AltTxt = "alt",
                    SnippetType = "test"
                }), "files.getUploadURLExternal",
                "Web_FilesGetExternal.json", jo =>
                {
                    Assert.Equal("test", jo.Value<string>("snippet_type"));
                    Assert.Equal("alt", jo.Value<string>("alt_txt"));
                    Assert.Equal("test.jpg", jo.Value<string>("filename"));
                    Assert.Equal(123, jo.Value<int>("length"));
                });
        }

        [Fact]
        public async Task FilesRemote_CompleteExternal()
        {
            var response = await Utility.AssertWebApi(c => c.Files.CompleteExternalUpload(new CompleteExternalUploadRequest
                {

                }), "files.completeUploadExternal",
                "Web_FilesCompleteExternal.json", jo =>
                {

                });
            Assert.Single(response.Files);
        }
    }
}