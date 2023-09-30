using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Commands
{
    public class ImageConverter
    {
        public static Bitmap ImageFromBytes(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                try
                {
                    return new Bitmap(stream);
                }
                catch
                {
                    return Properties.Resources.no_image;
                }
            }
        }
        public static byte[] BytesFromImage(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return stream.ToArray();
            }
        }
    }
}
