using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull(this object obj,string name)
        {
            if(obj == null)
                throw new ArgumentNullException(name);
        }
    }
}
