﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{
    public class WordRound : Round
    {
        public List<Word> words { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public WordRound() { 
            this.type = "words";
            this.friendlyName = "Ordrundan";
        }

        public override string buildReferencePartial() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("===========================", this.type));
            sb.AppendLine(string.Format("Type: {0}", this.type));
            sb.AppendLine(string.Format("Track: {0} - {1}", this.track.trackMetaData.artists[0].name, this.track.trackMetaData.name));
            sb.AppendLine(string.Format("Question: {0}", this.question));
            sb.AppendLine(string.Format("Answer: {0}", this.answer));
            sb.AppendLine(string.Format("===========================", this.type));
            return sb.ToString();
        }
        
    }

    public class Word
    {
        public string text { get; set; }
        public Boolean bom { get; set; }
        public Boolean selected { get; set; }
    }
}
