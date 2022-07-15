using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Contacts
{
    public class DeleteContactFailedEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

    }
}