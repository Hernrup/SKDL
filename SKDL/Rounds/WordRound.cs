using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{
    public class WordRound : Round
    {
        public List<Word> words { get; set; }

        public WordRound() { 
            this.type = "words";
        }
        
        
    }

    public class Word
    {
        public string text { get; set; }
        public Boolean bom { get; set; }
    }
}
