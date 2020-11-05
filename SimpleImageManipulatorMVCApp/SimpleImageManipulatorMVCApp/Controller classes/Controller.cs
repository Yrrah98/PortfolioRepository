using Model.Interfaces;
using SimpleImageManipulatorMVCApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging.MetaData;
using ControllerLibrary.ImageProcessor;
using Model.Model_Classes;
using ControllerLibrary.EventHandling;
using ControllerLibrary.Commands;
using ControllerLibrary;
using System.Drawing;
using View;
using System.Diagnostics;

namespace SimpleImageManipulatorMVCApp.Controller_classes
{
    /// <summary>
    /// AUTHOR: Harry Jacob Jones
    /// VERSION: 0.1
    /// CREATION DATE: 30/08/2020
    /// CLASS PURPOSE: This is the controller class, this handles the events/requests of the UI
    /// returning the necessary data from the ModelDatabase
    /// </summary>
    public class Controller : IController
    {
        // VARIABLE to store a form, called photoLibrary
        private Form photoLibrary;
        // VARIABLE to store the database which contains all the images, called modelDatabase
        private IModelDatabase modelDatabase;
        // VARIABLE to store OpenFileDialog
        private OpenFileDialog fileDialog;
        // VARIABLE/COLLECTION of Forms which open to view an individual photo
        private IList<PhotoViewer> viewers;

        private int _formCount;

        /// <summary>
        /// CONSTRUCTOR for Controller class
        /// </summary>
        public Controller() 
        {

        }

        #region IController Methods
        /// <summary>
        /// METHOD: Initialise, method to initialise the database and the form window
        /// </summary>
        /// <param name="pPhotoLibrary"> The form which the user will see upon opening the application </param>
        /// <param name="pModelDatabase"> The database where all the photos are stored </param>
        public void Initialise(Form pPhotoLibrary, IModelDatabase pModelDatabase) 
        {
            // INITIALISE
            _formCount = 0;
            // SET local photoLibrary variable to form parameter passed in
            photoLibrary = pPhotoLibrary;
            // INITIALISE photoViewer collection
            viewers = new List<PhotoViewer>();
            // INITIALISE the photoLibrary, first cast as a type of PhotoLibrary
            (pPhotoLibrary as PhotoLibrary).Initialise(Execute, AddData, ExpandThumbnail);
            // SET local modelDatabase variable to IModelDatabase parameter passed in
            modelDatabase = pModelDatabase;
            // INITIALISE the modelDatabase
            modelDatabase.Initialise(Execute, new ImageManipulator());
            // SET OpenFileDialog variable to new OpenFileDialog
            fileDialog = new OpenFileDialog();
            // SET multi-select to true for fileDialog, to allow multiple fials to be selected at once
            fileDialog.Multiselect = true;

            ((IModelPublisher)modelDatabase).Subscribe((photoLibrary as IModelListener).NewImageHandler);

            // CALL to Application method Run, passing in the local photo library form
            Application.Run(photoLibrary);
        }
        #endregion

        #region Public methods
        public void AddData(Size size) 
        {
            if (!(fileDialog.ShowDialog() == DialogResult.Cancel))
            {
                // INSTANTIATE and SET a new list of strings, which is the strings returned from
                // the file dialog box
                IList<String> filesToLoad = fileDialog.FileNames;

                foreach (String file in filesToLoad)
                {
                    // CALL to AddData method in the modelDatabase, passing in the current string
                    // being iterated over
                    modelDatabase.AddData(file, size);

                }
            }
        }

        /// <summary>
        /// METHOD: ExpandThumbnail, takes a string/key as a parameter
        /// </summary>
        /// <param name="key"></param>
        public void ExpandThumbnail(String key) 
        {
            _formCount++;
            // INSTANTIATE a new PhotoViewer
            PhotoViewer pv = new PhotoViewer();
            // CALL Subscribe on IModelDatabase and subscribe the photoviewers OnImageEvent method, passing in the key and the 
            // size of the forms picture box
            (modelDatabase as IPhotoviewerPublisher).SubscribePhotoviewer((pv as IPhotoviewerSubscriber).OnImageEvent, key, _formCount, pv.PB1.Size);
            // CALL to initialise method on the PhotoViewer
            pv.Initialise(Execute, key, _formCount, modelDatabase.ResizeImage, modelDatabase.FlipHorizontal, modelDatabase.FlipVertical,
                modelDatabase.RotateACW, modelDatabase.RotateCW);
            // CALL to Show method on the form
            pv.Show();
        }

        public void Execute(ICommand command) 
        {
            // EXECUTE the command
            command.Execute();
        }
        #endregion
    }
}
