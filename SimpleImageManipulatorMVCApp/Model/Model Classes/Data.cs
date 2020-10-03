using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model_Classes
{
    /// <summary>
    /// AUTHOR: Harry Jacob Jones /Yrrah98 (GitHub)
    /// VERSION: 0.1
    /// CREATION DATE: 30/08/2020
    /// CLASS PURPOSE: The purpose of this class is to store the images and only the images
    /// </summary>
    public class Data : IData
    {
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Data(Image pImg)
        {
            // SET data image as parameter image
            data = pImg;
        }

        #region Properties
        // Image, data property this is the central focus of the application
        public Image data { get; set; }
        #endregion
    }
}
