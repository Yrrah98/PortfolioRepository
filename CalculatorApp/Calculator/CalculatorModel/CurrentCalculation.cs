using CalculatorModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculatorModel
{
    /// <summary>
    /// NAME: CurrentCalculation
    /// PURPOSE: This will be the model and will store the data of the current calculation before
    /// the reset button is pressed. Once the reset button has been pressed, calculation information will be passed 
    /// to the PreviousCalculationModel
    /// VERSION: v1
    /// AUTHOR: Harry Jacob Jones
    /// </summary>
    public class CurrentCalculation : IModelInterface
    {
        /// <summary>
        /// Constructor for CurrentCalculation class
        /// </summary>
        public CurrentCalculation() 
        {

        }
    }
}
