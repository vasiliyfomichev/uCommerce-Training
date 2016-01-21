using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.MasterClass.Website.Models;

namespace UCommerce.MasterClass.Website.Controllers
{
	public class ShippingController : System.Web.Mvc.Controller
	{
		public ActionResult Index()
		{
			var shipping = new ShippingViewModel();
            shipping.AvailableShippingMethods = new List<SelectListItem>();

		    var shippingCountry = TransactionLibrary.GetShippingInformation().Country;
		    var availableShippingMethods = TransactionLibrary.GetShippingMethods(shippingCountry);

		    var selectedShippingMethod = TransactionLibrary.GetBasket(false).PurchaseOrder.Shipments.FirstOrDefault();
		    foreach (var availableShippingMethod in availableShippingMethods)
		    {
		        shipping.AvailableShippingMethods.Add(new SelectListItem()
		        {
		            Selected = selectedShippingMethod!=null 
                    && selectedShippingMethod.ShippingMethod.Id == availableShippingMethod.ShippingMethodId,
                    Text = availableShippingMethod.Name,
                    Value = availableShippingMethod.ShippingMethodId.ToString()
		        });
		    }


			return View("/Views/Shipping.cshtml", shipping);
		}

		[HttpPost]
		public ActionResult Index(ShippingViewModel shipping)
		{
            TransactionLibrary.CreateShipment(shipping.SelectedShippingMethodId, overwriteExisting:true);
            TransactionLibrary.ExecuteBasketPipeline();
			return Redirect("/store/payment");
		}
	}
}