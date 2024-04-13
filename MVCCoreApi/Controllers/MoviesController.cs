using MVCCoreApiMovie.Models;
using MVCCoreApiMovie.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService) =>
            _movieService = movieService;


        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<List<Movie>> Get() =>
            await _movieService.GetAsync();

        // GET api/<MoviesController>/5
        [HttpGet("{_id}")]
        public async Task<ActionResult<Movie>> Get(string movieId)
        {
            var movie = await _movieService.GetAsync(movieId);

            if(movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<IActionResult> Post(Movie newmovie)
        {
            await _movieService.CreateAsync(newmovie);

            return CreatedAtAction(nameof(Get), new { id = newmovie.Id, title = newmovie.Title, year = newmovie.Year},
            newmovie);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{_id}")]
        public async Task<IActionResult> Update(string id, Movie updatedmovie)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            updatedmovie.Id = movie.Id;

            await _movieService.UpdateAsync(id, updatedmovie);

            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{_id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            await _movieService.RemoveAsync(id);

            return NoContent();
        }
    }
}
