using Domain.Enums;
using DayanaCore.Infrastructure.Domain;
using System;

namespace Domain.Guarantees.Dtos
{
    public class GuaranteeSearchDto
    {
        
        [SearchableGuid(Operator = "eq")]
        public Guid? ClientId { get;  set; }
        [SearchableString(Operator = "co")]
        public string ClientName { get; set; }
        [SearchableEnum(Operator = "eq")]
        public GuaranteeMethodEnum? Method { get;  set; }
        [SearchableDateTime(Operator = "gte")]
        public DateTime? Date { get;  set; }
        [SearchableString(Operator = "co")]
        public string InternalNo { get;  set; }
        [SearchableDateTime(Operator = "gte")]
        public DateTime? UpdatedDate { get; set; }
        [SearchableString(Operator = "co")]
        public string ItemNo { get; set; }
        [SearchableDecimal(Operator = "eq")]
        public decimal? Amount { get; set; }
        [SearchableDateTime(Operator = "gte")]
        public DateTime? IssueDate { get;   set; }
        [SearchableDateTime(Operator = "gte")]
        public DateTime? DueDate { get;   set; }

    }
}