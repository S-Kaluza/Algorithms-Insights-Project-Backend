using Microsoft.AspNetCore.Identity;
using MinimalAPI_Application.Models.Entity.User;

namespace MinimalAPI_Application.General;

public class Roles : IdentityRole<int>
{
    public IList<User> Users { get; set; }
}