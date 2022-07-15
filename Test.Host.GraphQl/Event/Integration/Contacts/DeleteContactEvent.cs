using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Contacts
{
    public class DeleteContactEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }

    }
}