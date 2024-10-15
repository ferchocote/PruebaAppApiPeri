using AplicationServices.DTOs.Branch;
using AplicationServices.DTOs.Currency;
using AutoMapper;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.AutoMapper.Branch
{
    public class BranchMapperProfile : Profile
    {
        public BranchMapperProfile()
        {
            FromBranch_DMtoGetBranchesDTO();
            FromBranch_DMtoRequestAddBranchDto();
        }

        /// <summary>
        /// convierte desde Branch_DM hasta GetBranchesDTO
        /// </summary>
        private void FromBranch_DMtoGetBranchesDTO()
        {
            CreateMap<Branch_DM, GetBranchesDTO>()
                .ForMember(target => target.IdDto, opt => opt.MapFrom(source => source.ID))
                .ForMember(target => target.CodeDto, opt => opt.MapFrom(source => source.Code))
                .ForMember(target => target.DescriptionDto, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.AddressDto, opt => opt.MapFrom(source => source.Address))
                .ForMember(target => target.IdentificationDto, opt => opt.MapFrom(source => source.Identification))
                .ForMember(target => target.CreationDateDto, opt => opt.MapFrom(source => source.CreationDate))
                .ForMember(target => target.IdCurrencyDto, opt => opt.MapFrom(source => source.Currency))
                .ForMember(target => target.CurrencyDescriptionDto, opt => opt.MapFrom(source => source.CurrencyNavigation.Description ?? null))
                .ReverseMap();

        }

        /// <summary>
        /// convierte desde Branch_DM hasta RequestAddBranchDto
        /// </summary>
        private void FromBranch_DMtoRequestAddBranchDto()
        {
            CreateMap<Branch_DM, RequestAddBranchDto>()
                .ForMember(target => target.IdDto, opt => opt.MapFrom(source => source.ID))
                .ForMember(target => target.CodeDto, opt => opt.MapFrom(source => source.Code))
                .ForMember(target => target.DescriptionDto, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.AddressDto, opt => opt.MapFrom(source => source.Address))
                .ForMember(target => target.IdentificationDto, opt => opt.MapFrom(source => source.Identification))
                .ForMember(target => target.CreationDateDto, opt => opt.MapFrom(source => source.CreationDate))
                .ForMember(target => target.IdCurrencyDto, opt => opt.MapFrom(source => source.Currency))
                .ReverseMap();

        }
    }
}
