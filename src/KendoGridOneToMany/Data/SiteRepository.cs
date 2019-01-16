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
                               new ProductModel() { Id = 1, Type = "Apples" , Categories = new List<CategoryModel>()},
                               new ProductModel() { Id = 2, Type = "Potatos", Categories = new List<CategoryModel>()},
                               new ProductModel() { Id = 3, Type = "Peas", Categories = new List<CategoryModel>()},
                               new ProductModel() { Id = 4, Type = "Beans", Categories = new List<CategoryModel>()},
                               new ProductModel() { Id = 5, Type = "Basil", Categories = new List<CategoryModel>()},
                               new ProductModel() { Id = 6, Type = "Yogurt", Categories = new List<CategoryModel>()},
                               new ProductModel() { Id = 7, Type = "Milk", Categories = new List<CategoryModel>()}
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

        public ProductModel UpdateProduct(ProductModel updatedProduct)
        {
            var product = products.Where(i => i.Id == updatedProduct.Id).First();
            var index = products.IndexOf(product);

            if (index != -1)
            {
                products[index] = updatedProduct;
            }

            var pd = products;

            return updatedProduct;
        }

        public List<ProductModel> AddCategory(ProductModel updatedProduct)
        {
            var product = products.Where(i => i.Id == updatedProduct.Id).First();
            var category = categories.Where(i => i.Id == updatedProduct.CategoryId).First();
            var index = products.IndexOf(product);

            if (index != -1)
            {
                products[index].Categories.Add(category);
            }

            return products;
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