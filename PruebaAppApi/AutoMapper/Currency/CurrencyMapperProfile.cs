using AplicationServices.DTOs.Currency;
using AutoMapper;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.AutoMapper.Currency
{
    public class CurrencyMapperProfile : Profile
    {
        public CurrencyMapperProfile()
        {
            FromCurrency_DMtoGetCurrenciesDTO();
        }

        /// <summary>
        /// convierte desde Currency_DM hasta GetCurrenciesDTO
        /// </summary>
        private void FromCurrency_DMtoGetCurrenciesDTO()
        {
            CreateMap<Currency_DM, GetCurrenciesDTO>()
                .ForMember(target => target.IdDto, opt => opt.MapFrom(source => source.ID))
                .ForMember(target => target.DescriptionDto, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.CodeDto, opt => opt.MapFrom(source => source.code))
                .ReverseMap();

        }
    }
}
