using AutoMapper;
using Backend.Models;
using Backend.DTOS.School.Accounts;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<AccountsDTO, Accounts>().ReverseMap();
    }
}
