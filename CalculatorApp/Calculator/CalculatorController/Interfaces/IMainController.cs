using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorController.Interfaces
{
    public interface IMainController
    {
        /// <summary>
        /// METHOD: Initialise, will send initialisation data through method parameters
        /// to the controller 
        /// </summary>
        void Initialise();
    }
}
