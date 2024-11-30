using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }


        // her ürünün mutlaka kategorisi olcak.
        public int CategoryId { get; set; } 
        //kategori tablosunun değerlerine , ürün üzerinden ulaşmak için ,  23.satır eklendi.

        // context.product.category.categoryname
        public virtual Category Category { get; set; }
        
        public List<Order> Orders { get; set; }

    }
}
