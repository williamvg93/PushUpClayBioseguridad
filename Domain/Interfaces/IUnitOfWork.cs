using Domain.Interfaces.Company;
using Domain.Interfaces.Location;
using Domain.Interfaces.PersonF;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IShiftscheduling Shiftschedulings { get; }
    IWorkshift Workshifts { get; }
    IAddress Addresses { get; }
    IAddresstype Addresstypes { get; }
    ICountry Countries { get; }
    IDepartment Departments { get; }
    ITown Towns { get; }
    IContacttype Contacttypes { get; }
    IContract Contracts { get; }
    IContractstatus Contractstatuses { get; }
    IPerson People { get; }
    IPersoncategory Personcategories { get; }
    IPersoncontact Personcontacts { get; }
    IPersontype Peopletypes { get; }
    Task<int> SaveAsync();
}