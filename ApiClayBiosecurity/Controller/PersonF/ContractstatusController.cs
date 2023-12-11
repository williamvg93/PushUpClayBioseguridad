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

public class ContractstatusController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContractstatusController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContractstatusDto>>> Get()
    {
        var contractStatuses = await _unitOfWork.Contractstatuses.GetAllAsync();
        /* return Ok(contractStatuses); */
        return _mapper.Map<List<ContractstatusDto>>(contractStatuses);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContractstatusDto>> Get(int id)
    {
        var contractStatus = await _unitOfWork.Contractstatuses.GetByIdAsync(id);
        if (contractStatus == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContractstatusDto>(contractStatus);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contractstatus>> Post(ContractstatusDto contractstatusDto)
    {
        var contractStatus = _mapper.Map<Contractstatus>(contractstatusDto);

        this._unitOfWork.Contractstatuses.Add(contractStatus);
        await _unitOfWork.SaveAsync();
        if (contractStatus == null)
        {
            return BadRequest();
        }
        contractstatusDto.Id = contractStatus.Id;
        return CreatedAtAction(nameof(Post), new { id = contractstatusDto.Id }, contractstatusDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContractstatusDto>> Put(int id, [FromBody] ContractstatusDto contractstatusDto)
    {
        var contractStatus = _mapper.Map<Contractstatus>(contractstatusDto);
        if (contractStatus.Id == 0)
        {
            contractStatus.Id = id;
        }
        if (contractStatus.Id != id)
        {
            return BadRequest();
        }
        if (contractStatus == null)
        {
            return NotFound();
        }

        contractstatusDto.Id = contractStatus.Id;
        _unitOfWork.Contractstatuses.Update(contractStatus);
        await _unitOfWork.SaveAsync();
        return contractstatusDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var contractStatus = await _unitOfWork.Contractstatuses.GetByIdAsync(id);
        if (contractStatus == null)
        {
            return NotFound();
        }
        _unitOfWork.Contractstatuses.Remove(contractStatus);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}