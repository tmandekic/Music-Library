using Microsoft.AspNetCore.Mvc;
using MusicLibDbCtx.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        public SongController(ILogger<SongController> logger)
        {
            _logger = logger;
        }

        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            List<Song> songs = new();

            return songs;
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public Song Get(string songName)
        {
            Song song = new();

            return song;
        }

        // POST api/<SongController>
        [HttpPost]
        public void Post([FromBody] int trackNumber, string songName)
        {
            
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int songId, [FromBody] int trackNumber, string songName)
        {
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int songId)
        {
        }
    }
}
