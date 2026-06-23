using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.JsonConverters
{
    public class ChartConverter : JsonConverter<IChart>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, IChart value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IChart ReadJson(JsonReader reader, Type objectType, IChart existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            IChart target;
            if (string.IsNullOrWhiteSpace(componentType))
            {
                if(objectType != typeof(IChart)){
                    target = (IChart)Activator.CreateInstance(objectType);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                target = GetComponent(componentType);
            }
            
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"MessageBlock type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> IChartLookup = new()
        {
            {PieChart.ChartType, typeof(PieChart)},
            {BarChart.ChartType, typeof(BarChart)},
            {LineChart.ChartType, typeof(LineChart)},
            {AreaChart.ChartType, typeof(AreaChart)},
        };

        private IChart GetComponent(string type)
        {
            return (IChart) (
                IChartLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IChartLookup[type])
                    : new UnknownChart());
        }
    }
}
