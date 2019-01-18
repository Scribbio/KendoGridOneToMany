using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KendoGridOneToMany.Models;
using KendoGridOneToMany.Data;
using Kendo;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace KendoGridOneToMany.Controllers
{
    public class HomeController : Controller
    {
        private Random random = new Random();
        private static SiteRepository siteRepository = new SiteRepository();

        public IActionResult Index()
        {
            ViewData["categories"] = siteRepository.GetAllCategories();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }

        public ActionResult GetProducts([DataSourceRequest] DataSourceRequest dsRequest)
        {
            var result = siteRepository.GetAllProducts();
            return this.Json(result.ToDataSourceResult(dsRequest));
        }

        public ActionResult CreateProduct([DataSourceRequest] DataSourceRequest dsRequest, ProductModel productModel)
        {
            //productModel.Id = random.Next(10, 23432);
            return this.Json(productModel);
        }


        public ActionResult UpdateCategory([DataSourceRequest] DataSourceRequest request, ProductModel productModel)
        {

            if (productModel != null && ModelState.IsValid)
            {
                var updated = siteRepository.AddCategory(productModel);

                if(updated == null)
                {
                    this.ModelState.AddModelError("111111", "Role is already assigned to user");
                }
            }

            return this.Json(siteRepository.GetAllProducts().ToDataSourceResult(request, this.ModelState));
        }


        public ActionResult GetNames()
        {
            return this.Json(new List<string> { "Sara", "John", "James" });

        }

        public JsonResult GetCategories()
        {
            var result = siteRepository.GetAllCategories();
            return Json(result);
        }


        public ActionResult AddCategories()
        {
            return this.Json(new List<string> { "", "John", "James" });
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, ProductModel productModel)
        {
            var product= siteRepository.GetProductById(productModel.Id);
            var categoryToRemove = product.Categories.SingleOrDefault(r => r.Id == productModel.CategoryId);
            if (categoryToRemove != null)
            {
                product.Categories.Remove(categoryToRemove);
                siteRepository.UpdateProduct(product);
            }
            else
            {
                this.ModelState.AddModelError("RoleNotExist", "CategoryModel is not assigned to user");
            }

            return this.Json(siteRepository.GetAllProducts().ToDataSourceResult(request, this.ModelState));
        }

        //private void CustomValidateModel(LocationViewModel model)
        //{
        //    var existingEntity = _repository.GetAll<Location>()
        //                                        .Where(o => o.ID != model.ID)
        //                                        .Where(o => o.DisplayName.Equals(model.DisplayName))
        //                                        .FirstOrDefault();

        //    if (existingEntity != null)
        //    {
        //        if (existingEntity.Deleted == false)
        //            ModelState.AddModelError("DisplayName", "Name already exists.");
        //        else
        //            ModelState.AddModelError("DisplayName", "Name '" + existingEntity.DisplayName + "' already exists in DB, but deleted.");
        //    }
        //}



    }
}
