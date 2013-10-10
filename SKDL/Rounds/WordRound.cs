using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{
    public class WordRound : Round
    {
        public List<string> words { get; set; }

        public WordRound() { 
            this.type = "words";
            this.words = new List<string>();
        }
    }
}
