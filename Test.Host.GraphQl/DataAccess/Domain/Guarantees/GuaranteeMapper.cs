using AutoMapper;
using Domain.Guarantees;
using Domain.Guarantees.Dtos;

namespace DataAccess.Domain.Guarantees
{
     
    public class GuaranteeMapper : Profile
    {
        public GuaranteeMapper()
        {
            CreateMap<Guarantee, GuaranteeResponseDto>(); 
        }
    }
}
