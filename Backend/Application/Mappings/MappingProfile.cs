using AutoMapper;
using Backend.Application.DTOs.Crypto;
using Backend.Application.DTOs.PriceHistory;
using Backend.Application.DTOs.Users;
using Backend.Domain.Entities;

namespace Backend.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<CreateUserDTO, User>();
        CreateMap<User, ReadUserDTO>();
        CreateMap<UpdateUserDTO, User>();

        CreateMap<CreateCryptoDTO, Crypto>();
        CreateMap<Crypto, ReadCryptoDTO>();

        CreateMap<CreatePriceHistoryDTO, PriceHistory>();
        CreateMap<PriceHistory, ReadPriceHistoryDTO>()
                .ForMember(dest => dest.CryptoSymbol, opt => opt.MapFrom(src => src.Crypto.Symbol))
                .ForMember(dest => dest.CryptoName, opt => opt.MapFrom(src => src.Crypto.Name));
    }
}
