using AutoMapper;
using Domain.GuaranteeItems;
using Domain.GuaranteeItems.Dtos;

namespace DataAccess.Domain.GuaranteeItems
{

    public class   GuaranteeItemMapper : Profile 
    {
        public   GuaranteeItemMapper()
        {
            CreateMap<GuaranteeItem, GuaranteeItemResponseDto>(); 
        }
    }
}
