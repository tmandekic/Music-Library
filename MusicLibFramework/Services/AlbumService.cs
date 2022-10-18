using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibDbCtx.Model;
using MusicLibFramework.Repositories.Interfaces;
using MusicLibFramework.Services.Interfaces;

namespace MusicLibFramework.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ILogger<AlbumService> _logger;
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(ILogger<AlbumService> logger,
                            IAlbumRepository repository)
        {
            _logger = logger;
            _albumRepository = repository;
        }

        public void AddNew(Album entity)
        {
            _albumRepository.Create(entity);
        }

        public void Delete(Album entity)
        {
            _albumRepository.Delete(entity);
        }

        public List<Album> GetAll()
        {
            return _albumRepository.GetAll();
        }

        public List<Album> SearchByName(string name, out string errorMsg)
        {
            List<Album> searchResults = new();
            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMsg = "Album name cannot be empty";
            }
            else
            {
                searchResults = _albumRepository.GetByName(name);
            }
            return searchResults;
        }

        public List<Album> SearchByReleaseYear(int releaseYear, out string errorMsg)
        {
            List<Album> searchResults = new();
            errorMsg = string.Empty;
            int futureRYCutoff = DateTime.Now.Year + 1;

            if (releaseYear < 1800)
            {
                errorMsg = "Release year must be after 1800";
            }
            else if (releaseYear > futureRYCutoff)
            {
                errorMsg = $"Release year cannot be after {futureRYCutoff}";
            }
            else
            {
                searchResults = _albumRepository.GetByReleaseYear(releaseYear);
            }
            return searchResults;
        }

        public void Update(Album entity)
        {
            throw new NotImplementedException();
        }
    }
}
