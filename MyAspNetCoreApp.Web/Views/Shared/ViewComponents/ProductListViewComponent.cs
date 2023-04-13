using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;


namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type)
        {
            var viewmodels = _context.Products.Select(x => new ProductListComponentViewModel()
          {
              Name=x.Name,
              TextArea=x.TextArea,

          } ).ToList();

           
            if (type == 0)
            {
                return View("Default",viewmodels);
            }
            else
            {
                return View("Type2",viewmodels);
            }
        }

    }
}
