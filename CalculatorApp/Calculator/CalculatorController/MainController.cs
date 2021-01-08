using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorController.Interfaces;
using CalculatorView;


namespace CalculatorController
{
    /// <summary>
    /// NAME: MainController
    /// PURPOSE: The MainController class will be where the program entry point
    /// and will also help manage the input from users
    /// VERSION: v1
    /// AUTHOR: Harry Jacob Jones
    /// </summary>
    public class MainController : IMainController
    {
        /// <summary>
        /// Constructor for the MainController class
        /// </summary>
        public MainController() 
        {
            // Does nothing as of yet
        }


        public void Initialise() 
        {
            Application.Run(new Calculator());
        }
    }
}
