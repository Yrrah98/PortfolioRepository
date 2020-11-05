using ControllerLibrary;
using ControllerLibrary.ImageProcessor;
using Model.Model_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IModelDatabase
    {
        IDictionary<String, IData> ImageDatabase { get; set; }

        void Initialise(ExecuteDelegate pExecute, ImageManipulator pImgManipulator);

        void AddData(String key, Size size);

        Image RetrieveImage(String key);

        #region ImageManipulation methods
        void ResizeImage(String key, int pFormCount, Size size);

        void ResizeImage(String key, Image img, int pFormCount, Size size);

        void FlipHorizontal(String key, Image img, int pFormCount);

        void FlipVertical(String key, Image img, int pFormCount);

        void RotateCW(String key, Image img, int pFormCount);

        void RotateACW(String key, Image img, int pFormCount); 
        #endregion
    }
}
