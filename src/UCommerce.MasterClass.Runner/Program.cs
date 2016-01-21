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

		    var orders = UCommerce.EntitiesV2.PurchaseOrder.All().ToList();
		    var repository = ObjectFactory.Instance.Resolve<IRepository<PurchaseOrder>>();
		    var orders1 = repository.Select().ToList(); // same data as above
		    var sessionProvider = ObjectFactory.Instance.Resolve<ISessionProvider>();
		    var session = sessionProvider.GetSession();
		    var order2 = session.Query<PurchaseOrder>().Where(o=>o.Customer!=null).ToList(); // another way to get orders





		}
	}
}
