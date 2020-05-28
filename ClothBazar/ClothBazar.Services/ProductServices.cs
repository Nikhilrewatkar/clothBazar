using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class ProductServices
    {
        CBContext context = new CBContext();

        //List of Products
        public List<Product> getProducts()
        {
            return context.Products.Include(x=>x.Category).ToList();
        }


        //Detail of Product
        public Product getProduct(int Id)
        {
            return context.Products.Find(Id);
        }


        //Add new Category
        public void saveProduct(Product product)
        {
            context.Entry(product.Category).State = EntityState.Unchanged;
            context.Products.Add(product);
            context.SaveChanges();
        }

        //Update Category
        public void updateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Delete Category
        public void deleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
