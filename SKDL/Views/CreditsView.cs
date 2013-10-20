using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKDL.Views
{
    public partial class CreditsView : GenericView
    {
        private Round round;
        private SpotifyService.Service spotify;

        public CreditsView(Round round)
        {
            InitializeComponent();
            this.spotify = SpotifyService.Service.Instance;
            this.round = round;

            this.lbCredits.Text = this.buildTrackCreditsString();
        }

        public string buildTrackCreditsString(){
            StringBuilder sb = new StringBuilder();
            foreach (var r in this.round.game.rounds) {
                if(r.track != null)
                    sb.AppendLine(string.Format("{0} - {1}", r.track.trackMetaData.artists[0].name, r.track.trackMetaData.name));
            }
            
            return sb.ToString();
        }




  
    }
}
