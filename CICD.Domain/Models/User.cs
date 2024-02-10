using System.Text.Json.Serialization;
using CICD.Application.Common;

namespace CICD.Application.Models;

public class User : BaseModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    
    [JsonIgnore]
    public ICollection<Car> Cars { get; set; }
}