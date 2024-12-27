using MinimalAPI_Application.Enums;
using MinimalAPI_Application.General;

namespace MinimalAPI_DataAccess.General.User;

public class RolesSeed
{
    public static List<Roles> Seed()
    {
        List<Roles> rolesList = new();
        foreach (RolesEnum item in Enum.GetValues(typeof(RolesEnum)))
            rolesList.Add(new Roles
            {
                Id = (int)item,
                Name = item.ToString()
            });
        return rolesList;
    }
}