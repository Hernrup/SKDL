using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;

namespace SKDL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Game selectedGame = null;

            GameSelect selectDialog = new GameSelect();
            selectDialog.ShowDialog(null);
            selectedGame = selectDialog.getSelectedGame();
            selectDialog.Dispose();

            if (selectedGame != null) {
                Application.Run(new GUI(selectedGame));
            }
        }


    }
}
