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

public class ShiftschedulingController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ShiftschedulingController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ShiftschedulingDto>>> Get()
    {
        var shiftScheduling = await _unitOfWork.Shiftschedulings.GetAllAsync();
        /* return Ok(shiftScheduling); */
        return _mapper.Map<List<ShiftschedulingDto>>(shiftScheduling);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShiftschedulingDto>> Get(int id)
    {
        var shiftSheduling = await _unitOfWork.Shiftschedulings.GetByIdAsync(id);
        if (shiftSheduling == null)
        {
            return NotFound();
        }
        return _mapper.Map<ShiftschedulingDto>(shiftSheduling);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Shiftscheduling>> Post(ShiftschedulingDto shiftschedulingDto)
    {
        var shiftSheduling = _mapper.Map<Shiftscheduling>(shiftschedulingDto);

        this._unitOfWork.Shiftschedulings.Add(shiftSheduling);
        await _unitOfWork.SaveAsync();
        if (shiftSheduling == null)
        {
            return BadRequest();
        }
        shiftschedulingDto.Id = shiftSheduling.Id;
        return CreatedAtAction(nameof(Post), new { id = shiftschedulingDto.Id }, shiftschedulingDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ShiftschedulingDto>> Put(int id, [FromBody] ShiftschedulingDto shiftschedulingDto)
    {
        var shiftSheduling = _mapper.Map<Shiftscheduling>(shiftschedulingDto);
        if (shiftSheduling.Id == 0)
        {
            shiftSheduling.Id = id;
        }
        if (shiftSheduling.Id != id)
        {
            return BadRequest();
        }
        if (shiftSheduling == null)
        {
            return NotFound();
        }

        shiftschedulingDto.Id = shiftSheduling.Id;
        _unitOfWork.Shiftschedulings.Update(shiftSheduling);
        await _unitOfWork.SaveAsync();
        return shiftschedulingDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var shiftSheduling = await _unitOfWork.Shiftschedulings.GetByIdAsync(id);
        if (shiftSheduling == null)
        {
            return NotFound();
        }
        _unitOfWork.Shiftschedulings.Remove(shiftSheduling);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}