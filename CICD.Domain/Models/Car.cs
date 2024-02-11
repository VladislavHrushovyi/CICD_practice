using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CICD.Domain.Models;

public class Car
{
    [JsonProperty(PropertyName = "brand")]
    public string Brand { get; set; }
    
    [JsonProperty(PropertyName = "model")]
    public string Model { get; set; }    
}