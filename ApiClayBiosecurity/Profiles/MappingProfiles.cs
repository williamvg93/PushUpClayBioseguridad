using ApiClayBiosecurity.Dtos.Get.Company;
using ApiClayBiosecurity.Dtos.Get.Location;
using ApiClayBiosecurity.Dtos.Get.PersonF;
using ApiClayBiosecurity.Dtos.Post.Location;
using ApiClayBiosecurity.Dtos.Post.PersonF;
using AutoMapper;
using Domain.Entities.Company;
using Domain.Entities.Location;
using Domain.Entities.PersonF;

namespace ApiClayBiosecurity.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Shiftscheduling, ShiftschedulingDto>()
        .ReverseMap();

        CreateMap<Workshift, WorkshiftDto>()
        .ReverseMap();

        CreateMap<Address, AddressDto>()
        .ReverseMap();

        CreateMap<Addresstype, AddresstypeDto>()
        .ReverseMap();

        CreateMap<Country, CountryDto>()
        .ReverseMap();

        CreateMap<Department, DepartmentDto>()
        .ReverseMap();
        CreateMap<Department, DepartmentPDto>()
        .ReverseMap();

        CreateMap<Town, TownDto>()
        .ReverseMap();
        CreateMap<Town, TownPDto>()
        .ReverseMap();

        CreateMap<Contacttype, ContacttypeDto>()
        .ReverseMap();

        CreateMap<Contract, ContractDto>()
        .ReverseMap();

        CreateMap<Contractstatus, ContractstatusDto>()
        .ReverseMap();

        CreateMap<Personcategory, PersoncategoryDto>()
        .ReverseMap();

        CreateMap<Personcontact, PersoncontactDto>()
        .ReverseMap();

        CreateMap<Person, PersonDto>()
        .ReverseMap();
        CreateMap<Person, PersonPDto>()
        .ReverseMap();

        CreateMap<Persontype, PersontypeDto>()
        .ReverseMap();
    }
}