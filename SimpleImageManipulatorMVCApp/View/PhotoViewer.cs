using ControllerLibrary;
using ControllerLibrary.Commands;
using ControllerLibrary.EventHandling;
using ControllerLibrary.EventHandling.Args;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class PhotoViewer : Form, IPhotoviewerSubscriber
    {
        // VARIABLE to store the execute command in the controller
        private ExecuteDelegate _execute;
        // VARIABLE to store the key relating to the image being viewed
        private String _imgKey;
        // VARIABLE to store an action to resize the image, takes String and Size parameters
        private Action<String, Image, int, Size> _resizeImage;
        // VARIABLE to store an action to resize an image, takes string, img and int called _flipV
        private Action<String, Image, int> _flipV;
        // VARIABLE to store an action to resize an image, takes string, img and int called _flipH
        private Action<String, Image, int> _flipH;
        // VARIABLE to store an action to resize an image, takes string, img and int called _rotateACW
        private Action<String, Image, int> _rotateACW;
        // VARIABLE to store an action to resize an image, takes string, img and int called _rotateCW
        private Action<String, Image, int> _rotateCW;


        public PictureBox PB1 { get { return pictureBox1; } }

        public int FormNumber { get; set; }

        public PhotoViewer()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate pExecute, String pKey, int pFormNum, Action<String, Image,int, Size> resizeImage,
            Action<String, Image, int> flipH, Action<String, Image, int> flipV, Action<String, Image, int> rotateACW, Action<String, Image, int> rotateCW) 
        {
            _execute = pExecute;

            _imgKey = pKey;

            _resizeImage = resizeImage;

            FormNumber = pFormNum;

            _flipH = flipH;

            _flipV = flipV;

            _rotateACW = rotateACW;

            _rotateCW = rotateCW;
        }

        private void FlipVertical_Click(object sender, EventArgs e)
        {
            ICommand command = new Command<String, Image, int>(_flipV, _imgKey, PB1.Image, FormNumber);

            _execute(command);
        }


        /// <summary>
        /// METHOD: OnImageEvent, a method to subscribe to the model database 
        /// so that the image can be sent to the form rather than it retrieving the image
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnImageEvent(object source, EventArgs args) 
        {
            pictureBox1.Image = (args as ImageArgs)._img;
        }

        private void FlipHorizontal_Click(object sender, EventArgs e)
        {
            ICommand command = new Command<String, Image, int>(_flipH, _imgKey, PB1.Image, FormNumber);

            _execute(command);
        }

        private void RotateR_Click(object sender, EventArgs e)
        {
            ICommand command = new Command<String, Image, int>(_rotateCW, _imgKey, PB1.Image, FormNumber);

            _execute(command);

            
        }

        private void RotateL_Click(object sender, EventArgs e)
        {
            ICommand command = new Command<String, Image, int>(_rotateACW, _imgKey, PB1.Image, FormNumber);

            _execute(command);
        }
    }
}
