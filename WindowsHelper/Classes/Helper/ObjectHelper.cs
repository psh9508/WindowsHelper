using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Classes.Helper
{
    public static class ObjectHelper
    {
        public static bool IsNull(this object src)
        {
            return ReferenceEquals(src, null);
        }

        public static bool IsNotNull(this object src)
        {
            return !ReferenceEquals(src, null);
        }
    }
}
