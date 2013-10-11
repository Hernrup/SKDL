using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{
    public class LyricsRound : Round
    {
        public Lyric lyrics { get; set; }

        public LyricsRound() { 
            this.type = "lyrics";
        }

        
    }

    public class Lyric
    {
        public string original { get; set; }
        public string translated { get; set; }
    }
}
