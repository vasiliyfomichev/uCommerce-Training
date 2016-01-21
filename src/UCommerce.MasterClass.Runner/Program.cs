using System;
using System.Linq;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using NHibernate.Linq;
using UCommerce.EntitiesV2;
using UCommerce.Infrastructure;
using UCommerce.MasterClass.BusinessLogic.Queries;

namespace UCommerce.MasterClass.Integration
{
	class Program
	{
		static void Main(string[] args)
		{
			//log4net.Config.BasicConfigurator.Configure();
			
            //var order = ObjectFactory
            //    .Instance
            //    .Resolve<IRepository<PurchaseOrder>>()
            //    .Select(new LatestOrderQuery()).ToList();

            //var orders = UCommerce.EntitiesV2.PurchaseOrder.All().ToList();
            //var repository = ObjectFactory.Instance.Resolve<IRepository<PurchaseOrder>>();
            //var orders1 = repository.Select().ToList(); // same data as above
            //var sessionProvider = ObjectFactory.Instance.Resolve<ISessionProvider>();
            //var session = sessionProvider.GetSession();
            //var order2 = session.Query<PurchaseOrder>().Where(o=>o.Customer!=null).ToList(); // another way to get orders

            ////editing products
            //var product1 = session.Query<Product>().FirstOrDefault();
            //product1.Name = "hello world";
            //product1.Save();

            //var products = ObjectFactory.Instance.Resolve<IRepository<Product>>()
            //    .Select(new ProductByPropertiesQuery("ShowOnHomepage", "True")).ToList();

            //var orderLineRepository = ObjectFactory.Instance.Resolve<IRepository<OrderLine>>();
            //var productReposityrory = ObjectFactory.Instance.Resolve<IRepository<Product>>();


            //var query = from orderLine in orderLineRepository.Select()
            //    join product in productReposityrory.Select()
            //        on new
            //        {
            //            orderLine.Sku,
            //            orderLine.VariantSku

            //        } equals new
            //        {
            //            product.Sku,
            //            product.VariantSku
            //        }
            //    select product;
            //var result = query.ToList();

            ////deferred executed
            //var repo = ObjectFactory.Instance.Resolve<IRepository<PurchaseOrder>>();
            //var orders2 = repo.Select();

            //// requesting extra info 
            ////fetch customer to avoid loading multiple queries for each
            ////of the orders in the list.
            //orders2.Fetch(x => x.Customer);
            //orders2.FetchMany(x => x.OrderLines);

            //var result1 = orders.ToList();

            ////also deferred executed
            //var secondQuery = result1.AsQueryable();

            //foreach (var purchaseOrder in result1)
            //{
            //    if (purchaseOrder.Customer != null)
            //    {
            //        var customer = purchaseOrder.Customer;
            //        var firstName = customer.FirstName;
            //    }
            //}





		}
	}
}
