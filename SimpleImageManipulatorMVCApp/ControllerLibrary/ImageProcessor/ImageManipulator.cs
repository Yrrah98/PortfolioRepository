using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary.ImageProcessor
{
    public class ImageManipulator : IImageManipulator
    {
        private ImageFactory _imageFactory;

        private float _rotateVal;

        public ImageManipulator() 
        {
            _imageFactory = new ImageFactory(preserveExifData:false);

            _rotateVal = 45f;
        }

        public Image FlipHImage(Image img)
        {
            return _imageFactory.Load(img)
                .Flip()
                .Image;
        }

        public Image FlipVImage(Image img)
        {
            return _imageFactory.Load(img)
                .Flip(true)
                .Image;
        }

        public Image LoadImage(string filePath)
        {
            return _imageFactory.Load(filePath)
                .Image;
        }

        public Image ResizeImage(Size size, Image img) 
        {
            return _imageFactory.Load(img)
                .Resize(size)
                .Image;
        }

        public Image ResizeImage(int width, int height, Image img) 
        {
            return _imageFactory.Load(img)
                .Resize(new Size(width, height))
                .Image;
        }

        public Image RotateImageACW(Image img, float degrees)
        {
            return _imageFactory.Load(img)
                .Rotate(degrees)
                .Image;
        }

        public Image RotateImageCW(Image img, float degrees)
        {
            return _imageFactory.Load(img)
                .Rotate(degrees)
                .Image;
        }
    }
}
