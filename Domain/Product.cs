using System;

namespace Domain
{
    public class Product
    {
        string id;
        string name;
        string description;
        int quantity;
        int price;
        DateTime DatetimeCaducity; 

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime DateTimeCaducity { get; set; }

    }
}
