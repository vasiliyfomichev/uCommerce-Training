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
	public class BasketController : System.Web.Mvc.Controller
	{
		public ActionResult Index()
		{
			var basketModel = new PurchaseOrderViewModel();
		    basketModel = GetBasket();
			return View("/Views/Basket.cshtml", basketModel);
		}

		[HttpPost]
		public ActionResult Index(PurchaseOrderViewModel model)
		{
		    foreach (var orderLine in model.OrderLines)
		    {
		        var newQuantity = orderLine.Quantity;
		        if (model.RemoveOrderlineId == orderLine.OrderLineId)
		            newQuantity = 0;
		        TransactionLibrary.UpdateLineItem(orderLine.OrderLineId, newQuantity);
		    }
            TransactionLibrary.ExecuteBasketPipeline(); //important every time we update the basket
            //return Index();
            return RedirectToAction("Index");
		}

	    private PurchaseOrderViewModel GetBasket()
	    {
	        var order = TransactionLibrary.GetBasket(false).PurchaseOrder;
	        var basket = new PurchaseOrderViewModel();
            basket.OrderTotal = new Money(order.OrderTotal.GetValueOrDefault(), order.BillingCurrency).ToString();
	        foreach (var orderLine in order.OrderLines)
	        {
	            basket.OrderLines.Add(new OrderlineViewModel()
	            {
	                OrderLineId = orderLine.OrderLineId,
                    ProductName = orderLine.ProductName,
                    Quantity = orderLine.Quantity,
                    Sku = orderLine.Sku,
                    VariantSku = orderLine.VariantSku,
                    Total = new Money(orderLine.Total.GetValueOrDefault(), order.BillingCurrency).ToString()
	            });
	        }
            basket.OrderTotal = new Money(order.OrderTotal.GetValueOrDefault(), order.BillingCurrency).ToString();

	        return basket;
	    }
	}
}