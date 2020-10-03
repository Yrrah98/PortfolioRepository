using ControllerLibrary.EventHandling.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.EventHandling
{
    public interface IModelPublisher
    {

        void Subscribe(EventHandler<NewImageArgs> handler);

        void Unsubscribe(EventHandler<NewImageArgs> handler);
    }
}
