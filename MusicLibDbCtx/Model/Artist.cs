using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibDbCtx.Model
{
    public class Artist:BaseModel
    {
        public string? Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
