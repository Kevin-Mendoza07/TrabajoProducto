using System;
using System.Collections.Generic;
using System.Text; 

namespace Domain
{
    public class Product
    {
        string id;
        string name;
        string description;
        int quantity;
        decimal price;
        DateTime caducityDate; 

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime CaducityDate { get; set; }

    }
}
