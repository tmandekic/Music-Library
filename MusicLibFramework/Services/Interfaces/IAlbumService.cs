using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibDbCtx.Model;

namespace MusicLibFramework.Services.Interfaces
{
    public interface IAlbumService //: IBaseService<Album>
    {
        List<Album> SearchByReleaseYear(int releaseYear, out string errorMsg);
        List<Album> GetAll();
        List<Album> SearchByName(string name, out string errorMsg);
        void AddNew(Album entity);
        void Update(Album entity);
        void Delete(Album entity);
    }
}
