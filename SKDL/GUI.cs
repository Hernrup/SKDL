using SKDLViewControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SKDL
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            FormView = FormViews.A; //simply change views like this
            fullscreen(null,null);
        }

        private void fullscreen(object sender, EventArgs e) {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public enum FormViews {
            A, B
        }
        private ViewA viewA; //user control with view a on it 
        private ViewB viewB; //user control with view b on it

        private FormViews _formView;
        public FormViews FormView {
            get {
                return _formView;
            }
            set {
                _formView = value;
                OnFormViewChanged(_formView);
            }
        }
        protected virtual void OnFormViewChanged(FormViews view) {
            //contentPanel is just a System.Windows.Forms.Panel docked to fill the form
            switch (view) {
                case FormViews.A:
                    if (viewA == null) viewA = new ViewA();
                    //extension method, you could use a static function.
                    this.panelContent.DockControl(viewA);
                    break;
                case FormViews.B:
                    if (viewB == null) viewB = new ViewB();
                    this.panelContent.DockControl(viewB);
                    break;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }
    }

    public static class PanelExtensions {
        public static void DockControl(this Panel thisControl, Control controlToDock) {
            thisControl.Controls.Clear();
            thisControl.Controls.Add(controlToDock);
            controlToDock.Dock = DockStyle.Fill;
            //controlToDock.Visible = true;
        }
    }
}
