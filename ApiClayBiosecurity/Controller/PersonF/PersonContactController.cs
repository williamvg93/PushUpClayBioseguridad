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

public class PersonContactController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonContactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersoncontactDto>>> Get()
    {
        var peopleContacts = await _unitOfWork.Personcontacts.GetAllAsync();
        /* return Ok(peopleContacts); */
        return _mapper.Map<List<PersoncontactDto>>(peopleContacts);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersoncontactDto>> Get(int id)
    {
        var personContact = await _unitOfWork.Personcontacts.GetByIdAsync(id);
        if (personContact == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersoncontactDto>(personContact);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Personcontact>> Post(PersoncontactDto personcontactDto)
    {
        var personContact = _mapper.Map<Personcontact>(personcontactDto);

        this._unitOfWork.Personcontacts.Add(personContact);
        await _unitOfWork.SaveAsync();
        if (personContact == null)
        {
            return BadRequest();
        }
        personcontactDto.Id = personContact.Id;
        return CreatedAtAction(nameof(Post), new { id = personcontactDto.Id }, personcontactDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersoncontactDto>> Put(int id, [FromBody] PersoncontactDto personcontactDto)
    {
        var personContact = _mapper.Map<Personcontact>(personcontactDto);
        if (personContact.Id == 0)
        {
            personContact.Id = id;
        }
        if (personContact.Id != id)
        {
            return BadRequest();
        }
        if (personContact == null)
        {
            return NotFound();
        }

        personcontactDto.Id = personContact.Id;
        _unitOfWork.Personcontacts.Update(personContact);
        await _unitOfWork.SaveAsync();
        return personcontactDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var personContact = await _unitOfWork.Personcontacts.GetByIdAsync(id);
        if (personContact == null)
        {
            return NotFound();
        }
        _unitOfWork.Personcontacts.Remove(personContact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}