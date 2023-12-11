using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBiosecurity.Dtos.Get.Company;
using AutoMapper;
using Domain.Entities.Company;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBiosecurity.Controller.Company;

public class WorkshiftController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WorkshiftController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<WorkshiftDto>>> Get()
    {
        var workShifts = await _unitOfWork.Workshifts.GetAllAsync();
        /* return Ok(workShifts); */
        return _mapper.Map<List<WorkshiftDto>>(workShifts);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WorkshiftDto>> Get(int id)
    {
        var workShift = await _unitOfWork.Workshifts.GetByIdAsync(id);
        if (workShift == null)
        {
            return NotFound();
        }
        return _mapper.Map<WorkshiftDto>(workShift);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Workshift>> Post(WorkshiftDto workshiftDto)
    {
        var workShift = _mapper.Map<Workshift>(workshiftDto);

        this._unitOfWork.Workshifts.Add(workShift);
        await _unitOfWork.SaveAsync();
        if (workShift == null)
        {
            return BadRequest();
        }
        workshiftDto.Id = workShift.Id;
        return CreatedAtAction(nameof(Post), new { id = workshiftDto.Id }, workshiftDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkshiftDto>> Put(int id, [FromBody] WorkshiftDto workshiftDto)
    {
        var workShift = _mapper.Map<Workshift>(workshiftDto);
        if (workShift.Id == 0)
        {
            workShift.Id = id;
        }
        if (workShift.Id != id)
        {
            return BadRequest();
        }
        if (workShift == null)
        {
            return NotFound();
        }

        workshiftDto.Id = workShift.Id;
        _unitOfWork.Workshifts.Update(workShift);
        await _unitOfWork.SaveAsync();
        return workshiftDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var workShift = await _unitOfWork.Workshifts.GetByIdAsync(id);
        if (workShift == null)
        {
            return NotFound();
        }
        _unitOfWork.Workshifts.Remove(workShift);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}