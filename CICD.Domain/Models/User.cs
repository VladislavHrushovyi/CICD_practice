using CICD.Domain.Common;
using Newtonsoft.Json;

namespace CICD.Domain.Models;

public class User : BaseModel
{
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    
    [JsonProperty(PropertyName = "surname")]
    public string Surname { get; set; }
    
    [JsonProperty(PropertyName = "cars")]
    public ICollection<Car> Cars { get; set; }
}