using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.ImageProcessor
{
    public interface IImageManipulator
    {

        Image LoadImage(String filePath);

        Image RotateImageACW(Image img, float degrees);

        Image RotateImageCW(Image img, float degrees);

        Image FlipHImage(Image img);

        Image FlipVImage(Image img);

        Image ResizeImage(Size size, Image img);

        Image ResizeImage(int width, int height, Image img);


    }
}
