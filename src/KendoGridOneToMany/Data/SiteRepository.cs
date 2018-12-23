namespace KendoGridOneToMany.Data
{
    using KendoGridOneToMany.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;

    using AutoMapper;


    public class SiteRepository
    {
        private static List<ProductModel> products;

        private static List<CategoryModel> categories;

        public SiteRepository()
        {
            products = new List<ProductModel>()
                           {
                               new ProductModel() { Id = 1, Type = "Apples" },
                               new ProductModel() { Id = 2, Type = "Potatos" },
                               new ProductModel() { Id = 3, Type = "Peas" },
                               new ProductModel() { Id = 4, Type = "Beans" },
                               new ProductModel() { Id = 5, Type = "Basil" },
                               new ProductModel() { Id = 6, Type = "Yogurt" },
                               new ProductModel() { Id = 7, Type = "Milk" }
                           };

            categories = new List<CategoryModel>()
                         {
                             new CategoryModel { Id = 1, Name = "Fruit" },
                             new CategoryModel { Id = 2, Name = "Fruit" },
                             new CategoryModel { Id = 3, Name = "Vegetables" },
                             new CategoryModel { Id = 4, Name = "Frozen" },
                             new CategoryModel { Id = 5, Name = "Legumes" },
                             new CategoryModel { Id = 6, Name = "Dairy" },
                             new CategoryModel { Id = 7, Name = "Herbs" },
                         };
        }

        public List<ProductModel> GetAllProducts()
        {
            return products;
        }

        public List<CategoryModel> GetAllCategories()
        {
            return categories;
        }

        public CategoryModel AddNewCategory(CategoryModel category)
        {
            categories.Add(category);
            return category;
        }

        public ProductModel UpdateProducts(ProductModel updatedProduct)
        {
            var product = products.Where(c => c.Id == updatedProduct.Id).FirstOrDefault();
            product = updatedProduct;
            return product;
        }

        public CategoryModel GetCategoryById(int iD)
        {
            var category = categories.Where(c => c.Id == iD).FirstOrDefault();
            return category;
        }

        public ProductModel GetProductById(int iD)
        {
            var product = products.Where(c => c.Id == iD).FirstOrDefault();
            return product;
        }
    }
}