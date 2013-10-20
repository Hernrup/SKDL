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
    public partial class LyricsView : GenericView
    {
        private LyricsRound round;
        private SpotifyService.Service spotify;

        public LyricsView(Round round)
        {
           InitializeComponent();
           this.spotify = SpotifyService.Service.Instance;
            this.round = (LyricsRound)round;
            this.lbTrack.Text = "";
        }

        public void showTrack() {
            this.lbTrack.Text = string.Format("{0} - {1}", this.round.track.trackMetaData.artists[0].name, this.round.track.trackMetaData.name);
        }

        public void play() {
            this.spotify.play(this.round.track.uri);
        }

        public override Boolean handleKeyPress(Keys k) {
            switch (k) {
                case Keys.Enter:
                    this.play();
                    this.showTrack();
                    return true;
                case Keys.Space:
                    
                    return true;
            }
            return false;
        }
    }
}
