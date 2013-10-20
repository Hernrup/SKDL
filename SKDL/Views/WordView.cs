using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKDL.Views {
    public partial class WordView : GenericView {
        private WordRound round;
        private Dictionary<int, Label> boxes;
        private SpotifyService.Service spotify;

        public WordView(Round round) {
            InitializeComponent();
            this.spotify = SpotifyService.Service.Instance;
            this.round = (WordRound)round;
            this.boxes = new Dictionary<int, Label>(){
                {0,this.lbWord1},
                {1,this.lbWord2},
                {2,this.lbWord3},
                {3,this.lbWord4},
                {4,this.lbWord5},
                {5,this.lbWord6},
            };

            this.setup();

        }

        protected override void OnKeyDown(KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.D1:
                    this.selectBox(0);
                    break;
                case Keys.D2:
                    this.selectBox(1);
                    break;
            }
        }

        public void setup() {
            this.populateBoxes();
            this.lbTrack.Text = "";
        }

        public void populateBoxes() {
            for (var i = 0; i < boxes.Count; i++) {
                if (round.words.Count > i) {
                    this.formatBox(i);
                    boxes[i].Font = new Font(boxes[i].Font.FontFamily, 24);
                } else {
                    boxes[i].Text = "♪";
                    boxes[i].Font = new Font(boxes[i].Font.FontFamily, 72);
                }
            }
        }

        public void showTrack() {
            this.lbTrack.Text = string.Format("{0} - {1}", this.round.track.trackMetaData.artists[0].name, this.round.track.trackMetaData.name);
        }

        public void play() {
          this.spotify.play(this.round.track.uri);
        }

        public override Boolean handleKeyPress(Keys k) {
            switch (k) {
                case Keys.D1:
                    selectBox(0);
                    return true;
                case Keys.D2:
                    selectBox(1);
                    return true;
                case Keys.D3:
                    selectBox(2);
                    return true;
                case Keys.D4:
                    selectBox(3);
                    return true;
                case Keys.D5:
                    selectBox(4);
                    return true;
                case Keys.D6:
                    selectBox(5);
                    return true;
                case Keys.Enter:
                    this.play();
                    this.showTrack();
                    return true;
                case Keys.Space:
                   
                    return true;
            }
            return false;
        }

        private void selectBox(int index) {
            //invert selected property
            if (this.round.words.Count > index) {
                this.round.words[index].selected = true;
                this.formatBox(index);
            }
        }

        private void formatBox(int index) {
            var word = this.round.words[index];
            var box = this.boxes[index];
            if (!word.selected) {
                //normal formating
                box.Text = (index + 1).ToString();
                box.BackColor = Color.RoyalBlue;
            } else if (word.bom) {
                //bom formating
                box.Text = word.text;
                box.BackColor = Color.Crimson;
            } else {
                //correct formating
                box.Text = word.text;
                box.BackColor = Color.LimeGreen;
            }


        }

        private void lbTrack_Click(object sender, EventArgs e) {

        }


    }
}
