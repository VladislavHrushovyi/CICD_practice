using Newtonsoft.Json;

namespace CICD.Domain.Common;

public class BaseModel
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }
    
    [JsonProperty(PropertyName = "createdAt")]
    public string CreatedAt { get; set; }
}