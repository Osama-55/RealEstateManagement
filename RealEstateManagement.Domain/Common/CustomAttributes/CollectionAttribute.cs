using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionAttribute : Attribute
    {
        public string CollectionName { get; }

        public CollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
