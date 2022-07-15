using Domain.Enums;
using Domain.GuaranteeItems.Dtos;
using System;
using System.Collections.Generic;

namespace Domain.Guarantees.Dtos
{
    public class GuaranteeResponseDto
    {
        public Guid Id { get; set; }

        public Guid ClientId { get;  set; }

        public string ClientName { get; set; }

        public Guid CurrencyId { get;  set; }

       // public string CurrencyName { get;  set; }

        public decimal ExchangeRate { get;  set; }

        public GuaranteeMethodEnum Method { get;  set; }

        public DateTime Date { get;  set; }

        public string InternalNo { get;  set; }

        public string Description { get;  set; }
         
        public List<GuaranteeItemResponseDto> GuaranteeItemDto { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}