using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        // 1'e çok ilişki
        public List<Product> Products { get; set; }
    }
}

// int x --> field 
// public int  y --> property
// void test(){ int z } z --> variable