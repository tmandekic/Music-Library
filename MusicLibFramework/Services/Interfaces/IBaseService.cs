using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibDbCtx.Model;

namespace MusicLibFramework.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseModel
    {
        List<T> GetAll();
        List<T> SearchByName(string name, out string errorMsg);
        void AddNew(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
