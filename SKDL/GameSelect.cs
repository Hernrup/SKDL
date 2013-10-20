using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKDL {
    public partial class GameSelect : Form {
        
        public string selectedGame = null;
        public Game loadedGame = null;


        public void setStatus(string s) {
            this.lbStatus.Text = s;
        }
        
        public GameSelect() {
            InitializeComponent();
            this.populateList();
            this.setStatus("No game loaded");
        }

        private void populateList() {
            var games = DataHandler.getAvaliableGames();
            foreach (var g in games) {
                lvGames.Items.Add(new ListViewItem(g));
            }
        }

        public Game getSelectedGame() {
            return loadedGame;
        }

        private void SelectedIndexChanged(object sender, EventArgs e) {

            if (lvGames.SelectedItems.Count > 0) {
                this.selectedGame = lvGames.SelectedItems[0].Text;
                btLoad.Enabled = true;
            } else {
                btLoad.Enabled = false;
            }
        }

        private void btPlay_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void btReferense_Click(object sender, EventArgs e) {
            DataHandler.saveStringToChoosenFile(loadedGame.buildReference());
        }

        private void btLoad_Click(object sender, EventArgs e) {
            this.loadedGame = Game.load(this.selectedGame);
            this.btReferense.Enabled = true;
            this.btReferencePreview.Enabled = true;
            this.btPlay.Enabled = true;
            this.setStatus(string.Format("Game '{0}' is loaded", this.selectedGame));
        }

        private void brReferencePreview_Click(object sender, EventArgs e) {
            MessageBox.Show(loadedGame.buildReference());
        }
    }
}
