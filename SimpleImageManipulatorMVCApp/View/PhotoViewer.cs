using ControllerLibrary;
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
        private Action<String, int, Size> _resizeImage;


        public PictureBox PB1 { get { return pictureBox1; } }

        public int FormNumber { get; set; }

        public PhotoViewer()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate pExecute, String pKey, int pFormNum, Action<String, int, Size> resizeImage) 
        {
            _execute = pExecute;

            _imgKey = pKey;

            _resizeImage = resizeImage;

            FormNumber = pFormNum;
        }

        private void FlipVertical_Click(object sender, EventArgs e)
        {

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

    }
}
