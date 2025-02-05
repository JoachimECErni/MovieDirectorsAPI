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
    public class ActorMovieController : ControllerBase
    {
        private readonly IActorMovieRepository<ActorMovie> _context;
        private readonly IMapper _mapper;

        public ActorMovieController(IActorMovieRepository<ActorMovie> context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetActorMovie(int id)
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
        public async Task<IActionResult> CreateActorMovie([FromBody] CreateActorMovie createActorMovie)
        {
            try
            {
                var actorMovie = _mapper.Map<ActorMovie>(createActorMovie);
                var createdActorMovie = await _context.Add(actorMovie);
                return CreatedAtAction(nameof(CreateActorMovie), createdActorMovie);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActorMovie([FromBody] UpdateActorMovie updateActorMovie)
        {
            try
            {
                var data = await _context.Get(updateActorMovie.Id);
                if (data == null)
                    NotFound("Data not found");
                _mapper.Map(updateActorMovie, data);
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
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                var data = await _context.Get(id);
                if (data == null)
                    NotFound($"Data not found with id {id}");
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
