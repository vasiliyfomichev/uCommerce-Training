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
	public class ProductController : System.Web.Mvc.Controller
	{
		public ActionResult Index()
		{
			ProductViewModel productModel = new ProductViewModel();

		    var currentProduct = Runtime.SiteContext.Current.CatalogContext.CurrentProduct;
		    productModel = MapProduct(currentProduct);
		    
			return View("/views/product.cshtml", productModel);
		}


	    private ProductViewModel MapProduct(Product product)
	    {
            var productModel = new ProductViewModel
            {
                Sku = product.Sku,
                VariantSku = product.VariantSku,
                LongDescription = product.LongDescription(),
                Name = product.DisplayName(),
                PriceCalculation = CatalogLibrary.CalculatePrice(product)
            };

	        foreach (var variant in product.Variants)
	        {
	            productModel.Variants.Add(MapProduct(variant));
	        }
	        return productModel;
	    }

		[HttpPost]
		public ActionResult Index(AddToBasketViewModel model)
		{
            TransactionLibrary.AddToBasket(1, model.Sku, model.VariantSku);
			return Index();
		}



	}
}