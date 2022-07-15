using DayanaCore.Infrastructure.Messaging;
using Domain;
using DotNetCore.CAP;
using Event.Integration.Guarantees;
using System.Threading.Tasks;

namespace Application.Guarantees.EventHandlers
{
    public class DeleteGuaranteeEventHandler : ICapSubscribe
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;
        private readonly IPubMessageHandler _pubMessageHandler;

        public DeleteGuaranteeEventHandler(IWriteUnitOfWork writeUnitOfWork, IPubMessageHandler pubMessageHandler)
        {
            _writeUnitOfWork = writeUnitOfWork;
            _pubMessageHandler = pubMessageHandler;
        }

        [CapSubscribe(nameof(DeleteGuaranteeEvent))]
        public async Task Handler(DeleteGuaranteeEvent message)
        {
            return;//because dont have Macroservice

            var entity = _writeUnitOfWork.GuaranteeWriteRepository.Get(message.Id);


            if (entity == null)
            {
                return;
            }

            _writeUnitOfWork.GuaranteeWriteRepository.SoftRemove(entity);

            await _writeUnitOfWork.Commit(string.Empty);

        }

    }
}
