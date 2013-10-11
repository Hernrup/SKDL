using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SKDLViewControls;

namespace SKDL
{
    public class DataHandler
    {

        public static Game loadGame(string path) {
            var game = getDummyData();
            createViews(game);
            return game;
        }

        public static Game createViews(Game game) {
            foreach (var r in game.rounds) {
                r.view = getNewView(r.type);
            }

            return game;
        }

        private static UserControl getNewView(string type){
            switch (type)
            {
                case "intro":
                    return new ViewA();
                case "image":
                    return new ViewA();
                case "lyrics":
                    return new ViewA();
                case "words":
                    return new ViewA();
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


        public static Game getDummyData()
        {
            var game = new Game();
            game.rounds = new List<Round>() { 
                new IntroRound() { 
                     track = new Track(){uri="spotify:track:77o2IKTG6w7E8uKdCGij4b",position="0:0"}
                },
                new WordRound()
                {
                    track = new Track(){uri="spotify:track:77o2IKTG6w7E8uKdCGij4b",position="0:0"},
                    words = new List<Word>() { 
                            new Word(){text = "word1", bom = false},
                            new Word(){text = "word2", bom = false},
                            new Word(){text = "word3", bom = false},
                            new Word(){text = "word4", bom = false},
                            new Word(){text = "word5", bom = false},
                            new Word(){text = "word6", bom = false},
                        }
                },
                new WordRound()
                {
                    track = new Track(){uri="spotify:track:77o2IKTG6w7E8uKdCGij4b",position="0:0"},
                     words = new List<Word>() { 
                            new Word(){text = "word1", bom = false},
                            new Word(){text = "word2", bom = false},
                            new Word(){text = "word3", bom = false},
                            new Word(){text = "word4", bom = false},
                            new Word(){text = "word5", bom = false},
                        }
                },
                new ImageRound(){
                    track = new Track(){uri="spotify:track:77o2IKTG6w7E8uKdCGij4b",position="0:0"},
                    images = new List<string>() { 
                        "pic1.png",
                        "pic2.png",
                        "pic3.png",
                        "pic4.png",
                        "pic5.png",
                        "pic6.png"
                    }
                },
                new LyricsRound(){
                    track = new Track(){uri="spotify:track:77o2IKTG6w7E8uKdCGij4b",position="0:0"},
                    lyrics = new Lyric(){original="Some text original",translated="some text translated"}
                }
                
            };

            return game;
        }
    }
}
