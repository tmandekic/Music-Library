using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibFramework.Repositories.Interfaces;
using MusicLibDbCtx.Model;

namespace MusicLibFramework.Repositories
{
    public class SongRepository : ISongRepository
    {
        public void Create(Song entity)
        {
            /*using (var context = new taxturkdb_devContext())
            {
                
            }*/
        }

        public void Delete(Song entity)
        {
            throw new NotImplementedException();
        }

        public List<Song> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Song> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Song entity)
        {
            throw new NotImplementedException();
        }
    }
}
