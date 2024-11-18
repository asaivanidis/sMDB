using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMDb.Data;
using SMDb.Models;

namespace SMDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<MoviesController> _logger;
        private readonly Cloudinary _cloudinary; // Cloudinary API client

        public MoviesController(MovieDbContext context, ILogger<MoviesController> logger, IConfiguration config)
        {
            _logger = logger;
            _context = context;

            var account = new Account(
           config["Cloudinary:CloudName"],
           config["Cloudinary:ApiKey"],
           config["Cloudinary:ApiSecret"]
       );
            _cloudinary = new Cloudinary(account);
        }

        // GET request to get all movies api/<MoviesController>
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            _logger.LogInformation("Handling GET request for movies list");
            return Ok(await _context.Movies.ToListAsync());
        }

        // GET request to get a movie "api/<MoviesController>/{MovieId}"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            _logger.LogInformation("Handling GET request for specific movie info");

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        // POST request to add a movie "api/<MoviesController>/AddMovie"
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {

            _logger.LogInformation("Handling POST request for adding a movie");
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
        }

        // POST request to update a movie "api/<MoviesController>/UpdateMovie"
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            _logger.LogInformation("Handling PUT request for updating movie");
            if (id != movie.MovieId) return BadRequest();
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST request to delete a movie "api/<MoviesController>/DeleteMovie/{MovieId}"
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            _logger.LogInformation("Handling DELETE request for removing a movie");

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST request to upload images to cloudinary
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required");
            }
            System.Diagnostics.Debug.WriteLine("uploading image");
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Folder = "movies"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            System.Diagnostics.Debug.WriteLine(uploadResult.SecureUrl.ToString());
            return Ok(new { Url = uploadResult.SecureUrl.ToString() });
        }
    }
}
