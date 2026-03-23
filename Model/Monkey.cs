using System.Text.Json.Serialization;
using System.Text.Json;

namespace MonkeyFinderHybrid.Model;

public class Monkey
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

        public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Population { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }



}
[JsonSerializable(typeof(List<Monkey>))]
internal sealed partial class MonkeyContext : JsonSerializerContext
{
 
}