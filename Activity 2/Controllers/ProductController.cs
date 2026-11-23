using Microsoft.AspNetCore.Mvc;
using MyMcvApp.Models;

namespace MyMcvApp.Controllers{
    public class ProductController : Controller{
        public IActionResult Details(){
            var myProduct = new Product(){
                Id = 1,
                Name = "Mechanical Keyboard",
                Price = 85.50m
            };
            return View(myProduct);
        }
    }
}