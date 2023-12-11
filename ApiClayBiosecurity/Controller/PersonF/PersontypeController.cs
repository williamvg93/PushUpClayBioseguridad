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

public class PersontypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersontypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersontypeDto>>> Get()
    {
        var peopleTypes = await _unitOfWork.Peopletypes.GetAllAsync();
        /* return Ok(peopleTypes); */
        return _mapper.Map<List<PersontypeDto>>(peopleTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersontypeDto>> Get(int id)
    {
        var personType = await _unitOfWork.Peopletypes.GetByIdAsync(id);
        if (personType == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersontypeDto>(personType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persontype>> Post(PersontypeDto persontypeDto)
    {
        var personType = _mapper.Map<Persontype>(persontypeDto);

        this._unitOfWork.Peopletypes.Add(personType);
        await _unitOfWork.SaveAsync();
        if (personType == null)
        {
            return BadRequest();
        }
        persontypeDto.Id = personType.Id;
        return CreatedAtAction(nameof(Post), new { id = persontypeDto.Id }, persontypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersontypeDto>> Put(int id, [FromBody] PersontypeDto persontypeDto)
    {
        var personType = _mapper.Map<Persontype>(persontypeDto);
        if (personType.Id == 0)
        {
            personType.Id = id;
        }
        if (personType.Id != id)
        {
            return BadRequest();
        }
        if (personType == null)
        {
            return NotFound();
        }

        persontypeDto.Id = personType.Id;
        _unitOfWork.Peopletypes.Update(personType);
        await _unitOfWork.SaveAsync();
        return persontypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var personType = await _unitOfWork.Peopletypes.GetByIdAsync(id);
        if (personType == null)
        {
            return NotFound();
        }
        _unitOfWork.Peopletypes.Remove(personType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}