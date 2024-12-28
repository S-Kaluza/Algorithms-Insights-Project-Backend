using MediatR;
using MinimalAPI_Application.Models.Entity.User;

namespace MinimalAPI_Domain.Users.Queries.GetUserById.Request;

public class GetUserById : IRequest<User>
{
    public int Id { get; set; }
}