using Microsoft.AspNetCore.Mvc;
using MusicLibDbCtx.Model;
using MusicLibFramework.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IAlbumService _albumService;

        string controllerName = "Album";

        public AlbumController(ILogger<AlbumController> logger,
                                IAlbumService service)
        {
            _logger = logger;
            _albumService = service;
        }


        // GET: api/<AlbumController>
        [HttpGet]
        public ActionResult GetAll()
        {
            string serviceName = "GetAll";
            try
            {
                List<Album> albums = _albumService.GetAll();

                return StatusCode(StatusCodes.Status200OK, albums);
            }
            catch (Exception exc)
            {
                _logger.LogError("Error calling {controllerName} for {serviceName}. Error: {message}", controllerName, serviceName, exc.Message);
                string uiErrMsg = $"Error calling {serviceName}.";
                return StatusCode(StatusCodes.Status500InternalServerError, uiErrMsg);
            }
        }

        // GET api/<AlbumController>/2010
        [HttpGet("{id}")]
        public ActionResult GetByReleaseYear(int releaseYear)
        {
            string serviceName = "GetByReleaseYear";
            try
            {
                List<Album> albums = _albumService.SearchByReleaseYear(releaseYear, out string errMsg);

                if (string.IsNullOrEmpty(errMsg))
                {
                    return StatusCode(StatusCodes.Status200OK, albums);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, errMsg);
                }
            }
            catch (Exception exc)
            {
                _logger.LogError("Error calling {controllerName} for {serviceName}. Error: {message}", controllerName, serviceName, exc.Message);
                string uiErrMsg = $"Error calling {serviceName}.";
                return StatusCode(StatusCodes.Status500InternalServerError, uiErrMsg);
            }
        }

        // GET api/<AlbumController>/rio
        [HttpGet("{name}")]
        public List<Album> SearchByName(string name)
        {
            List<Album> albums = new();

            return albums;
        }

        // POST api/<AlbumController>
        [HttpPost]
        public StatusCodeResult AddNew([FromBody] Album entity)
        {
            string serviceName = "AddNew";
            try
            {
                _albumService.AddNew(entity);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception exc)
            {
                _logger.LogError("Error calling {controllerName} for {serviceName}. Error: {Message}", controllerName, serviceName, exc.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Album entity)
        {
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}
