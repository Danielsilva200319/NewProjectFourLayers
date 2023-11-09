using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CityController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CityDto>>> Get()
        {
            var cities = await _unitOfWork.Cities.GetAllAsync();
            return _mapper.Map<List<CityDto>>(cities);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> Get(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return _mapper.Map<CityDto>(city);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>> Post(CityDto cityDto)
        {
            var cities = _mapper.Map<City>(cityDto);
            _unitOfWork.Cities.Add(cities);
            await _unitOfWork.SaveAsync();
            if (cities == null)
            {
                return BadRequest();
            }
            cityDto.Id = cities.Id;
            return CreatedAtAction(nameof(Post), new { id = cityDto.Id }, cityDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> Put(int id, [FromBody] CityDto cityDto)
        {
            if (cityDto.Id == 0)
            {
                cityDto.Id = id;
            }
            if (cityDto.Id != id)
            {
                return NotFound();
            }
            var city = _mapper.Map<City>(cityDto);
            cityDto.Id = city.Id;
            _unitOfWork.Cities.Update(city);
            await _unitOfWork.SaveAsync();
            return cityDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var cities = await _unitOfWork.Cities.GetByIdAsync(id);
            if (cities == null)
            {
                return NotFound();
            }
            _unitOfWork.Cities.Remove(cities);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}