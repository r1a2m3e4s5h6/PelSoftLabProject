using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PelSoftLabTask.entities;
using PelSoftLabTask.Models;

namespace PelSoftLabTask.Controllers
{
	public class ProductController : Controller
	{
		private readonly PelSoftLabDbContext _db;
		IConfiguration _configuration;
		string connection;
        public ProductController(PelSoftLabDbContext db, IConfiguration configuration)
        {
			_db = db;
			_configuration = configuration;
			connection = configuration.GetConnectionString("defaultconnection");
        }
		public IActionResult Search()
		{
			ViewBag.products = _db.Products.ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Search(ProductModel productmodel)
		{
			// Call the stored procedure using DbContext
			if (productmodel.Conjunction == "AND")
			{
				ViewBag.results = _db.Products.FromSqlRaw("exec searchproducts {0}, {1}, {2}, {3}, {4}",
				productmodel.ProductName,
				productmodel.Size,
				productmodel.Price,
				productmodel.MfgDate,
				productmodel.Category).ToList();
			}
			else
			{
				ViewBag.results = _db.Products.FromSqlRaw("exec SearchProductsWithOR {0}, {1}, {2}, {3}, {4}",
					productmodel.ProductName,
					productmodel.Size,
					productmodel.Price,
					productmodel.MfgDate,
					productmodel.Category).ToList();
			}
			ViewBag.products = _db.Products.ToList();
			return View(productmodel);
		}
	}
}
