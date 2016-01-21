﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCommerce.MasterClass.Website.Models
{
	public class AddressDetailsViewModel
	{
		public AddressDetailsViewModel()
		{
			ShippingAddress = new AddressViewModel();
			BillingAddress = new AddressViewModel();
			AvailableCountries = new List<SelectListItem>();
		}
		public AddressViewModel ShippingAddress { get; set; }

		public AddressViewModel BillingAddress { get; set; }

		public IList<SelectListItem> AvailableCountries { get; set; }
	}
}