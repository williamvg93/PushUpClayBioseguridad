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

public class PersoncategoryController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersoncategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersoncategoryDto>>> Get()
    {
        var personCategories = await _unitOfWork.Personcategories.GetAllAsync();
        /* return Ok(personCategories); */
        return _mapper.Map<List<PersoncategoryDto>>(personCategories);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersoncategoryDto>> Get(int id)
    {
        var personCategory = await _unitOfWork.Personcategories.GetByIdAsync(id);
        if (personCategory == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersoncategoryDto>(personCategory);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersoncategoryDto>> Post(PersoncategoryDto personcategoryDto)
    {
        var personCategory = _mapper.Map<Personcategory>(personcategoryDto);

        this._unitOfWork.Personcategories.Add(personCategory);
        await _unitOfWork.SaveAsync();
        if (personCategory == null)
        {
            return BadRequest();
        }
        personcategoryDto.Id = personCategory.Id;
        return CreatedAtAction(nameof(Post), new { id = personcategoryDto.Id }, personcategoryDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersoncategoryDto>> Put(int id, [FromBody] PersoncategoryDto personcategoryDto)
    {
        var personCategory = _mapper.Map<Personcategory>(personcategoryDto);
        if (personCategory.Id == 0)
        {
            personCategory.Id = id;
        }
        if (personCategory.Id != id)
        {
            return BadRequest();
        }
        if (personCategory == null)
        {
            return NotFound();
        }

        personcategoryDto.Id = personCategory.Id;
        _unitOfWork.Personcategories.Update(personCategory);
        await _unitOfWork.SaveAsync();
        return personcategoryDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var personCategory = await _unitOfWork.Personcategories.GetByIdAsync(id);
        if (personCategory == null)
        {
            return NotFound();
        }
        _unitOfWork.Personcategories.Remove(personCategory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}