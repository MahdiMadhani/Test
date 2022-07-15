using DayanaCore.Infrastructure.Domain;
using System;
using Domain.Enums;
using Domain.GuaranteeItems;
using System.Collections.Generic;

namespace Domain.Guarantees
{
    public class Guarantee : Entity
    {
        private Guarantee()
        {
            GuaranteeItems = new List<GuaranteeItem>();
        }

        public Guid ClientId { get; private set; }

        public Guid CurrencyId { get; private set; }

        public decimal ExchangeRate { get; private set; }

        public GuaranteeMethodEnum Method { get; private set; }

        public DateTime Date { get; private set; }

        public string InternalNo { get; private set; }

        public string Description { get; private set; }

        public List<GuaranteeItem> GuaranteeItems { get; set; }

        public static Guarantee CreateInstance()
        {
            var newEntity = new Guarantee
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            return newEntity;
        }

        //public void SetPaymentType (PaymentTypeEnum paymentType)
        //{
        //    PaymentType = paymentType;
        //}

        public void SetClientId(Guid clientId)
        {
            ClientId = clientId;
        }

        public void SetCurrencyId(Guid currencyId)
        {
            CurrencyId = currencyId;
        }

        public void SetExchangeRate(decimal exchangeRate)
        {
            ExchangeRate = exchangeRate;
        }

        

        public void SetGuaranteeMethod(GuaranteeMethodEnum GuaranteeMethod)
        {
            Method = GuaranteeMethod;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void SetInternalNo(string internalNo)
        {
            InternalNo = internalNo;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }

        public void UpdateInstance()
        {
            UpdatedDate = DateTime.UtcNow;
        }


    }
}