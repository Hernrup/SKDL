using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKDL.Views;

namespace SKDL
{

    public partial class Round
    {
        public string type { get; set; }
        public string friendlyName { get; set; }
        public Track track { get; set; }
        public Game game { get; set; }
        public GenericView view { get; set; }

        public virtual string buildReferencePartial() {
            return "";
        }
    }
}
