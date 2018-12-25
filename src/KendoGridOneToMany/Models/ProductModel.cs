using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoGridOneToMany.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            //this.Categories = new List<CategoryModel>
            //{
            //    new CategoryModel { Id = 1, Name = "Fruit" },
            //    new CategoryModel { Id = 2, Name = "Vegetables" },
            //    new CategoryModel { Id = 2, Name = "Frozen" }
            //};
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }

        public ICollection<CategoryModel> Categories { get; set; }

        public string DisplayCatogories
        {
            get
            {
                try
                {
                    return string.Join(", \n", this.Categories.Select(x => x.Name).ToList());
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}