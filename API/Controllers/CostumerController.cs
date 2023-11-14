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
    public class CostumerController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CostumerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CostumerDto>>> Get()
        {
            var costumers = await _unitOfWork.Costumers.GetAllAsync();

            return _mapper.Map<List<CostumerDto>>(costumers);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CostumerDto>> Get(int id)
        {
            var costumer = await _unitOfWork.Costumers.GetByIdAsync(id);
            if (costumer == null)
                return NotFound();

            return _mapper.Map<CostumerDto>(costumer);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Costumer>> Post(CostumerDto costumerDto)
        {
            var costumers = _mapper.Map<Costumer>(costumerDto);
            _unitOfWork.Costumers.Add(costumers);
            await _unitOfWork.SaveAsync();
            if (costumers == null)
            {
                return BadRequest();
            }
            costumerDto.Id = costumers.Id;
            return CreatedAtAction(nameof(Post), new { id = costumerDto.Id }, costumerDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CostumerDto>> Put(int id, [FromBody] CostumerDto costumerDto)
        {
            if (costumerDto.Id == 0)
            {
                costumerDto.Id = id;
            }
            if (costumerDto.Id != id)
            {
                return NotFound();
            }
            var costumer = _mapper.Map<Costumer>(costumerDto);
            costumerDto.Id = costumer.Id;
            _unitOfWork.Costumers.Update(costumer);
            await _unitOfWork.SaveAsync();
            return costumerDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var costumers = await _unitOfWork.Costumers.GetByIdAsync(id);
            if (costumers == null)
            {
                return NotFound();
            }
            _unitOfWork.Costumers.Remove(costumers);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}