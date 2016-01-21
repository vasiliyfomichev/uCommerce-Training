﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.MasterClass.Website.Models;

namespace UCommerce.MasterClass.Website.Controllers
{
	public class PreviewController : System.Web.Mvc.Controller
	{
		public ActionResult Index()
		{
			PurchaseOrderViewModel model = MapOrder();

			return View("/Views/preview.cshtml", model);
		}

		private PurchaseOrderViewModel MapOrder()
		{
		    var basket = TransactionLibrary.GetBasket(false).PurchaseOrder;
			var basketModel = new PurchaseOrderViewModel
			{
			    SubTotal = new Money(basket.SubTotal.GetValueOrDefault(), basket.BillingCurrency).ToString(),
			    ShippingTotal = new Money(basket.ShippingTotal.GetValueOrDefault(), basket.BillingCurrency).ToString(),
			    PaymentTotal = new Money(basket.PaymentTotal.GetValueOrDefault(), basket.BillingCurrency).ToString(),
			    DiscountTotal = new Money(basket.DiscountTotal.GetValueOrDefault(), basket.BillingCurrency).ToString(),
			    TaxTotal = new Money(basket.TaxTotal.GetValueOrDefault(), basket.BillingCurrency).ToString(),
                OrderTotal = new Money(basket.OrderTotal.GetValueOrDefault(), basket.BillingCurrency).ToString()
			};

		    foreach (var orderLine in basket.OrderLines)
		    {
                basketModel.OrderLines.Add(new OrderlineViewModel()
		        {
		            OrderLineId = orderLine.OrderLineId,
                    ProductName = orderLine.ProductName,
                    Sku = orderLine.Sku,
                    VariantSku = orderLine.VariantSku,
                    Quantity = orderLine.Quantity,
                    Total = new Money(orderLine.Total.GetValueOrDefault(), basket.BillingCurrency).ToString()
		        });
		    }

		    
			return basketModel;
		}
		
		[HttpPost]
		public ActionResult Post()
		{
            TransactionLibrary.RequestPayments();
			return View("/Views/Complete.cshtml");
		}
	}
}