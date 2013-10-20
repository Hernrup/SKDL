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
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public string path { get; set; }

        public Game() {
            
        }

        public void save(string name)
        {
            DataHandler.writeStringToFile(DataHandler.serialize(this),name);
        }

        public static Game load(string name)
        {
            return DataHandler.gameFromFile(name);
        }

        public string buildReference() {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (Round r in this.rounds) {
                if(r.type != "credits"){
                    sb.AppendLine(string.Format("Round {0}",++i));
                    sb.AppendLine(r.buildReferencePartial());
                }
            }

            return sb.ToString();
        }
    }

    public class Player{
        public string image {get;set;}
        public int points {get;set;}

        public Player() {
            points = 0;

        }
    }
}
