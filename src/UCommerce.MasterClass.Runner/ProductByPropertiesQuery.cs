using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using UCommerce.EntitiesV2;
using UCommerce.EntitiesV2.Queries;
using Product = UCommerce.Documents.Product;

namespace UCommerce.MasterClass.Integration
{
    public class ProductByPropertiesQuery : ICannedQuery<UCommerce.EntitiesV2.Product>
    {
        private readonly string _fieldName;
        private readonly string _propertyValue;
        
        public ProductByPropertiesQuery(string fieldName, string value)
        {
            _fieldName = fieldName;
            _propertyValue = value;
        }

        public IEnumerable<EntitiesV2.Product> Execute(NHibernate.ISession session)
        {
            return session.Query<UCommerce.EntitiesV2.Product>()
                .Where(product => product.ProductProperties.Any(
                    property=>property.Value == _propertyValue &&
                    property.ProductDefinitionField.Name == _fieldName));
        }
    }
}
