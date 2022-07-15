using Domain.Enums;
using System;

namespace Domain.Guarantees.Dtos
{
    public class GuaranteeHistoryListResponseDto
    {
        public Guid Id { get; set; }
        public string InternalNo { get;   set; }
        public DateTime Date { get;   set; }
        public Guid ClientId { get;   set; }
        public string ClientName { get;   set; }
        public GuaranteeMethodEnum Method { get;   set; }
        public string ItemNo { get;   set; }
        public decimal Amount { get;   set; } 
        public string TrackingNo { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}