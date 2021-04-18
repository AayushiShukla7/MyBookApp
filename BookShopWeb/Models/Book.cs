using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopWeb.Models
{
    public class Book
    {
        //Good Practice - To have a simple model at the beginning. Start with 2-3 properties.
        //Later on, you can add more properties (after you have created and configured the basic CRUD operations for these 3 peoperties).
        //Don't start with too many properties --> It would make your life HELL to create CRUD with this many fields!!
        public string Name { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
    }
}