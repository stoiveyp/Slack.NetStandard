using System;
using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.Messages.Blocks
{
    public class RawNumberCell : ITableRowCell
    {
        public RawNumberCell(int value)
        {
            Number = value;
            _isInteger = true;
        }

        public RawNumberCell(int value, string text):this(value)
        {
            Text = text;
        }

        public RawNumberCell(decimal value)
        {
            Number = value;
            _isInteger = false;
        }

        public RawNumberCell(decimal value, string text):this(value)
        {
            Text = text;
        }

        private bool _isInteger;
        public decimal Number { get; set; }
        public string Text { get; set; }

        public object GenerateCell()
        {
            object valueProp = _isInteger ? (object)Convert.ToInt32(Number) : (object)Number;
            return new JObject(
                new JProperty("type", "raw_number"),
                new JProperty("value", valueProp),
                new JProperty("text", Text ?? Number.ToString())
            );
        }
    }
}