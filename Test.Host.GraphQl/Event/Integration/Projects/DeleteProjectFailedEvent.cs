using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Projects
{
    public class DeleteProjectFailedEvent:IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}