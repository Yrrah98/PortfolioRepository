using ControllerLibrary;
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

        void Initialise(ExecuteDelegate pExecute);

        void AddData(String key, Size size);

        Image RetrieveImage(String key);

        #region ImageManipulation methods
        void ResizeImage(String key, int pFormCount, Size size);

        void ResizeImage(String key, Image img,int pFormCount, Size size);
        #endregion
    }
}
