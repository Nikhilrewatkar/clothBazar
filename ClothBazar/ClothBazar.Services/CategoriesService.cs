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
    public class CategoriesService
    {
        CBContext context = new CBContext();

        //List of Categories
        public List<Category> getCategories()
        {
           return context.Categories.ToList();
        }


        //Detail of Category
        public Category getCategory(int Id)
        {
            return context.Categories.Find(Id);
        }


        //Add new Category
        public void saveCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        //Update Category
        public void updateCategory(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Delete Category
        public void deleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
