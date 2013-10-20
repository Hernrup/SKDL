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
    public partial class GenericView : UserControl
    {
        public GenericView()
        {
            InitializeComponent();
        }

        public virtual Boolean handleKeyPress(Keys k)
        {
            return true;
        }
    }
}
