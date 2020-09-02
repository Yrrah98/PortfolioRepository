using Model.Interfaces;
using Model.Model_Classes;
using SimpleImageManipulatorMVCApp.Controller_classes;
using SimpleImageManipulatorMVCApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace SimpleImageManipulatorMVCApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IController Controller = new Controller();
            IModelDatabase ModelDatabase = new ModelDatabase();
            Form PhotoLibrary = new PhotoLibrary();
            Controller.Initialise(PhotoLibrary, ModelDatabase);

        }
    }
}
