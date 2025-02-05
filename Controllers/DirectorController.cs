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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository<Director> _context;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepository<Director> context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            try
            {
                var directors = await _context.GetAll();
                var directorsDTO = _mapper.Map<List<DirectorDTO>>(directors);
                return Ok(directorsDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirector(int id)
        {
            try
            {
                var director = await _context.Get(id);
                var directorDTO = _mapper.Map<DirectorDTO>(director);
                return Ok(directorDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector([FromBody] CreateDirector createDirector)
        {
            try
            {
                var director = _mapper.Map<Director>(createDirector);
                var createdDirector = await _context.Add(director);
                var directorDTO = _mapper.Map<DirectorDTO>(createdDirector);
                return CreatedAtAction(nameof(GetDirector),new {id = directorDTO },directorDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
