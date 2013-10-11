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

                var game = DataHandler.loadGame("");

                game = game;
            }
            catch (Exception z) {
                Console.WriteLine("Unexpected error:\r\n" + z.ToString());
            }
            Console.ReadLine();

           
        }
    }
}
