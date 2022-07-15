using System;
using System.Collections.Generic;
using DayanaCore.Infrastructure.Domain;
using Domain.Enums;

namespace Event.Integration.Guarantees
{
    public class UpdateGuaranteeEvent : IIntegrationEvent
    {
        public UpdateGuaranteeEvent()
        {
     
        }

        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal ExchangeRate { get; set; }

        public GuaranteeMethodEnum Method { get; set; }

        public DateTime Date { get; set; }

        public string InternalNo { get; set; }

        public string Description { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }

    }
}