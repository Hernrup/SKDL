using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SKDL.Views
{
    public partial class ImageView : GenericView
    {
        private ImageRound round;
        private Dictionary<int, PictureBox> boxes;
        private SpotifyService.Service spotify;

        public ImageView(Round round) {
            InitializeComponent();
            this.spotify = SpotifyService.Service.Instance;
            this.round = (ImageRound)round;
            this.boxes = new Dictionary<int, PictureBox>(){
                {0,this.pictureBox1},
                {1,this.pictureBox2},
                {2,this.pictureBox3},
                {3,this.pictureBox4},
                {4,this.pictureBox5},
                {5,this.pictureBox6},
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
            this.populateBoxes(true);
            this.lbTrack.Text = "";
        }

        public void populateBoxes(Boolean isInitial) {
            for (var i = 0; i < boxes.Count; i++) {
                if (round.images.Count > i) {
                    this.formatBox(i, isInitial);
                }
            }
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
                case Keys.Space:
                    this.populateBoxes(false);
                    return true;
            }
            return false;
        }

        private void selectBox(int index) {
            //invert selected property
            if (this.round.images.Count > index && this.boxes[index].Image != null) {
                this.round.images[index].selected = !this.round.images[index].selected;
                this.formatBox(index,false);
            }
        }

        private void formatBox(int index, Boolean isInitial) {
            var img = this.round.images[index];
            var box = this.boxes[index];
            if (!img.selected && !isInitial) {
                //normal formating
                box.BackColor = Color.Black;
                box.Image = Image.FromFile(Path.Combine(round.game.path, img.path));
            } else {
                //correct formating
                box.BackColor = Color.RoyalBlue;
                box.Image = null;
            }


        }
    }
}
