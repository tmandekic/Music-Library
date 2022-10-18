using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibDbCtx.Model;

namespace MusicLibFramework.Repositories.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        public List<Album> GetByReleaseYear(int releaseYear);
    }
}
