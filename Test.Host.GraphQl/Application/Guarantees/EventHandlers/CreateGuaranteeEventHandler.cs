using DotNetCore.CAP;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using Domain.Guarantees;
using Event.Integration.Guarantees;

namespace Application.Guarantees.EventHandlers
{
    public class CreateGuaranteeEventHandler : ICapSubscribe
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;

        public CreateGuaranteeEventHandler(IWriteUnitOfWork writeUnitOfWork)
        {
            _writeUnitOfWork = writeUnitOfWork;
        }

        [CapSubscribe(nameof(CreateGuaranteeEvent))]
        public async Task Handler(CreateGuaranteeEvent message)
        {
            return;//because dont have Macroservice

            var instance = Guarantee.CreateInstance();

            instance.SetClientId(message.ClientId);

            instance.SetGuaranteeMethod(message.Method);

            instance.SetCurrencyId(message.CurrencyId);

            instance.SetExchangeRate(message.ExchangeRate);

            instance.SetDate(message.Date);

            instance.SetDescription(message.Description);

            await _writeUnitOfWork.GuaranteeWriteRepository.AddAsync(instance);
            await _writeUnitOfWork.Commit(string.Empty);

        }

    }
}
