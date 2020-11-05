using ControllerLibrary;
using ControllerLibrary.EventHandling;
using ControllerLibrary.EventHandling.Args;
using ControllerLibrary.ImageProcessor;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model_Classes
{
    /// <summary>
    /// AUTHOR: Harry Jacob Jones
    /// VERSION: 0.1
    /// CREATION DATE: 30/08/2020
    /// </summary>
    public class ModelDatabase : IModelDatabase, IModelPublisher, IPhotoviewerPublisher
    {
        #region Properties
        // The image databse, central focus for image manipulation application
        public IDictionary<String, IData> ImageDatabase { get; set; }
        #endregion

        private EventHandler<NewImageArgs> _handlers;

        private EventHandler<ImageArgs> _photoViewerHandlers;

        private IDictionary<String, IDictionary<int, EventHandler<ImageArgs>>> _photoViewHandlerCollection;

        private ExecuteDelegate _execute;

        private IImageManipulator _imgManipulator;
        // CONSTRUCTOR
        public ModelDatabase() 
        {
            // INITIALISE the ImageDatabase dictionary
            ImageDatabase = new Dictionary<String, IData>();
            // INITIALISE a Dictionary key string data IDictionary<int, EventHandler<ImageArgs>>
            _photoViewHandlerCollection = new Dictionary<String, IDictionary<int, EventHandler<ImageArgs>>>();
        }

        #region ImageManipulation methods

        /// <summary>
        /// METHOD: ResizeImage, a method which resizes the image found at the key to a specified size. 
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="size"></param>
        public void ResizeImage(String key, int pFormCount, Size size) 
        {
            // SET the image found at the key, to the resized image
            // REFACTOR -- this affects the quality of the image when sizing it back up, it will be better to send
            // the image returned by the resize method, opposed to altering the image and then sending.
            ImageDatabase[key].data = _imgManipulator.ResizeImage(size, ImageDatabase[key].data);
            // CALL to SendToPhotoViewer method
            SendToPhotoViewer(key, pFormCount);
        }

        /// <summary>
        /// OVERLOAD: Overloaded method of ResizeImage - used to resize an image and not affect the immutability of what is originally stored
        /// Essentially, passing around the same copy of an image for editing rather than the editing the image in the database
        /// </summary>
        /// <param name="img"></param>
        /// <param name="pFormCount"></param>
        /// <param name="size"></param>
        public void ResizeImage(String key, Image img, int pFormCount, Size size) 
        {

            SendToPhotoViewer(key, _imgManipulator.ResizeImage(size, img), pFormCount);
        }

        public void FlipVertical(String key, Image img, int pFormCount) 
        {
            SendToPhotoViewer(key, _imgManipulator.FlipVImage(img), pFormCount);
        }

        public void FlipHorizontal(String key, Image img, int pFormCount) 
        {
            SendToPhotoViewer(key, _imgManipulator.FlipHImage(img), pFormCount);
        }

        public void RotateACW(String key, Image img, int pFormCount, float degrees) 
        {
            SendToPhotoViewer(key, _imgManipulator.RotateImageACW(img, degrees), pFormCount);
        }

        public void RotateCW(String key, Image img, int pFormCount, float degrees)
        {
            SendToPhotoViewer(key, _imgManipulator.RotateImageCW(img, degrees), pFormCount);
        }
        #endregion

        #region IModelPublisher methods

        public void Subscribe(EventHandler<NewImageArgs> handler) 
        {
            // ADD an event handler for when new images are added to the collection
            _handlers += handler;
        }

        public void Unsubscribe(EventHandler<NewImageArgs> handler)
        {
            // REMOVE a handler 
            _handlers -= handler;
        }

        public void SubscribePhotoviewer(EventHandler<ImageArgs> handler, String key, int pFormCount, Size size)
        {
            // IF there is already a handler for that image
            if (_photoViewHandlerCollection.ContainsKey(key))
            {
                // ADD the new key and the new handler
                _photoViewHandlerCollection[key].Add(pFormCount, handler);
            }
            else 
            {
                // ELSE 
                // INSTANTIATE a new inner dictionary key int value EventHandler<ImageArgs>
                IDictionary<int, EventHandler<ImageArgs>> inner = new Dictionary<int, EventHandler<ImageArgs>>();
                // ADD 0 and then handler as key and data
                inner.Add(pFormCount, handler);
                // ADD the image key and the inner dictionary
                _photoViewHandlerCollection.Add(key, inner);
            }

            ImageDatabase[key].data = _imgManipulator.ResizeImage(size, ImageDatabase[key].data);

            SendToPhotoViewer(key, pFormCount);
        }

        // METHOD to be called when the user closes a window to remove the handler
        public void UnsubscribePhotoviewer(EventHandler<ImageArgs> handler, String key, int pFormCount) 
        {
            // REMOVE a handler from when an image is manipulated
            _photoViewHandlerCollection[key].Remove(pFormCount);
        }
        #endregion

        #region Public Methods

        public void Initialise(ExecuteDelegate pExecute, ImageManipulator pImgManipulator)
        {
            // SET local ImageFactory var to new ImageFactory
            _imgManipulator = pImgManipulator;
            // SET ExecuteDelegate in class to ExecuteDelegate passed in
            _execute = pExecute;
        }

        public void AddData(String file, Size size) 
        {
            // CREATE new IData variable, to store the image returned from passing the 
            // image manipulators load method the file passed as a parameter into this method
            IData data = new Data(_imgManipulator.LoadImage(file));
            // CREATE new Guid as string from Guid class
            // THEN ADD the string as a key along side the data passed in
            String key = Guid.NewGuid().ToString();
            // ADD the key and data to the database
            ImageDatabase.Add(key, data);
            // Local Image called img, so as not to edit the original image
            Image img = _imgManipulator.ResizeImage(size, ImageDatabase[key].data);
            // CALL to SendImage method, to broadcast the image to the listener
            SendImage(img, key);
        }

        public void SendImage(Image img, String key) 
        {
            // CREATE new NewImageArgs, passing in the image passed to this method as a parameter and the key
            // to access the image
            NewImageArgs args = new NewImageArgs(img, key);
            // CALL _handlers passing this in as the source and the args as parameters
            _handlers(this, args);
        }

        /*
         * REFACTOR -- Have this method take the String parameter
         * and an Image parameter. The image will be the returned image from the 
         * manipulation method. As opposed to changing/setting the image 
         * and then accessing the image from within this method.
         * The String parameter will stay so that it can get passed along so it is easy to manipulate the image in question.
         * May pose problems in terms of multiple rotations/edits on an image, as the base of it will be edited.
         * Cross that bridge when it comes to it.
         */
        public void SendToPhotoViewer(String key, int pFormCount) 
        {
            // INSTANTIATE a new ImageArgs, passing in the image from 
            // the image database found at the key
            ImageArgs args = new ImageArgs(ImageDatabase[key].data);
            // CALL to the handler 
            _photoViewHandlerCollection[key][pFormCount](this, args);
        }

        public void SendToPhotoViewer(String key, Image img, int pFormCount) 
        {
            ImageArgs args = new ImageArgs(img);

            _photoViewHandlerCollection[key][pFormCount](this, args);
        }

        /// <summary>
        /// METHOD: RetrieveImage a method which retrieves an image found by the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Image RetrieveImage(String key) 
        {
            // IF the key is contained in the dictionary
            if (ImageDatabase.ContainsKey(key))
                // RETURN the image found at the key
                return ImageDatabase[key].data;
            else 
                // ELSE return null
                return null;
        }
        #endregion

    }
}
