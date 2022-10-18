using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibFramework.Repositories.Interfaces;
using MusicLibDbCtx.Model;
using MusicLibDbCtx;
using Microsoft.Extensions.Logging;

namespace MusicLibFramework.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private ILogger<AlbumRepository> _logger;
        private MusicLibDbContext _musicLibDbContext;

        string entityName = "Album";

        public AlbumRepository(ILogger<AlbumRepository> logger,
            MusicLibDbContext dbCtx)
        {
            _logger = logger;
            _musicLibDbContext = dbCtx;
        }

        public void Create(Album entity)
        {
            //using (_musicLibDbContext)
            //{
                _musicLibDbContext.Albums.Add(entity);
                try
                {
                    //entity.Created = DateTime.Now;    // this is handled in db
                    _musicLibDbContext.SaveChanges();
                }
                catch(Exception exc)
                {
                    // log exception
                    _logger.LogError("Error creating {entityName}: {name}. Error message: {Message}",entityName, entity.Name, exc.Message);

                    // throw exception up the stack
                    throw;
                }
            //}
        }

        public void Delete(Album entity)
        {
            _musicLibDbContext.Albums.Remove(entity);
            try
            {
                _musicLibDbContext.SaveChanges();
            }
            catch (Exception exc)
            {
                // log exception
                _logger.LogError("Error deleting {entityName}: {name}. Error message: {Message}", entityName, entity.Name, exc.Message);

                // throw exception up the stack
                throw;
            }
        }

        public List<Album> GetAll()
        {
            var albums = _musicLibDbContext.Albums.ToList();
            return albums;
        }

        public List<Album> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<Album>();
            }
            var albums = _musicLibDbContext.Albums
                        .Where(a => !string.IsNullOrWhiteSpace(a.Name) && 
                                    a.Name.Contains(name))
                        .ToList();
            return albums;
        }

        public List<Album> GetByReleaseYear(int releaseYear)
        {
            var albums = _musicLibDbContext.Albums
                        .Where(a => a.YearReleased == releaseYear)
                        .ToList();
            return albums;
        }

        public void Update(Album entity)
        {
            var oldAlbum = _musicLibDbContext.Albums.FirstOrDefault<Album>(p => p.Id == entity.Id);
            if (oldAlbum != null)
            {
                oldAlbum.YearReleased = entity.YearReleased;
                oldAlbum.Name = entity.Name;
                oldAlbum.LastModified = DateTime.Now;
            }
            _musicLibDbContext.Albums.Add(entity);
            try
            {
                _musicLibDbContext.SaveChanges();
            }
            catch (Exception exc)
            {
                // log exception
                _logger.LogError("Error updating {entityName}: {name}. Error message: {Message}", entityName, entity.Name, exc.Message);

                // throw exception up the stack
                throw;
            }
        }
    }
}
