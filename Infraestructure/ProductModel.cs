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
        //    if(products == null)
        //    {
        //        throw new ArgumentException("Error, la caducidad no puede ser null");

        //    } else if(products.Length == 1)
        //    {
        //        return products;
        //    }
            
        //}

        //public Product[] GetProductsByRangoPrecio(decimal p1, decimal p2)
        //{

        //}

        public Product[] OrdenarByPrecio()
        {
            if(products == null)
            {
                throw new ArgumentException("Error, el producto es null");

            }else if (products.Length == 1)
            {
                return products;
            }
            Array.Sort(products, new Product.ProductPriceComparer());
            return products;
        }

        public Product FindById(int id)
        {
            int index = -1, i=0;
            foreach (Product product in products)
            {
                if(products[i].Id == id)
                {
                    index = i;
                    break;
                }
                i++;
            }
            return index < 0 ? null : products[index];
        }

        public bool Update(Product p)
        {
            bool success = false;
            int index = GetIndex(p);
            if (index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {p.Id} no existe");
            }

            products[index] = p;
            return !success;
        }
        public int GetIndex(Product p)
        {
            int index = -1, i = 0;
            foreach(Product product in products)
            {
                if(product.Id == p.Id)
                {
                    index = i;
                    break;
                }
                i++;
            }
            return index;
        }


        public bool Delete(Product p)
        {
            bool flag = false;
            int index = GetIndex(p);
            if (index < 0)
            {
                throw new ArgumentException("Error, el producto no existe en el inventario");
            }
            Product[] tmp = new Product[products.Length - 1];
            products[index] = products[products.Length - 1];
            Array.Copy(products, tmp, products.Length - 1);
            products = tmp;

            return !flag;
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
 