using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class VisitorViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public VisitorViewComponent(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitors= _context.Visitor.ToList();
            var visitorViewModels = _mapper.Map < List<VisitorViewModel>>(visitors) ;
            ViewBag.visitorViewModels = visitorViewModels;

            return View();
        }

    }
}
