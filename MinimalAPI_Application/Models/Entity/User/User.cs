using Microsoft.AspNetCore.Identity;
using MinimalAPI_Application.Enums;
using MinimalAPI_Application.General;

namespace MinimalAPI_Application.Models.Entity.User;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public StatusEnum Status { get; set; }
    public int StatusId { get; set; }
    public int RolesId { get; set; }
    public Roles Roles { get; set; }
}