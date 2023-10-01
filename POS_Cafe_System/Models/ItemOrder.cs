using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Models
{
    public class ItemOrder:ReactiveObject
    {
        public int Id { get; set; }
        [Reactive]
        public bool IsSelected { get; set; } = false;
        [Reactive]
        public int Count { get; set; } = 0;
        public string Name { get; set; }
        public byte[] ImageBytes { get; set; }
        public double Price { get; set; }
        public Bitmap Image { get; set; }

        public ItemOrder(int id, string name, double price, Bitmap image)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            ImageBytes = POS_Cafe_System.Commands.ImageConverter.BytesFromImage(image);

        }
        public ItemOrder(int id, string name, double price, byte[] imageBytes)
        {
            Id = id;
            Name = name;
            Price = price;
            ImageBytes = imageBytes;
            Image = POS_Cafe_System.Commands.ImageConverter.ImageFromBytes(imageBytes);
        }
    }
}
