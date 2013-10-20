using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{
    public class ImageRound : Round
    {

        public List<boxImage> images { get; set; }

        public ImageRound() { 
            this.type = "image";
            this.friendlyName = "Bildrundan";
        }

        public override string buildReferencePartial() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("===========================", this.type));
            sb.AppendLine(string.Format("Type: {0}", this.type));
            sb.AppendLine(string.Format("===========================", this.type));
            return sb.ToString();
        }

    }

    public class boxImage {
        public string path { get; set; }
        public Boolean selected { get; set; }
    }
}
