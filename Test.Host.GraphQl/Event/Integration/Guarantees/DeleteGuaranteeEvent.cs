using System;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Guarantees
{
    public class DeleteGuaranteeEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }

    }
}