using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Entities
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class EnumDescription : Attribute
    {
        public EnumDescription(Type resourceType)
        {
            ResourceType = resourceType;
        }

        public Type ResourceType { get; }
    }
}
