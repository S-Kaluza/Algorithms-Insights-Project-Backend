using MinimalAPI_Application.Models.Entity.User;

namespace MinimalAPI_Application.General;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
}