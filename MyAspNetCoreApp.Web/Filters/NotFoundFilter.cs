using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly AppDbContext _contex;
        public NotFoundFilter(AppDbContext contex)
        {
            _contex = contex;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue = context.ActionArguments.Values.First();
            var id = (int)idValue;
            var hasProduct = _contex.Products.Any(x => x.Id == id);
            if (hasProduct == false)
            {
                context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel(){Errors=new List<string>() {$"Bu({id}) Id ye sahip ürün veritabanında yoktur." } });
            }
        }


    }
}
