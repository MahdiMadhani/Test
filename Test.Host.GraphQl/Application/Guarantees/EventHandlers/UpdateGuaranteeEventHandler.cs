using DotNetCore.CAP;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using Event.Integration.Guarantees;

namespace Application.Guarantees.EventHandlers
{
    public class UpdateGuaranteeEventHandler : ICapSubscribe
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;

        public UpdateGuaranteeEventHandler(IWriteUnitOfWork writeUnitOfWork)
        {
            _writeUnitOfWork = writeUnitOfWork;
        }

        [CapSubscribe(nameof(UpdateGuaranteeEvent))]
        public async Task Handler(UpdateGuaranteeEvent message)
        {
            return;//because dont have Macroservice

            var instance = _writeUnitOfWork.GuaranteeWriteRepository.Get(message.Id);
            if (instance == null)
                return;


            instance.SetClientId(message.ClientId);

            instance.SetGuaranteeMethod(message.Method);


            instance.SetCurrencyId(message.CurrencyId);

            instance.SetExchangeRate(message.ExchangeRate);

            instance.SetDate(message.Date);

            instance.SetDescription(message.Description);

            _writeUnitOfWork.GuaranteeWriteRepository.UpdateEntity(instance);
            await _writeUnitOfWork.Commit(string.Empty);

        }

    }
}
