using Domain.enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Product
    {
        string id;
        string name;
        string description;
        int quantity;
        decimal price;
        DateTime caducityDate; 

        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public int Quantity { get; set; }
        [JsonProperty]
        public decimal Price { get; set; }
        [JsonProperty]
        public DateTime CaducityDate { get; set; }
        [JsonProperty]
        public UnitMeasure UnitMeasure { get; set; }
        public Search Search { get; set; }

        public class ProductPriceComparer : IComparer<Product>
        {
            public int Compare(Product p1, Product p2)
            {

                if (p1 == null || p2 == null)
                {
                    throw new ArgumentException("Error, los valores no pueden ser null");

                }
                else if (p1.Price > p2.Price)
                {
                    return 1;

                }
                else if (p1.Price < p2.Price)
                {
                    return -1;

                }
                else
                {
                    return 0;
                }
            }
        }





    }
}
