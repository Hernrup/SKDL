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

                SpotifyService.Service sp = new SpotifyService.Service();
                string trackUri = "spotify:track:2r1WyawAEquFyJc81xCv50";

                var status = sp.getStatus();
                if (status.track != null)
                    Console.WriteLine(string.Format("You're listening to {0} - {1} from the album '{2}'", status.track.trackResource.name, status.track.artistResource.name, status.track.albumResource.name));
                else
                    Console.WriteLine("You're not listening to any songs");

                Console.WriteLine(sp.getTrackInfo(trackUri).artists[0].name);

                sp.play(trackUri);

            }
            catch (Exception z) {
                Console.WriteLine("Unexpected error:\r\n" + z.ToString());
            }
            Console.ReadLine();

           
        }
    }
}
