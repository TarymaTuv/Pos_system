using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Models
{
    public class ItemOrderForEmp : ItemOrder
    {
        public ItemOrderForEmp(int id, string name, double price, byte[] imageBytes) : base(id, name, price, imageBytes)
        {
        }
    }
}
