
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
    public partial class PhotoLibrary : Form, IModelListener
    {
        // VARIABLE to store a strategy delegate, will call load image method in controller
        private ExecuteDelegate Execute;
        // VARIABLE to store an Action, called LoadImages
        private Action<Size> LoadImages;
        // VARIABLE to store an Action called ThumbnailDoubleClick
        private Action<String> ThumbnailDoubleClick;
        

        /// <summary>
        /// CONSTRUCTOR for PhotoLibrary form
        /// </summary>
        /// <param name="pExecute"> Execute delegate, to execute commands </param>
        /// <param name="pVoidDelegate"> Action parameter, to store the AddData method from the controller </param>
        public PhotoLibrary()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate pExecute, Action<Size> pLoadImages, Action<String> pDoubleClick) 
        {
            Execute = pExecute;

            LoadImages = pLoadImages;

            ThumbnailDoubleClick = pDoubleClick;
        }

        private void OpenPhotoBtn_Click(object sender, EventArgs e)
        {
            // INSTANTIATE a new Command, with a Size type parameter and passing in the VoidDelegate/Load Images delegate 
            // and a new Size variable, size set in constructor to desired size 
            ICommand command = new Command<Size>(LoadImages, new Size(56, 56));
            // CALL Execute delegate, passing in the command
            Execute(command);

        }

        private void Thumbnail_DoubleClick(object source, EventArgs args) 
        {
            ICommand ExpandThumbnail = new Command<String>(ThumbnailDoubleClick, (source as PictureBox).Name);

            Execute(ExpandThumbnail);
        }

        #region IModelListener methods
        public void NewImageHandler(object source, NewImageArgs args) 
        {

            // INSTANTIATE a new PictureBox in order to contain a thumbnail of the image
            PictureBox thumbnail = new PictureBox();
            // SET the picture boxes image to the image passed as event data
            thumbnail.Image = args._img;
            // SET the name of the image to the images key, so it can be accessed if needed
            thumbnail.Name = args._key;
            // SET the Width and Height of the image so that they appear the size you desire
            thumbnail.Size = new Size(56, 56);
            // ADD the picturebox to the flow layour panel
            ThumbnailArea.Controls.Add(thumbnail);
            // SET the thumbnail/pictureboxes double click event handler to the Thumbnail Double Click in here
            // A command will be run to expand the double clicked photo
            thumbnail.DoubleClick += Thumbnail_DoubleClick;
        }
        #endregion 
    }
}
