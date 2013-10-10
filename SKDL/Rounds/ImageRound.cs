using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL
{
    public class ImageRound : Round
    {
        public List<string>images { get; set; }

        public ImageRound() { 
            this.type = "image";
            this.images = new List<string>();
        }
    }
}
