using System.Text.Json.Serialization;

namespace CICD.Application.Common;

public class BaseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }
}