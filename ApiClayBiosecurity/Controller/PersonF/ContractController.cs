using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBiosecurity.Dtos.Get.PersonF;
using AutoMapper;
using Domain.Entities.PersonF;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBiosecurity.Controller.PersonF;

public class ContractController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContractController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContractDto>>> Get()
    {
        var contracts = await _unitOfWork.Contracts.GetAllAsync();
        /* return Ok(contracts); */
        return _mapper.Map<List<ContractDto>>(contracts);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContractDto>> Get(int id)
    {
        var contract = await _unitOfWork.Contracts.GetByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContractDto>(contract);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contract>> Post(ContractDto contractDto)
    {
        var contract = _mapper.Map<Contract>(contractDto);

        this._unitOfWork.Contracts.Add(contract);
        await _unitOfWork.SaveAsync();
        if (contract == null)
        {
            return BadRequest();
        }
        contractDto.Id = contract.Id;
        return CreatedAtAction(nameof(Post), new { id = contractDto.Id }, contractDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContractDto>> Put(int id, [FromBody] ContractDto contractDto)
    {
        var contract = _mapper.Map<Contract>(contractDto);
        if (contract.Id == 0)
        {
            contract.Id = id;
        }
        if (contract.Id != id)
        {
            return BadRequest();
        }
        if (contract == null)
        {
            return NotFound();
        }

        contractDto.Id = contract.Id;
        _unitOfWork.Contracts.Update(contract);
        await _unitOfWork.SaveAsync();
        return contractDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var contract = await _unitOfWork.Contracts.GetByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        _unitOfWork.Contracts.Remove(contract);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}