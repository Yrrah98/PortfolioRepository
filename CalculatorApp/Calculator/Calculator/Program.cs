using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorController.Interfaces;
using CalculatorController;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Default main initialisation stuff
            // could move to the controller, but this is fine here. 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Instantiate a new MainController, the program will enter here.
            IMainController controller = new MainController();

            controller.Initialise();

        }
    }
}
