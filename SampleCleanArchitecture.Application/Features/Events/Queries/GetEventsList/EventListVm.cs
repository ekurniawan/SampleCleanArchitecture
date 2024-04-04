﻿namespace SampleCleanArchitecture.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
    }
}
