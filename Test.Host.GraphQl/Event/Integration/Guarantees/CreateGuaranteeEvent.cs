using System;
using System.Collections.Generic;
using DayanaCore.Infrastructure.Domain;
using Domain.Enums;

namespace Event.Integration.Guarantees
{
    public class CreateGuaranteeEvent : IIntegrationEvent
    {
        public CreateGuaranteeEvent()
        {
        }

        public Guid Id { get; set; }

        public Guid ClientId { get;  set; }

        public Guid CurrencyId { get;  set; }

        public decimal ExchangeRate { get;  set; }

        public GuaranteeMethodEnum Method { get;  set; }

        public DateTime Date { get;  set; }

        public string InternalNo { get;  set; }

        public string Description { get;  set; }

        public List<GuaranteeItemEvent> GuaranteeItems { get; set; }


    }

    public class GuaranteeItemEvent
    {
        public Guid? InvesmentId { get; private set; }
        public string ItemNo { get; private set; }
        public decimal Amount { get; private set; }
        public Guid? ReferenceTypeId { get; private set; }
        public GuaranteeItemReferenceTypeEnum? ReferenceType { get; private set; }
        public DateTime? IssueDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public Guid CurrencyId { get; private set; }
        public Guid GuaranteeId { get; private set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
    }
}