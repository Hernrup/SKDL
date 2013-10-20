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
    public partial class IntroView : GenericView
    {
        private Round round;
        private SpotifyService.Service spotify;
        private Boolean intoPlayed;

        public IntroView(Round round)
        {
            InitializeComponent();
            this.spotify = SpotifyService.Service.Instance;
            this.round = round;
            this.intoPlayed = false;
            this.lbTrack.Text = "";
        }

        public void play() {
            this.spotify.play(this.round.track.uri);
        }

        public void showTrack() {
            this.lbTrack.Text = string.Format("{0} - {1}", this.round.track.trackMetaData.artists[0].name, this.round.track.trackMetaData.name);
        }

        public override Boolean handleKeyPress(Keys k) {
            switch (k) {
                case Keys.Enter:
                    if(this.intoPlayed)
                        showTrack();
                    return true;
                case Keys.Space:
                    play();
                    this.intoPlayed = true;
                    return true;
            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {

        }

        private void lbTrack_Click(object sender, EventArgs e) {

        }

        
    }
}
