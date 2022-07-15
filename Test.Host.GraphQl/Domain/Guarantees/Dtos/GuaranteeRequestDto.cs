using System;
using Domain.Enums;
using System.Collections.Generic;
using Domain.GuaranteeItems.Dtos;

namespace Domain.Guarantees.Dtos
{
    public class GuaranteeRequestDto : BaseRequestDto
    {
        public Guid ClientId { get;  set; }
        public Guid CurrencyId { get;  set; }
        public decimal ExchangeRate { get;  set; }
        public GuaranteeMethodEnum Method { get;  set; }
        public DateTime Date { get;  set; }
        public string Description { get;  set; }
        public List<GuaranteeItemRequestDto> GuaranteeItemDto { get; set; }
    }
}