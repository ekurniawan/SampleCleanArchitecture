using AutoMapper;
using MediatR;
using SampleCleanArchitecture.Application.Contracts.Persistence;
using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = _mapper.Map<Event>(request);
            var validator = new CreateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            newEvent = await _eventRepository.AddAsync(newEvent);
            return newEvent.EventId;
        }
    }
}
