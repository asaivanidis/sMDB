using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sMDB.Data;
using sMDB.Models;

namespace sMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET api/<MoviesController>
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _context.Movies.ToListAsync());
        }

        // GET request to get a movie "api/<MoviesController>/{MovieId}"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        // POST request to add a movie "api/<MoviesController>/AddMovie"
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
        }

        // POST request to update a movie "api/<MoviesController>/UpdateMovie"
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.MovieId) return BadRequest();
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST request to delete a movie "api/<MoviesController>/DeleteMovie/{MovieId}"
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
