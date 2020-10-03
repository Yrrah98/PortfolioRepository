using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// METHOD: Execute method for the command pattern
        /// </summary>
        void Execute();
    }
}
