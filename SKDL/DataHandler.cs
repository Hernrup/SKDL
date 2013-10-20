using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SKDL.Views;

namespace SKDL
{
    public class DataHandler
    {
        //public static string gamesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"SKDL","games");
        public static string gamesFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "games");

        public static string gameFileExtension = ".sing";
        public static string gameFile = "settings" + gameFileExtension;


        public static Game gameFromFile(string gameName) {
            var path = Path.Combine(gamesFolder, gameName, DataHandler.gameFile);
            var data = readStringFromFile(path);
            Game game = deserialize<Game>(data);
            
            game.path = Path.Combine(gamesFolder, gameName);
            game = getTrackMetaData(game);
            game.rounds.Add(new Round() { type = "credits" });
            game = createGameReference(game);
            game = createViews(game);
            
            return game;
        }


        public static Game getTrackMetaData(Game game) {
            foreach (var r in game.rounds) {
                if (r.track != null) {
                    r.track.trackMetaData = SpotifyService.Service.Instance.getTrackInfo(r.track.uri);
                }
            }

            return game;
        }

        public static Game createViews(Game game) {
            foreach (var r in game.rounds) {
                r.view = getView(r);
            }

            return game;
        }

        public static Game createGameReference(Game game) {
            foreach (var r in game.rounds) {
                r.game = game;
            }

            return game;
        }

        public static void writeStringToFile(string s, string gameName) {
            var path = Path.Combine(gamesFolder, gameName);
            Directory.CreateDirectory(path);
            using (StreamWriter outfile = new StreamWriter(Path.Combine(path, DataHandler.gameFile), true))
            {
                outfile.Write(s);
            }
        }

        public static void saveStringToChoosenFile(string s) {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Game.txt";
            savefile.Filter = "Text files (*.txt)|*.txt";
            if(savefile.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(savefile.FileName))
                    sw.WriteLine(s);
            }
        }

        public static string readStringFromFile(string file)
        {
            return File.ReadAllText(Path.Combine(gamesFolder, file));
        }

        public static List<string> getAvaliableGames() {
            var games = new List<string>();
            foreach (string folder in Directory.GetDirectories(DataHandler.gamesFolder, "*", SearchOption.TopDirectoryOnly)) {
                games.Add(Path.GetFileName(folder));
            }
            return games;
        }

        private static GenericView getView(Round round)
        {
            switch (round.type)
            {
                case "intro":
                    return new IntroView(round);
                case "image":
                    return new ImageView(round);
                case "lyrics":
                    return new LyricsView(round);
                case "words":
                    return new WordView(round);
                case "credits":
                    return new CreditsView(round);
                default:
                    throw new Exception("Round type could not be found");
            }
        }

        public static T deserialize<T>(string o) {
            return JsonConvert.DeserializeObject<T>(o, new RoundConverter());
        }

        public static string serialize<T>(T o)
        {
            return JsonConvert.SerializeObject(o);
        }


       

      
    }
}
