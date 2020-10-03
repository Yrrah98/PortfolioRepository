using ControllerLibrary.Commands;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleImageManipulatorMVCApp.Interfaces
{
    public interface IController
    {

        void Initialise(Form pPhotoLibrary, IModelDatabase pModelDatabase);

        void AddData(Size size);

        void Execute(ICommand command);

        void ExpandThumbnail(String key);
    }
}
