﻿using System;
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
        private SiteRepository siteRepository = new SiteRepository();

        public IActionResult Index()
        {
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


        public ActionResult UpdateProduct([DataSourceRequest] DataSourceRequest dsRequest, ProductModel productModel)
        {
            if (productModel != null && ModelState.IsValid)
            {
                var toUpdate = siteRepository.UpdateProducts(productModel);
            }
            else
            {
                this.ModelState.AddModelError("RoleAlreadyAssigned", "Role is already assigned to user");
            }

            //List<UserViewModel> allUsersViewModels = this.userService.GetUserList().ToList();
            //return this.Json(allUsersViewModels.ToDataSourceResult(request, this.ModelState));


            return this.Json(ModelState.ToDataSourceResult());
        }


        public ActionResult GetNames()
        {
            return this.Json(new List<string> { "Sara", "John", "James" });

        }

        public ActionResult GetCategories()
        {
            return this.Json(siteRepository.GetAllCategories());
        }

        public ActionResult AddCategories()
        {
            return this.Json(new List<string> { "", "John", "James" });
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest request, ProductModel productModel)
        {
            //var user = this.userService.GetByGid(userViewModel.Gid);
            //var roleToRemove = user.UserRoles.SingleOrDefault(r => r.Id == userViewModel.RoleId);
            //if (roleToRemove != null)
            //{
            //    user.UserRoles.Remove(roleToRemove);
            //    this.userService.Update(user);
            //}
            //else
            //{
            //    this.ModelState.AddModelError("RoleNotExist", "CategoryModel is not assigned to user");
            //}

            //List<UserViewModel> allUsersViewModels = this.userService.GetUserList().ToList();
            //return this.Json(allUsersViewModels.ToDataSourceResult(request, this.ModelState));

            return this.Json(null);
        }
    }
}