using ApiClayBiosecurity.Dtos.Get.PersonF;
using ApiClayBiosecurity.Dtos.Querys;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBiosecurity.Controller.Querys;

public class QuerysController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuerysController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Employees */
    [HttpGet("GetAllEmployees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TypePersonPersonDto>>> GetAllEmployees()
    {
        var employees = await _unitOfWork.Peopletypes.GetAllEmployees();
        /* return Ok(employees); */
        return _mapper.Map<List<TypePersonPersonDto>>(employees);
    }

    /* List All employees who are security guards */
    [HttpGet("GetVigilantEmployees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryPersonPersonDto>>> GetVigilantEmployees()
    {
        var employees = await _unitOfWork.Personcategories.GetVigilantEmployees();
        /* return Ok(employees); */
        return _mapper.Map<List<CategoryPersonPersonDto>>(employees);
    }

    /* List of phone numbers of a vigilant*/
    [HttpGet("GetPhoneNumbersVigilant{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VigilantPhoneNumberDto>>> GetPhoneNumbersVigilant(int id)
    {
        var employees = await _unitOfWork.People.GetPhoneNumbersVigilant(id);
        /* return Ok(employees); */
        return _mapper.Map<List<VigilantPhoneNumberDto>>(employees);
    }
}
