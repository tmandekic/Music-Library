using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicLibDbCtx.Model;

namespace MusicLibFramework.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        List<T> GetAll();
        List<T> GetByName(string name);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
