using ControllerLibrary.EventHandling.Args;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.EventHandling
{
    public interface IPhotoviewerPublisher
    {

        void SubscribePhotoviewer(EventHandler<ImageArgs> handler, String key, int pFormCount, Size size);

        void UnsubscribePhotoviewer(EventHandler<ImageArgs> handler, String key, int pFormCount);
    }
}
