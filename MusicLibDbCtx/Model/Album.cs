using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibDbCtx.Model
{
    public class Album:BaseModel
    {
        public string? Name { get; set; }
        public int YearReleased { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Song> Songs { get; set; }

    }
}
