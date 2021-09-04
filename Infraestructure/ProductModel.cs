using Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
            if ( product == null)
            {
                throw new ArgumentException("Error, producto no puede ser null.");
            }

            if(products == null)
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

        public Product[] GetProducts()
        {
            return products;
        }
        //public bool Update(Product p)
        //{
        //    bool success = false;
        //    int index = GetIndex(p);
        //    if(index < 0)
        //    {
        //        throw new ArgumentException($"Error, producto con codigo {p.Codigo} no existe");
        //    }

        //    products[index] = p;
        //    return !success;
        //}
        //public int GetIndex(Product p)
        //{
        //    return;
        //}


        //public bool Delete(Product p)
        //{
        //    bool flag = false;
        //    int index = GetIndex(p);
        //    if (index < 0)
        //    {
        //        throw new ArgumentException("");
        //    }
        //}


        public class ProductPriceComparer : IComparer<Product>
        {
            public int Compare(Product p1, Product p2)
            {
                
                if(p1 == null || p2 == null)
                {
                    throw new ArgumentException("Error, los valores no pueden ser null");

                } else if(p1.Price > p2.Price)
                {
                    return 1;

                } else if(p1.Price < p2.Price)
                {
                    return -1;

                } else
                {
                    return 0;
                }
            }
        }


        //public void Delete(Product product)
        //{

        //}

        //Ejercicio
        //Add, Update, Delete, FindById
        //Convertir y retornar como Json
        //Agregar ComboBoxs para busqueda
        //Agregar RichTextBox para mostrar informacion
    }
}
 