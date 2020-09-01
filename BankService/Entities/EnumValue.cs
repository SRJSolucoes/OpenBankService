using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Entities
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValue : Attribute
    {
        public EnumValue(object value)
        {
            Value = value;
        }

        public object Value { get; }
    }
}
