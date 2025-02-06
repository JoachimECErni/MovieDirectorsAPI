using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Data.Repositories.Interfaces;
using MovieDirectorsAPI.Exceptions;

namespace MovieDirectorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastRepository<Cast> _context;
        private readonly IMapper _mapper;

        public CastController(ICastRepository<Cast> context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetCast(int id)
        {
            try
            {
                var actor = await _context.Get(id);
                var actorDTO = _mapper.Map<ActorDTO>(actor);
                return Ok(actorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateCast([FromBody] CreateCast createCast)
        {
            try
            {
                var cast = _mapper.Map<Cast>(createCast);
                var createdCast = await _context.Add(cast);
                return CreatedAtAction(nameof(CreateCast), createdCast);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast([FromBody] UpdateCast updateCast)
        {
            try
            {
                var data = await _context.Get(updateCast.Id);
                if (data == null)
                    NotFound("Cast not found");
                _mapper.Map(updateCast, data);
                var updatedData = await _context.Update(data);
                return Ok(updatedData);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
            try
            {
                var data = await _context.Get(id);
                if (data == null)
                    NotFound($"Cast not found with id {id}");
                await _context.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
