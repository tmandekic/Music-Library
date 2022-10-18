using Microsoft.AspNetCore.Mvc;
using MusicLibDbCtx.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        public ArtistController(ILogger<ArtistController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ArtistController>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            List<Artist> artists = new();

            
            return artists;
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public Artist Get(string artistName)
        {
            Artist artist = new Artist();

            return artist;
        }

        // POST api/<ArtistController>
        [HttpPost]
        public void Post([FromBody] string artistName)
        {
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string artistName)
        {
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
