using Domain.Enums;
using System;

namespace Domain.GuaranteeItems.Dtos
{
    public class GuaranteeItemRequestDto
    {
        public Guid Id { get; set; }
        public Guid InvesmentId { get;   set; }
        public string ItemNo { get;   set; }
        public decimal Amount { get;   set; }
        public Guid? ReferenceTypeId { get;   set; }
        public GuaranteeItemReferenceTypeEnum? ReferenceType { get;   set; }
        public FormStatus? Status { get; set; }
        public Guid CurrencyId { get;   set; }
        public DateTime? IssueDate { get;   set; }
        public DateTime DueDate { get;   set; }
    }
}