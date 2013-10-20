using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using SKDL.Views;


namespace SKDL
{
    public partial class GUI : Form
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private GenericView _view;
        private Game _game;
        private int _roundIndex;
        private Boolean _isFullscreen;
        private SpotifyService.Service _spotify;

        public GenericView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                OnFormViewChanged(_view);
            }
        }

        public Game Game {
            get {
                return _game;
            }
            set {
                _game = value;
            }
        }

        public GUI(Game game)
        {
            InitializeComponent();
            
            
            _spotify = SpotifyService.Service.Instance;

            this._game = game;
            //_game = Game.load(gameName, _spotify);
            
            this.setupPlayerImages();
            this.setuppoints();
            this.setRound(0);

        }

        private void setupPlayerImages() {
            this.pbPicturePlayer1.Image = Image.FromFile(Path.Combine(_game.path,_game.player1.image));
            this.pbPicturePlayer2.Image = Image.FromFile(Path.Combine(_game.path, _game.player2.image));
        }

        private void setuppoints() {
            
        }

        public void setRound(int i)
        {
            if (i < _game.rounds.Count && i >= 0)
            {
                log.Debug("Round: " + i.ToString());
                this.View = _game.rounds[i].view;
                this.lbRoundType.Text = _game.rounds[i].friendlyName;
                this._roundIndex = i;
                this._spotify.pause();
            }
            else {
                log.Debug("Round index out of bounds: " + i.ToString());
            }
        }

        public void nextRound() {
            var n = _roundIndex+1;
            this.setRound(n);
        }
        public void prevRound()
        {
            var n = _roundIndex-1;
            this.setRound(n);
        }

        private void toggleFullscreen() {
            //invert variable
            this._isFullscreen = !this._isFullscreen;

            if (this._isFullscreen) {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            } else {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
            }
            
        }

  

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData) { 
                case Keys.Right:
                    nextRound();
                    return true;
                case Keys.Left:
                    prevRound();
                    return true;
                case Keys.Z:
                    this.givePoint(_game.player1, lbPoints1);
                    return true;
                case Keys.X:
                    this.givePoint(_game.player2, lbPoints2);
                    return true;
                case Keys.F11:
                    if(MessageBox.Show("You are about to exit the game. Are you sure?","Whaa!?",MessageBoxButtons.YesNo)== DialogResult.Yes){
                        this.Close();
                    }
                    return true;
                case Keys.F12:
                    this.toggleFullscreen();
                    return true;
                case Keys.Escape:
                    this._spotify.pause();
                    return true;

                //keys to send to view
                case Keys.Enter:
                case Keys.Space:
                case Keys.D1: 
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.P:
                case Keys.Up:
                case Keys.Down:
                
                    _game.rounds[_roundIndex].view.handleKeyPress(keyData);
                    return true;
            }

            // Call the base class
            //return base.ProcessCmdKey(ref msg, keyData);

            //disable all other keys
            return true;
        }

        protected void givePoint(Player p, Label lb) {
            p.points++;
            lb.Text = p.points.ToString();
        }

        protected virtual void OnFormViewChanged(GenericView view)
        {
            this.panelContent.DockControl(view);
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

    }

    public static class PanelExtensions {
        public static void DockControl(this Panel thisControl, Control controlToDock) {
            thisControl.Controls.Clear();
            thisControl.Controls.Add(controlToDock);
            controlToDock.Dock = DockStyle.Fill;
        }
    }
}
