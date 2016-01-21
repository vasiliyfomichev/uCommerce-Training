using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;
using UCommerce.MasterClass.Website.Models;
using UCommerce.Runtime;

namespace UCommerce.MasterClass.Website.Controllers
{
	public class CategoryController : System.Web.Mvc.Controller
	{
		public ActionResult Index()
		{
			var categoryViewModel = new CategoryViewModel();
		    var currentCategory = UCommerce.Runtime.SiteContext.Current.CatalogContext.CurrentCategory;
		    categoryViewModel.Name = currentCategory.DisplayName();
		    categoryViewModel.Description = currentCategory.Description();

		    categoryViewModel.Products = MapProducts(CatalogLibrary.GetProducts(currentCategory));

			return View("/views/category.cshtml",categoryViewModel);
		}

	    private IList<ProductViewModel> MapProducts(ICollection<Product> uCommerceProductsToMap)
	    {
	        var products = new List<ProductViewModel>();
	        foreach (var uCommerceProduct in uCommerceProductsToMap)
	        {
	            products.Add(new ProductViewModel()
	            {
	                Sku = uCommerceProduct.Sku,
                    Name = uCommerceProduct.DisplayName(),
                    LongDescription = uCommerceProduct.LongDescription(),
                    Variants = MapProducts(uCommerceProduct.Variants),
                    VariantSku = uCommerceProduct.VariantSku,
                    PriceCalculation = UCommerce.Api.CatalogLibrary.CalculatePrice(uCommerceProduct),
                    Url = "/store/product?product="+uCommerceProduct.Id
	            });
	        }

	        return products;
	    }
	}
}