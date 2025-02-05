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
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository<Movie> _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository<Movie> context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await _context.GetAll();
                var movieDTO = _mapper.Map<List<MovieDTO>>(movies);

                return Ok(movieDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                var movie = await _context.Get(id);
                var movieDTO = _mapper.Map<MovieDTO>(movie);
                return Ok(movieDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovie createMovie)
        {
            try
            {
                var movie = _mapper.Map<Movie>(createMovie);
                var createdMovie = await _context.Add(movie);
                var movieDTO = _mapper.Map<MovieDTO>(createdMovie);
                return CreatedAtAction(nameof(GetMovie),new {id = movieDTO.Id},movieDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovie updateMovie)
        {
            try
            {
                var movie = await _context.Get(updateMovie.Id);
                if (movie == null)
                    NotFound("Movie not found");
                _mapper.Map(updateMovie, movie);
                var updatedMovie = await _context.Update(movie);
                var movieDTO = _mapper.Map<MovieDTO>(updatedMovie);
                return Ok(movieDTO);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var movie = await _context.Get(id);
                if (movie == null)
                    NotFound($"Movie not found with id {id}");
                await _context.Delete(id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionMessage.GetMessage(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
