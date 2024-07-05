using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Utilities
{
    public static class CreateSpeciallyString
    {
        public static string CreateUniqCode()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
