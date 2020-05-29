using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Slack.NetStandard
{
    public class MultipartFile
    {
        public MultipartFile() {}

        public MultipartFile(Stream stream, string filename)
        {
            Stream = stream;
            Filename = filename;
        }
        public string Filename { get; }
        public Stream Stream { get; }
    }
}
