using MinimalAPI_Application.Enums;
using MinimalAPI_Application.General;

namespace MinimalAPI_DataAccess.General.User;

public class StatusSeed
{
    public static List<Status> Seed()
    {
        List<Status> userStatusList = new();
        foreach (StatusEnum item in Enum.GetValues(typeof(StatusEnum)))
            userStatusList.Add(new Status
            {
                Id = (int)item,
                Name = item.ToString()
            });
        return userStatusList;
    }
}