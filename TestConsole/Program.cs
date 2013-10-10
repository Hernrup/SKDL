using Newtonsoft.Json;
using SKDL;
using SpotifyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine();
            Console.WriteLine("Authenticating...");

            try {

                var game = new Game();
                game.rounds.Add(new IntroRound());
                game.rounds.Add(new WordRound());
                game.rounds.Add(new ImageRound());
                game.rounds.Add(new LyricsRound());

                string output = JsonConvert.SerializeObject(game);
                Console.WriteLine(output);


                var gameOut = JsonConvert.DeserializeObject<Game>(output, new RoundConverter());
                gameOut.ToString();
            }
            catch (Exception z) {
                Console.WriteLine("Unexpected error:\r\n" + z.ToString());
            }
            Console.ReadLine();

           
        }
    }
}
