using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Projects
{
    public class DeleteProjectRollbackEvent:IIntegrationEvent
    {
        
        public Guid Id { get; set; }
        public string Message { get; set; }

    }
}