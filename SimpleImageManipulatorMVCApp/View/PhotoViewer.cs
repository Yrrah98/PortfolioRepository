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
        private Action<String, Image, int, float> _rotateACW;
        // VARIABLE to store an action to resize an image, takes string, img and int called _rotateCW
        private Action<String, Image, int, float> _rotateCW;
        // VARIABLE to store an unrotated version of the image so as not to cause any problems
        private Image _unrotatedImg;
        // VARIABLE to store the current rotation of the image
        private float _currentRotation;
        public PictureBox PB1 { get { return pictureBox1; } }

        public int FormNumber { get; set; }

        public PhotoViewer()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate pExecute, String pKey, int pFormNum, Action<String, Image,int, Size> resizeImage,
            Action<String, Image, int> flipH, Action<String, Image, int> flipV, Action<String, Image, int, float> rotateACW, Action<String, Image, int, float> rotateCW) 
        {
            _execute = pExecute;

            _imgKey = pKey;

            _resizeImage = resizeImage;

            FormNumber = pFormNum;

            _flipH = flipH;

            _flipV = flipV;

            _rotateACW = rotateACW;

            _rotateCW = rotateCW;

            _unrotatedImg = pictureBox1.Image;
        }

        private void FlipVertical_Click(object sender, EventArgs e)
        {
            ICommand command = new Command<String, Image, int>(_flipV, _imgKey, PB1.Image, FormNumber);

            _execute(command);

            UpdateImage();
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

            UpdateImage();
        }

        private void RotateR_Click(object sender, EventArgs e)
        {
            _currentRotation += 45f;

            ICommand command = new Command<String, Image, int, float>(_rotateCW, _imgKey, _unrotatedImg, FormNumber, _currentRotation);

            _execute(command);
        }

        private void RotateL_Click(object sender, EventArgs e)
        {
            _currentRotation -= 45f;

            ICommand command = new Command<String, Image, int, float>(_rotateACW, _imgKey, _unrotatedImg, FormNumber, _currentRotation);

            _execute(command);
        }

        /// <summary>
        /// METHOD: The purpose of this method is to update the unrotated image
        /// As rotating the same image causes problems. So we will save the image in a state of no rotation so 
        /// when we want we can apply rotation to the unrotated version of it.
        /// </summary>
        private void UpdateImage() 
        {
            _unrotatedImg = pictureBox1.Image;
        }
    }
}
