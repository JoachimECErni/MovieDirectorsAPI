using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Data.Repositories;
using MovieDirectorsAPI.Data.Repositories.Interfaces;
using MovieDirectorsAPI.Exceptions;

namespace MovieDirectorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorProfileController : ControllerBase
    {
        private readonly IBaseRepository<ActorProfile> _context;
        private readonly IMapper _mapper;

        public ActorProfileController(IBaseRepository<ActorProfile> context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActorProfiles()
        {
            try
            {
                var actors = await _context.GetAll();
                var actorDtos = _mapper.Map<List<ActorProfileDTO>>(actors);
                return Ok(actorDtos);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorProfile(int id)
        {
            try
            {
                var actorProfile = await _context.Get(id);
                var actorDTO = _mapper.Map<ActorProfileDTO>(actorProfile);
                return Ok(actorDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateActorProfile([FromBody] CreateActorProfile createActorProfile)
        {
            try
            {
                var actorProfile = _mapper.Map<ActorProfile>(createActorProfile);
                var createdActorProfile = await _context.Add(actorProfile);
                var actorProfileDTO = _mapper.Map<ActorProfileDTO>(createdActorProfile);
                return CreatedAtAction(nameof(CreateActor),new {id = actorProfileDTO.Id}, actorProfileDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActorProfile([FromBody] UpdateActorProfile updateActorProfile)
        {
            try
            {
                var actorProfile = await _context.Get(updateActorProfile.Id);
                if (actorProfile == null)
                    NotFound("Actor Profile not found");
                _mapper.Map(updateActorProfile, actorProfile);
                var updatedActor = await _context.Update(actorProfile);
                var actorProfileDTO = _mapper.Map<ActorProfileDTO>(updatedActor);
                return Ok(actorProfileDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteActorProfile(int id)
        {
            try
            {
                var actorProfile = await _context.Get(id);
                if (actorProfile == null)
                    NotFound($"Actor Profile not found with id {id}");
                await _context.Delete(id);
                return Ok(actorProfile);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
