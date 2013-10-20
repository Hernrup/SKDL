using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SKDL
{
    public class LyricsRound : Round
    {
        public Lyrics lyrics { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public LyricsRound() { 
            this.type = "lyrics";
            this.friendlyName = "Textrundan";
        }

        

        public override string buildReferencePartial() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("===========================", this.type));
            sb.AppendLine(string.Format("Type: {0}", this.type));
            sb.AppendLine(string.Format("Track: {0} - {1}", this.track.trackMetaData.artists[0].name, this.track.trackMetaData.name));
            sb.AppendLine(string.Format("Question: {0}", this.question));
            sb.AppendLine(string.Format("Answer: {0}", this.answer));
            sb.AppendLine(string.Format("Original lyrics:"));
            sb.AppendLine(string.Format("{0}", this.lyrics.getTrimmedLyrics(this.lyrics.original)));
            sb.AppendLine(string.Format(""));
            sb.AppendLine(string.Format("Translated lyrics:"));
            sb.AppendLine(string.Format("Translated lyrics: {0}", this.lyrics.getTrimmedLyrics(this.lyrics.translated)));
            sb.AppendLine(string.Format("===========================", this.type));
            return sb.ToString();
        }
        
    }

    public class Lyrics
    {
        public string original { get; set; }
        public string translated { get; set; }

        public string getTrimmedLyrics(string s) {
            Regex trimmer = new Regex(@"\s+");
            return trimmer.Replace(s, " ");
        }
    }
}
