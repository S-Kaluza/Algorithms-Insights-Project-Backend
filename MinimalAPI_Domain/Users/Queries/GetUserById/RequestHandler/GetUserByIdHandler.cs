using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_Application.Enums;
using MinimalAPI_Application.Extensions;
using MinimalAPI_Application.Models.Domains;
using MinimalAPI_Application.Models.Entity.User;
using MinimalAPI_DataAccess;

namespace MinimalAPI_Domain.Users.Queries.GetUserById.RequestHandler;

public class GetUserByIdHandler(ApplicationDbContext context) : IRequestHandler<Request.GetUserById, User>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<User> Handle(Request.GetUserById request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id,
                       cancellationToken: cancellationToken)
                   ?? throw new DomainException(ErrorCodeEnum.UserNotFound,
                       ErrorCodeEnum.UserNotFound.GetDescription());
        return user;
    }
}