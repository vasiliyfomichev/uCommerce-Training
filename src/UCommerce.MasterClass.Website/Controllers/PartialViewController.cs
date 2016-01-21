using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.MasterClass.Website.Models;

namespace UCommerce.MasterClass.Website.Controllers
{
	public class PartialViewController : System.Web.Mvc.Controller
	{
		public ActionResult CategoryNavigation()
		{
			var categoryNavigation = new CategoryNavigationViewModel();
		    categoryNavigation.Categories = MapUCommerceCategories(CatalogLibrary.GetRootCategories());
			return View("/views/PartialViews/CategoryNavigation.cshtml", categoryNavigation);
		}

	    private IList<CategoryViewModel> MapUCommerceCategories(ICollection<UCommerce.EntitiesV2.Category> uCommerceCategories)
	    {
	        var categoryList = new List<CategoryViewModel>();

	        foreach (var uCommerceCategory in uCommerceCategories)
	        {
	            categoryList.Add(new CategoryViewModel()
	            {
	                //Name = uCommerceCategory.Name,
                    Name = Extensions.CategoryExtensions.DisplayName(uCommerceCategory),
                    Url = "/store/category?category="+uCommerceCategory.CategoryId,
                    Categories = MapUCommerceCategories(UCommerce.Api.CatalogLibrary.GetCategories(uCommerceCategory)),

	            });
	        }
	        return categoryList;
	    }
	}
}