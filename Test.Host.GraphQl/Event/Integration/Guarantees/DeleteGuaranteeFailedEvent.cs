using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Guarantees
{
    public class DeleteGuaranteeFailedEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

    }
}