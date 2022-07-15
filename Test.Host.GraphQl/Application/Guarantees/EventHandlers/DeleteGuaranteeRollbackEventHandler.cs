using System;
using DotNetCore.CAP;
using System.Threading.Tasks;
using Domain;
using Event.Integration.Guarantees;
using Microsoft.EntityFrameworkCore;

namespace Application.ReadOnly.Guarantees.EventHandlers
{
    public class DeleteGuaranteeRollbackEventHandler : ICapSubscribe
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;

        public DeleteGuaranteeRollbackEventHandler(IWriteUnitOfWork writeUnitOfWork)
        {
            _writeUnitOfWork = writeUnitOfWork;
        }

        [CapSubscribe(nameof(DeleteGuaranteeRollbackEvent))]
        public async Task Handler(DeleteGuaranteeRollbackEvent message)
        {
            return;//because dont have Macroservice

            var entity = await _writeUnitOfWork.GuaranteeWriteRepository.Find(it => it.Id == message.Id)
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return;
            }


            entity.Deleted = false;
            _writeUnitOfWork.GuaranteeWriteRepository.UpdateEntity(entity);

            await _writeUnitOfWork.Commit(string.Empty);

        }

    }
}
