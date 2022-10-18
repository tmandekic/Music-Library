using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibDbCtx.Model
{
    public class Song:BaseModel
    {
        public string? Name { get; set; }
        public int Track { get; set; }
    }
}
