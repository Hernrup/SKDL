using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{

    public class Game
    {
        public List<Round> rounds { get; set; }

        public Game() {
            rounds = new List<Round>();
        }
    }
}
