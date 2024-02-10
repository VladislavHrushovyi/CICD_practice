using CICD.Application.Common;

namespace CICD.Application.Models;

public class User : BaseModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Car> Cars { get; set; }
}