using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Projects
{
    public class CreateProjectEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ManagerId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
    }
}