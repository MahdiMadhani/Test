using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Projects
{
    public class DeleteProjectEvent:IIntegrationEvent
    {
        public Guid Id { get; set; }
    }
}