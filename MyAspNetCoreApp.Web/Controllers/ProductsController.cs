using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

           var products= _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult pages(int page, int pagesize)
        {
            var products = _context.Products.Skip((page - 1) * pagesize).Take(pagesize).ToList();

            //ViewBag.page = page;
            //ViewBag.pagesize = pagesize;

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
      

        public IActionResult GetById(int productid)
        {

            var product = _context.Products.Find(productid);
            return View(_mapper.Map<ProductViewModel>(product));

        }


        public IActionResult Remove(int id)
        {

            var sil= _context.Products.Find(id);
            _context.Products.Remove(sil);
            _context.SaveChanges();
            TempData["Uyarı"] = "Ürün Başarıyla Silindi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
         
            return View();

        }
        [HttpPost]
        public IActionResult SaveProduct(ProductViewModel NewProduct)
        {

                _context.Products.Add(_mapper.Map<Product>(NewProduct));
                _context.SaveChanges();
                TempData["Uyarı"] = "Ürün Başarıyla Eklendi";
                return RedirectToAction("Index");
     
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);

        }
        [HttpPost]
        public IActionResult ProductUpdate(Product updateProduct)
        {
            
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["Uyarı"] = "Ürün Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }



    }
}
