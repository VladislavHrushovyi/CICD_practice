using System.Text.Json.Serialization;

namespace CICD.Application.Models;

public class Car
{
    [JsonPropertyName("brand")]
    public string Brand { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }    
}