using System;
using System.Collections.Generic;
using ASP.NET_CORE_MVC.Models;
namespace ASP.NET_CORE_MVC.Services
{
    public class ProductServices : List<ProductModel>
    {
        public ProductServices()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel(){Id = 1,Name = "Iphone X", Price = 1000},
                new ProductModel(){Id = 2,Name = "Iphone Xyz", Price = 1200},
                new ProductModel(){Id = 3,Name = "Iphone X11111", Price = 3000},
            });
        }
    }
}