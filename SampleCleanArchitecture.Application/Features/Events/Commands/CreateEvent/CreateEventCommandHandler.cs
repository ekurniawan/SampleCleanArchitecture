using MediatR;

namespace SampleCleanArchitecture.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        public Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
