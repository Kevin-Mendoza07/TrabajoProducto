using Domain;
using System;

namespace Infraestructure
{
    public class ProductModel
    {
        private Product[] products; 

        public ProductModel()
        {

        }

        public void Add(Product product)
        {
            if (products ==null)
            {
                products = new Product[1];
                products[0] = product;
                return; 
            }

            Product[] tmp = new Product[products.Length + 1];
            Array.Copy(products, tmp, products.Length);
            tmp[tmp.Length - 1] = product;
            products = tmp;

        }

    }
}
