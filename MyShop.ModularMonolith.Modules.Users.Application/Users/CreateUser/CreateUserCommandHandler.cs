using MassTransit;
using MediatR;
using MyShop.ModularMonolith.Modules.Users.Domain.Users;

namespace MyShop.ModularMonolith.Modules.Users.Application.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IBus bus)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _bus = bus;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.UserName);

        await _userRepository.AddAsync(user);

        await _bus.Publish(new UserCreatedDomainEvent(Guid.NewGuid(), user.Id));

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}