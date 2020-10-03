using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.EventHandling.Args
{
    public class NewImageArgs : EventArgs
    {
        // Variable to store the image 
        public Image _img;
        // Variable to store the key for the image
        public String _key;


        public NewImageArgs(Image img, String key) 
        {
            _img = img;

            _key = key;
        }
    }
}
