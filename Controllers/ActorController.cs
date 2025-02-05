using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Data.Repositories;
using MovieDirectorsAPI.Data.Repositories.Interfaces;
using MovieDirectorsAPI.Exceptions;

namespace MovieDirectorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository<Actor> _context;
        private readonly IMapper _mapper;

        public ActorController(IActorRepository<Actor> context = null, IMapper mapper = null, IBaseRepository<Director> directorContext = null)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            try
            {
                var actors = await _context.GetAll();
                var actorDtos = _mapper.Map<List<ActorDTO>>(actors);
                return Ok(actorDtos);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor(int id)
        {
            try
            {
                var actor = await _context.Get(id);
                var actorDTO = _mapper.Map<ActorDTO>(actor);
                return Ok(actorDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] CreateActor createActor)
        {
            try
            {
                var actor = _mapper.Map<Actor>(createActor);
                var createdActor = await _context.Add(actor);
                var actorDTO = _mapper.Map<ActorDTO>(createdActor);
                return CreatedAtAction(nameof(CreateActor),new {id = actorDTO.Id},actorDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActor([FromBody] UpdateActor updateActor)
        {
            try
            {
                var actor = await _context.Get(updateActor.Id);
                if (actor == null)
                    NotFound("Actor not found");
                _mapper.Map(updateActor, actor);
                var updatedActor = await _context.Update(actor);
                var actorDTO = _mapper.Map<ActorDTO>(updatedActor);
                return Ok(actorDTO);
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
                var actor = await _context.Get(id);
                if (actor == null)
                    NotFound($"Actor not found with id {id}");
                await _context.Delete(id);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
