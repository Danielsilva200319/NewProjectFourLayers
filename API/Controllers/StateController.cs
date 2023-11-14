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
    public class StateController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<StateDto>>> Get()
        {
            var states = await _unitOfWork.States.GetAllAsync();
            return _mapper.Map<List<StateDto>>(states);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StateDto>> Get(int id)
        {
            var state = await _unitOfWork.States.GetByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return _mapper.Map<StateDto>(state);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State>> Post(StateDto stateDto)
        {
            var states = _mapper.Map<State>(stateDto);
            _unitOfWork.States.Add(states);
            await _unitOfWork.SaveAsync();
            if (states == null)
            {
                return BadRequest();
            }
            stateDto.Id = states.Id;
            return CreatedAtAction(nameof(Post), new { id = stateDto.Id }, stateDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StateDto>> Put(int id, [FromBody] StateDto stateDto)
        {
            if (stateDto.Id == 0)
            {
                stateDto.Id = id;
            }
            if (stateDto.Id != id)
            {
                return NotFound();
            }
            var state = _mapper.Map<State>(stateDto);
            stateDto.Id = state.Id;
            _unitOfWork.States.Update(state);
            await _unitOfWork.SaveAsync();
            return stateDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var states = await _unitOfWork.States.GetByIdAsync(id);
            if (states == null)
            {
                return NotFound();
            }
            _unitOfWork.States.Remove(states);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}