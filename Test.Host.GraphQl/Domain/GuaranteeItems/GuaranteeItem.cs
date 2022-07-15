using Domain.Enums;
using Domain.Guarantees;
using DayanaCore.Infrastructure.Domain;
using System;

namespace Domain.GuaranteeItems
{
    public class GuaranteeItem : Entity
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
        public Guarantee Guarantee { get; set; }

        public void UpdateInstance()
        {
            UpdatedDate = DateTime.UtcNow;
        }

        public static GuaranteeItem CreateInstance(Guid guaranteeId)
        {
            var newEntity = new GuaranteeItem
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                GuaranteeId = guaranteeId
            };
            return newEntity;
        }

        public void SetInvesmentId(Guid? invesmentId)
        {
            InvesmentId = invesmentId;
        }
        public void SetItemNo(string itemNo)
        {
            ItemNo = itemNo;
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }
        public void SetReferenceTypeId(Guid? referenceTypeId)
        {
            ReferenceTypeId = referenceTypeId;
        }
        public void SetReferenceType(GuaranteeItemReferenceTypeEnum? referenceType)
        {
            ReferenceType = referenceType;
        }
        public void SetGuaranteeId(Guid guaranteeId)
        {
            GuaranteeId = guaranteeId;
        }
        public void SetCurrencyId(Guid currencyId)
        {
            CurrencyId = currencyId;
        }
        public void SetIssueDate(DateTime? issueDate)
        {
            IssueDate = issueDate;
        }
        public void SetDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
        }
    }
}