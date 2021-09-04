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
        public string Id { get; set; }
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




    }
}
