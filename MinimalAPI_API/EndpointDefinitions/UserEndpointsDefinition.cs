using MediatR;
using MinimalAPI_Domain.Users.Queries.GetUserById.Request;
using MinimalAPIWebApplication.EndpointDefinition;

namespace MinimalAPIWebApplication.EndpointDefinitions;

public class UserEndpointsDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var users = app.MapGroup("/api/users");
        users.MapGet("/{id}", GetUser)
            .WithName("getUserById");
    }

    public async Task<IResult> GetUser(IMediator mediator, int id)
    {
        var getUser = new GetUserById { Id = id };
        var user = await mediator.Send(getUser);
        return Results.Ok(user);
    }
}