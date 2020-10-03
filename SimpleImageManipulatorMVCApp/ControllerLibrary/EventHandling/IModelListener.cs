using ControllerLibrary.EventHandling.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.EventHandling
{
    public interface IModelListener
    {

        void NewImageHandler(object source, NewImageArgs args);
    }
}
